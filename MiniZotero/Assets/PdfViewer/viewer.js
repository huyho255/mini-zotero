import * as pdfjsLib from "../PdfJs/build/pdf.mjs";

pdfjsLib.GlobalWorkerOptions.workerSrc = "../PdfJs/build/pdf.worker.mjs";

const viewer = document.getElementById("viewer");
const statusBar = document.getElementById("status");

const pageStates = new Map();

let pdfDocument = null;
let currentScale = 1.2;
let visualScale = 1.2;
let currentPage = 1;
let zoomTimer = null;
let isLiveZooming = false;
let scrollTimer = null;
let customSelection = null;
let areaSelectionBox = null;
let currentToolMode = "select";
let handPanState = null;
let storedHighlights = [];

const RENDER_QUALITY = 2;
const MAX_OUTPUT_SCALE = 4;
const MIN_ZOOM = 0.5;
const MAX_ZOOM = 4;
const AREA_SELECTION_THRESHOLD = 4;

function getQueryValue(name) {
    const params = new URLSearchParams(window.location.search);
    return params.get(name);
}

function getHashValue(name, fallback) {
    const hash = window.location.hash.replace("#", "");
    const params = new URLSearchParams(hash);
    return params.get(name) || fallback;
}

function clampScale(scale) {
    return Math.min(Math.max(scale, MIN_ZOOM), MAX_ZOOM);
}

function sendToCSharp(type, data = {}) {
    const payload = JSON.stringify({
        type,
        pageNumber: data.pageNumber || currentPage,
        zoomPercent: Math.round(currentScale * 100),
        ...data
    });

    try {
        if (typeof invokeCSharpAction === "function") {
            invokeCSharpAction(payload);
            return;
        }

        if (window.chrome?.webview?.postMessage) {
            window.chrome.webview.postMessage(payload);
            return;
        }

        if (window.webkit?.messageHandlers?.webview?.postMessage) {
            window.webkit.messageHandlers.webview.postMessage(payload);
        }
    } catch {
    }
}

function getOutputScale() {
    const deviceScale = window.devicePixelRatio || 1;
    return Math.min(deviceScale * RENDER_QUALITY, MAX_OUTPUT_SCALE);
}

function cancelTask(task) {
    try {
        task?.cancel?.();
    } catch {
    }
}

function isCancellationError(error) {
    return error?.name === "RenderingCancelledException" ||
        error?.name === "AbortException";
}

function applyPageVisualScale(state, nextVisualScale) {
    const visualWidth = Math.floor(state.baseWidth * nextVisualScale);
    const visualHeight = Math.floor(state.baseHeight * nextVisualScale);

    state.wrapper.style.width = `${visualWidth}px`;
    state.wrapper.style.height = `${visualHeight}px`;

    if (!state.content || !state.renderedScale) {
        return;
    }

    const ratio = nextVisualScale / state.renderedScale;

    if (Math.abs(ratio - 1) < 0.001) {
        state.content.style.transform = "";
        state.content.style.transformOrigin = "";
        return;
    }

    state.content.style.transform = `scale(${ratio})`;
    state.content.style.transformOrigin = "0 0";
}

function getZoomAnchor(clientX = null, clientY = null) {
    const viewerRect = viewer.getBoundingClientRect();
    const fallbackClientX = viewerRect.left + viewer.clientWidth / 2;
    const fallbackClientY = viewerRect.top + viewer.clientHeight / 2;
    const anchorClientX = clientX ?? fallbackClientX;
    const anchorClientY = clientY ?? fallbackClientY;
    const clampedClientX = Math.min(
        Math.max(anchorClientX, viewerRect.left),
        viewerRect.right
    );
    const clampedClientY = Math.min(
        Math.max(anchorClientY, viewerRect.top),
        viewerRect.bottom
    );

    let anchorState = null;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageRect = state.wrapper.getBoundingClientRect();

        if (pageRect.top <= clampedClientY && pageRect.bottom >= clampedClientY) {
            anchorState = state;
            break;
        }

        const pageMiddle = pageRect.top + pageRect.height / 2;
        const distance = Math.abs(pageMiddle - clampedClientY);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            anchorState = state;
        }
    }

    if (!anchorState) {
        return null;
    }

    const pageHeight = Math.max(anchorState.wrapper.clientHeight, 1);
    const pageWidth = Math.max(anchorState.wrapper.clientWidth, 1);
    const pageRect = anchorState.wrapper.getBoundingClientRect();
    const yRatio = Math.min(
        Math.max((clampedClientY - pageRect.top) / pageHeight, 0),
        1
    );
    const xRatio = Math.min(
        Math.max((clampedClientX - pageRect.left) / pageWidth, 0),
        1
    );

    return {
        pageNumber: anchorState.pageNumber,
        xRatio,
        yRatio,
        offsetInViewerX: clampedClientX - viewerRect.left,
        offsetInViewerY: clampedClientY - viewerRect.top
    };
}

function restoreZoomAnchor(anchor) {
    if (!anchor) {
        return;
    }

    const state = pageStates.get(anchor.pageNumber);

    if (!state) {
        return;
    }

    viewer.scrollLeft = state.wrapper.offsetLeft +
        state.wrapper.clientWidth * anchor.xRatio -
        anchor.offsetInViewerX;
    viewer.scrollTop = state.wrapper.offsetTop +
        state.wrapper.clientHeight * anchor.yRatio -
        anchor.offsetInViewerY;
}

async function cancelActiveRenderTasks() {
    for (const state of pageStates.values()) {
        cancelTask(state.renderTask);
        cancelTask(state.textLayerTask);
        state.renderTask = null;
        state.textLayerTask = null;
        state.renderPromise = null;
        state.renderingScale = 0;
    }
}

async function createPagePlaceholder(pageNumber) {
    const page = await pdfDocument.getPage(pageNumber);
    const baseViewport = page.getViewport({ scale: 1 });

    const wrapper = document.createElement("div");
    wrapper.className = "page";
    wrapper.dataset.pageNumber = String(pageNumber);

    const state = {
        pageNumber,
        wrapper,
        content: null,
        canvas: null,
        textLayer: null,
        highlightLayer: null,
        selectionOverlay: null,
        textItems: [],
        selectedWordRects: [],
        renderTask: null,
        textLayerTask: null,
        renderPromise: null,
        renderingScale: 0,
        renderedScale: 0,
        baseWidth: baseViewport.width,
        baseHeight: baseViewport.height,
        isRendered: false
    };

    pageStates.set(pageNumber, state);
    viewer.appendChild(wrapper);
    applyPageVisualScale(state, currentScale);
}

async function createPagePlaceholders() {
    viewer.innerHTML = "";
    pageStates.clear();

    for (let pageNumber = 1; pageNumber <= pdfDocument.numPages; pageNumber++) {
        await createPagePlaceholder(pageNumber);
    }
}

function buildSelectableWords(textContent, viewport) {
    const words = [];
    let globalIndex = 0;

    for (const item of textContent.items) {
        if (!item.str || !item.transform) {
            continue;
        }

        const text = item.str;
        const pdfTransform = pdfjsLib.Util.transform(
            viewport.transform,
            item.transform
        );
        const x = pdfTransform[4];
        const y = pdfTransform[5];
        const fontHeight = Math.abs(pdfTransform[3]) || item.height || 10;
        const itemWidth = Number.isFinite(item.width)
            ? Math.abs(item.width * viewport.scale)
            : Math.max(text.length * fontHeight * 0.45, 1);
        const parts = text.match(/\S+|\s+/g) ?? [];

        let cursorX = x;

        for (const part of parts) {
            const width = text.length > 0
                ? itemWidth * (part.length / text.length)
                : 0;

            if (part.trim().length > 0) {
                words.push({
                    index: globalIndex++,
                    text: part,
                    left: cursorX,
                    top: y - fontHeight,
                    right: cursorX + width,
                    bottom: y,
                    width,
                    height: fontHeight,
                    lineY: y
                });
            }

            cursorX += width;
        }
    }

    return words;
}

async function renderTextLayer(page, viewport, content, state) {
    const textLayerDiv = document.createElement("div");
    textLayerDiv.className = "textLayer";
    textLayerDiv.style.width = `${Math.floor(viewport.width)}px`;
    textLayerDiv.style.height = `${Math.floor(viewport.height)}px`;

    content.appendChild(textLayerDiv);

    const textContent = await page.getTextContent({
        includeMarkedContent: true,
        disableNormalization: false
    });

    state.textItems = buildSelectableWords(textContent, viewport);

    if (!pdfjsLib.TextLayer) {
        throw new Error("PDF.js TextLayer API is not available in this build.");
    }

    const textLayer = new pdfjsLib.TextLayer({
        textContentSource: textContent,
        container: textLayerDiv,
        viewport
    });

    state.textLayerTask = textLayer;
    await textLayer.render();
    state.textLayerTask = null;

    return textLayerDiv;
}

function createHighlightLayer(viewport) {
    const highlightLayer = document.createElement("div");
    highlightLayer.className = "highlightLayer";
    highlightLayer.style.width = `${Math.floor(viewport.width)}px`;
    highlightLayer.style.height = `${Math.floor(viewport.height)}px`;
    return highlightLayer;
}

async function renderPage(pageNumber, force = false) {
    const state = pageStates.get(pageNumber);

    if (!state || isLiveZooming) {
        return;
    }

    if (!force && state.isRendered && state.renderedScale === currentScale) {
        return;
    }

    if (!force && state.renderPromise && state.renderingScale === currentScale) {
        return state.renderPromise;
    }

    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);
    state.renderTask = null;
    state.textLayerTask = null;

    const renderPromise = renderPageInternal(state);
    state.renderPromise = renderPromise;
    state.renderingScale = currentScale;

    try {
        await renderPromise;
    } finally {
        if (state.renderPromise === renderPromise) {
            state.renderPromise = null;
            state.renderingScale = 0;
        }
    }
}

async function renderPageInternal(state) {
    const targetScale = currentScale;
    const page = await pdfDocument.getPage(state.pageNumber);
    const viewport = page.getViewport({ scale: targetScale });

    const content = document.createElement("div");
    content.className = "pageContent";
    content.style.width = `${Math.floor(viewport.width)}px`;
    content.style.height = `${Math.floor(viewport.height)}px`;
    content.style.setProperty("--total-scale-factor", String(targetScale));

    const canvas = document.createElement("canvas");
    canvas.className = "canvasLayer";
    canvas.style.width = `${Math.floor(viewport.width)}px`;
    canvas.style.height = `${Math.floor(viewport.height)}px`;

    const context = canvas.getContext("2d", {
        alpha: false
    });

    if (!context) {
        throw new Error("Unable to create canvas context.");
    }

    const outputScale = getOutputScale();

    canvas.width = Math.floor(viewport.width * outputScale);
    canvas.height = Math.floor(viewport.height * outputScale);

    content.appendChild(canvas);

    const renderTask = page.render({
        canvasContext: context,
        viewport,
        transform: outputScale !== 1
            ? [outputScale, 0, 0, outputScale, 0, 0]
            : null
    });

    state.renderTask = renderTask;

    try {
        await renderTask.promise;
    } catch (error) {
        if (isCancellationError(error)) {
            return;
        }

        throw error;
    } finally {
        if (state.renderTask === renderTask) {
            state.renderTask = null;
        }
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    let textLayer = null;

    try {
        textLayer = await renderTextLayer(page, viewport, content, state);
    } catch (error) {
        if (!isCancellationError(error)) {
            throw error;
        }

        return;
    } finally {
        state.textLayerTask = null;
    }

    if (isLiveZooming || targetScale !== currentScale) {
        return;
    }

    const highlightLayer = createHighlightLayer(viewport);
    content.appendChild(highlightLayer);

    const selectionOverlay = document.createElement("div");
    selectionOverlay.className = "selectionOverlay";
    content.appendChild(selectionOverlay);

    const oldContent = state.content;

    state.wrapper.appendChild(content);

    if (oldContent) {
        oldContent.remove();
    }

    state.content = content;
    state.canvas = canvas;
    state.textLayer = textLayer;
    state.highlightLayer = highlightLayer;
    state.selectionOverlay = selectionOverlay;
    state.renderedScale = targetScale;
    state.isRendered = true;

    renderStoredHighlightsForPage(state);
    applyPageVisualScale(state, visualScale);
}

function isPageNearViewport(wrapper, buffer = viewer.clientHeight) {
    const viewerRect = viewer.getBoundingClientRect();
    const pageRect = wrapper.getBoundingClientRect();

    return (
        pageRect.bottom >= viewerRect.top - buffer &&
        pageRect.top <= viewerRect.bottom + buffer
    );
}

function unloadPage(state) {
    cancelTask(state.renderTask);
    cancelTask(state.textLayerTask);

    state.content?.remove();

    state.content = null;
    state.canvas = null;
    state.textLayer = null;
    state.highlightLayer = null;
    state.selectionOverlay = null;
    state.textItems = [];
    state.selectedWordRects = [];
    state.renderTask = null;
    state.textLayerTask = null;
    state.renderPromise = null;
    state.renderingScale = 0;
    state.renderedScale = 0;
    state.isRendered = false;
}

function cleanupFarPages() {
    const buffer = viewer.clientHeight * 3;

    for (const state of pageStates.values()) {
        if (!isPageNearViewport(state.wrapper, buffer)) {
            unloadPage(state);
        }
    }
}

async function renderVisiblePages(force = false) {
    if (isLiveZooming) {
        return;
    }

    const renderPromises = [];

    for (const state of pageStates.values()) {
        if (isPageNearViewport(state.wrapper)) {
            renderPromises.push(renderPage(state.pageNumber, force));
        }
    }

    cleanupFarPages();
    await Promise.all(renderPromises);
}

function updateCurrentPageFromScroll() {
    if (pageStates.size === 0) {
        return;
    }

    const viewportMiddle = viewer.scrollTop + viewer.clientHeight / 2;

    let nearestPage = 1;
    let nearestDistance = Number.MAX_VALUE;

    for (const state of pageStates.values()) {
        const pageTop = state.wrapper.offsetTop;
        const pageMiddle = pageTop + state.wrapper.clientHeight / 2;
        const distance = Math.abs(pageMiddle - viewportMiddle);

        if (distance < nearestDistance) {
            nearestDistance = distance;
            nearestPage = state.pageNumber;
        }
    }

    if (nearestPage !== currentPage) {
        currentPage = nearestPage;
        statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function scrollToPage(pageNumber, notify = true) {
    const state = pageStates.get(pageNumber);

    if (!state) {
        return;
    }

    state.wrapper.scrollIntoView({ block: "start" });
    currentPage = pageNumber;

    if (notify) {
        sendToCSharp("pageChanged", { pageNumber: currentPage });
    }
}

function clearAllSelectionOverlays() {
    for (const state of pageStates.values()) {
        if (state.selectionOverlay) {
            state.selectionOverlay.innerHTML = "";
        }
    }
}

function clearCustomSelection() {
    customSelection = null;
    clearAllSelectionOverlays();
    clearAreaSelectionBox();
}

function clearAreaSelectionBox() {
    areaSelectionBox?.remove();
    areaSelectionBox = null;
}

function setToolMode(toolMode) {
    currentToolMode = ["hand", "highlight"].includes(toolMode)
        ? toolMode
        : "select";
    handPanState = null;
    viewer.classList.toggle("toolHand", currentToolMode === "hand");
    viewer.classList.toggle("toolSelect", currentToolMode === "select");
    viewer.classList.toggle("toolHighlight", currentToolMode === "highlight");
    viewer.classList.remove("panning");

    if (currentToolMode === "hand") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
    }
}

function startHandPan(event) {
    if (event.button !== 0 || isLiveZooming) {
        return false;
    }

    handPanState = {
        pointerId: event.pointerId,
        startClientX: event.clientX,
        startClientY: event.clientY,
        startScrollLeft: viewer.scrollLeft,
        startScrollTop: viewer.scrollTop
    };

    viewer.classList.add("panning");
    viewer.setPointerCapture?.(event.pointerId);
    event.preventDefault();
    return true;
}

function moveHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    viewer.scrollLeft = handPanState.startScrollLeft -
        (event.clientX - handPanState.startClientX);
    viewer.scrollTop = handPanState.startScrollTop -
        (event.clientY - handPanState.startClientY);
    event.preventDefault();
    return true;
}

function stopHandPan(event) {
    if (!handPanState || handPanState.pointerId !== event.pointerId) {
        return false;
    }

    handPanState = null;
    viewer.classList.remove("panning");

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    event.preventDefault();
    return true;
}

function getPagePointFromClient(state, clientX, clientY) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        x: (clientX - contentRect.left) / scaleX,
        y: (clientY - contentRect.top) / scaleY
    };
}

function findRenderedPageAtClientPoint(clientX, clientY) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX >= contentRect.left &&
            clientX <= contentRect.right &&
            clientY >= contentRect.top &&
            clientY <= contentRect.bottom
        ) {
            return state;
        }
    }

    return null;
}

function findWordAtClientPoint(clientX, clientY, includeNearbyWord = true) {
    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (
            clientX < contentRect.left ||
            clientX > contentRect.right ||
            clientY < contentRect.top ||
            clientY > contentRect.bottom
        ) {
            continue;
        }

        const point = getPagePointFromClient(state, clientX, clientY);
        let bestWord = null;
        let bestDistance = Number.MAX_VALUE;

        for (const word of state.textItems) {
            const inside =
                point.x >= word.left &&
                point.x <= word.right &&
                point.y >= word.top &&
                point.y <= word.bottom;

            if (inside) {
                return { state, word };
            }

            const centerX = (word.left + word.right) / 2;
            const centerY = (word.top + word.bottom) / 2;
            const dx = point.x - centerX;
            const dy = point.y - centerY;
            const distance = dx * dx + dy * dy;

            if (distance < bestDistance) {
                bestDistance = distance;
                bestWord = word;
            }
        }

        if (includeNearbyWord && bestWord && bestDistance < 900) {
            return {
                state,
                word: bestWord
            };
        }
    }

    return null;
}

function getClientDragRect(selection) {
    const left = Math.min(selection.startClientX, selection.endClientX);
    const top = Math.min(selection.startClientY, selection.endClientY);
    const right = Math.max(selection.startClientX, selection.endClientX);
    const bottom = Math.max(selection.startClientY, selection.endClientY);

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function rectsIntersect(first, second) {
    return first.right >= second.left &&
        first.left <= second.right &&
        first.bottom >= second.top &&
        first.top <= second.bottom;
}

function getWordClientRect(state, word) {
    const contentRect = state.content.getBoundingClientRect();
    const scaleX = contentRect.width / state.content.offsetWidth;
    const scaleY = contentRect.height / state.content.offsetHeight;

    return {
        left: contentRect.left + word.left * scaleX,
        top: contentRect.top + word.top * scaleY,
        right: contentRect.left + word.right * scaleX,
        bottom: contentRect.top + word.bottom * scaleY
    };
}

function getOrCreateAreaSelectionBox() {
    if (areaSelectionBox) {
        return areaSelectionBox;
    }

    areaSelectionBox = document.createElement("div");
    areaSelectionBox.className = "selectionDragBox";
    viewer.appendChild(areaSelectionBox);
    return areaSelectionBox;
}

function renderAreaSelectionBox(selection) {
    const dragRect = getClientDragRect(selection);

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        clearAreaSelectionBox();
        return;
    }

    const viewerRect = viewer.getBoundingClientRect();
    const box = getOrCreateAreaSelectionBox();

    box.style.left = `${dragRect.left - viewerRect.left + viewer.scrollLeft}px`;
    box.style.top = `${dragRect.top - viewerRect.top + viewer.scrollTop}px`;
    box.style.width = `${dragRect.width}px`;
    box.style.height = `${dragRect.height}px`;
}

function updateAreaSelectionWords(selection) {
    const dragRect = getClientDragRect(selection);
    const wordIndexesByPage = new Map();

    if (dragRect.width < AREA_SELECTION_THRESHOLD &&
        dragRect.height < AREA_SELECTION_THRESHOLD) {
        selection.wordIndexesByPage = wordIndexesByPage;
        return;
    }

    for (const state of pageStates.values()) {
        if (!state.content || !state.isRendered || state.textItems.length === 0) {
            continue;
        }

        const contentRect = state.content.getBoundingClientRect();

        if (!rectsIntersect(dragRect, contentRect)) {
            continue;
        }

        const selectedIndexes = new Set();

        for (const word of state.textItems) {
            if (rectsIntersect(dragRect, getWordClientRect(state, word))) {
                selectedIndexes.add(word.index);
            }
        }

        if (selectedIndexes.size > 0) {
            wordIndexesByPage.set(state.pageNumber, selectedIndexes);
        }
    }

    selection.wordIndexesByPage = wordIndexesByPage;
}

function compareSelectionPosition(firstPage, firstIndex, secondPage, secondIndex) {
    if (firstPage !== secondPage) {
        return firstPage - secondPage;
    }

    return firstIndex - secondIndex;
}

function getSelectedWordsForPage(state) {
    if (!customSelection || state.textItems.length === 0) {
        return [];
    }

    if (customSelection.mode === "area") {
        const selectedIndexes = customSelection.wordIndexesByPage?.get(state.pageNumber);

        if (!selectedIndexes) {
            return [];
        }

        return state.textItems.filter(word => selectedIndexes.has(word.index));
    }

    const direction = compareSelectionPosition(
        customSelection.startPage,
        customSelection.startWordIndex,
        customSelection.endPage,
        customSelection.endWordIndex
    );
    const isForward = direction <= 0;
    const firstPage = isForward ? customSelection.startPage : customSelection.endPage;
    const lastPage = isForward ? customSelection.endPage : customSelection.startPage;

    if (state.pageNumber < firstPage || state.pageNumber > lastPage) {
        return [];
    }

    let startIndex = 0;
    let endIndex = state.textItems[state.textItems.length - 1].index;

    if (isForward) {
        if (state.pageNumber === customSelection.startPage) {
            startIndex = customSelection.startWordIndex;
        }

        if (state.pageNumber === customSelection.endPage) {
            endIndex = customSelection.endWordIndex;
        }
    } else {
        if (state.pageNumber === customSelection.endPage) {
            startIndex = customSelection.endWordIndex;
        }

        if (state.pageNumber === customSelection.startPage) {
            endIndex = customSelection.startWordIndex;
        }
    }

    if (startIndex > endIndex) {
        const temp = startIndex;
        startIndex = endIndex;
        endIndex = temp;
    }

    return state.textItems.filter(word =>
        word.index >= startIndex &&
        word.index <= endIndex
    );
}

function groupWordsByLine(words) {
    const lines = new Map();

    for (const word of words) {
        const key = Math.round(word.lineY / 4) * 4;

        if (!lines.has(key)) {
            lines.set(key, []);
        }

        lines.get(key).push(word);
    }

    return [...lines.entries()].sort((first, second) => first[0] - second[0]);
}

function renderCustomSelection() {
    clearAllSelectionOverlays();

    for (const state of pageStates.values()) {
        if (!state.selectionOverlay) {
            continue;
        }

        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const fragment = document.createDocumentFragment();

        for (const segment of buildHighlightSegments(words, state)) {
            const rect = document.createElement("div");

            rect.className = "selectionOverlayRect";
            rect.style.left = `${segment.left}px`;
            rect.style.top = `${segment.top}px`;
            rect.style.width = `${segment.width}px`;
            rect.style.height = `${segment.height}px`;

            fragment.appendChild(rect);
        }

        state.selectionOverlay.appendChild(fragment);
    }
}

function getRenderedPageWidth(state) {
    if (state.content?.offsetWidth) {
        return state.content.offsetWidth;
    }

    if (state.baseWidth && state.renderedScale) {
        return state.baseWidth * state.renderedScale;
    }

    return state.baseWidth * currentScale;
}

function getLineFontHeight(line) {
    const heights = line.words
        .map(word => word.height || 0)
        .filter(height => height > 0)
        .sort((first, second) => first - second);

    return heights.length === 0
        ? 12
        : heights[Math.floor(heights.length / 2)];
}

function getLineText(line) {
    return line.words
        .map(word => word.text ?? "")
        .join("")
        .trim();
}

function compareLinePosition(first, second) {
    const fontHeight = Math.max(getLineFontHeight(first), getLineFontHeight(second));
    const yTolerance = Math.max(2, fontHeight * 0.4);

    if (Math.abs(first.top - second.top) > yTolerance) {
        return first.top - second.top;
    }

    return first.left - second.left;
}

function isProbablyHeadingText(text) {
    if (!text) {
        return false;
    }

    const normalized = text.replace(/\s+/g, " ").trim();

    if (normalized.length <= 3) {
        return false;
    }

    const isUpper = /^([IVXLCDM]+\.?\s+)?[A-ZÀ-Ỵ0-9\s\-–().:]+$/.test(normalized);
    const isNumbered = /^(chương|chapter|section|phần|mục|\d+(\.\d+)*\.?)\s+\d*.*$/i.test(normalized);
    const isCommonHeader = /^(Abstract|Introduction|Methodology|Methods|Results|Discussion|Conclusion|References|Acknowledgment|Tóm\s+tắt|Tổng\s+quan|Kết\s+luận)$/i.test(normalized);

    return isUpper || isNumbered || isCommonHeader;
}

function isFullWidthLine(line, state) {
    const pageWidth = getRenderedPageWidth(state);
    const widthRatio = line.width / Math.max(pageWidth, 1);
    const touchesLeft = line.left <= pageWidth * 0.2;
    const touchesRight = line.right >= pageWidth * 0.8;

    return widthRatio >= 0.65 ||
        (widthRatio >= 0.52 && touchesLeft && touchesRight);
}

function isStructuralLine(line, state) {
    if (isFullWidthLine(line, state)) {
        return true;
    }

    const text = getLineText(line);
    const pageWidth = getRenderedPageWidth(state);

    return isProbablyHeadingText(text) &&
        (line.width / Math.max(pageWidth, 1)) <= 0.65;
}

function groupWordsIntoVisualLines(words, state) {
    const pageWidth = getRenderedPageWidth(state);
    const sortedWords = [...words].sort((first, second) => {
        const fontHeight = Math.max(first.height || 12, second.height || 12);

        return Math.abs(first.lineY - second.lineY) > Math.max(2, fontHeight * 0.4)
            ? first.lineY - second.lineY
            : first.left - second.left;
    });
    const rows = [];

    for (const word of sortedWords) {
        const yTolerance = Math.max(2, (word.height || 12) * 0.4);
        let targetRow = rows.find(row => Math.abs(row.lineY - word.lineY) <= yTolerance);

        if (!targetRow) {
            targetRow = {
                lineY: word.lineY,
                words: []
            };
            rows.push(targetRow);
        }

        targetRow.words.push(word);
    }

    const lines = [];

    for (const row of rows) {
        const rowWords = row.words.sort((first, second) => first.left - second.left);
        let currentLineWords = [];

        for (const word of rowWords) {
            const previous = currentLineWords[currentLineWords.length - 1];

            if (!previous) {
                currentLineWords.push(word);
                continue;
            }

            const fontHeight = Math.max(previous.height || 12, word.height || 12);

            if ((word.left - previous.right) > Math.max(fontHeight * 2.8, pageWidth * 0.022)) {
                lines.push(createVisualLineFromWords(currentLineWords));
                currentLineWords = [word];
            } else {
                currentLineWords.push(word);
            }
        }

        if (currentLineWords.length > 0) {
            lines.push(createVisualLineFromWords(currentLineWords));
        }
    }

    return lines.sort(compareLinePosition);
}

function createVisualLineFromWords(words) {
    const left = Math.min(...words.map(word => word.left));
    const right = Math.max(...words.map(word => word.right));
    const top = Math.min(...words.map(word => word.top));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        words,
        left,
        right,
        top,
        bottom,
        lineY: words.reduce((sum, word) => sum + word.lineY, 0) / words.length,
        width: right - left,
        height: bottom - top,
        centerX: (left + right) / 2
    };
}

function getHorizontalOverlapRatio(line, column) {
    const overlap = Math.min(line.right, column.right) -
        Math.max(line.left, column.left);

    return overlap <= 0
        ? 0
        : overlap / Math.min(line.width, column.right - column.left);
}

function groupLinesIntoColumns(lines, state) {
    const columns = [];

    for (const line of [...lines].sort(compareLinePosition)) {
        if (isStructuralLine(line, state)) {
            columns.push({
                lines: [line],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: true
            });
            continue;
        }

        let bestColumn = null;
        let bestScore = 0;

        for (const column of columns) {
            if (column.isStructural) {
                continue;
            }

            const overlapScore = getHorizontalOverlapRatio(line, column);
            const xTolerance = Math.max(3, getLineFontHeight(line) * 0.75);
            const score = line.centerX >= column.left - xTolerance &&
                line.centerX <= column.right + xTolerance
                ? Math.max(overlapScore, 0.5)
                : overlapScore;

            if (score > bestScore) {
                bestScore = score;
                bestColumn = column;
            }
        }

        if (!bestColumn || bestScore < 0.25) {
            bestColumn = {
                lines: [],
                left: line.left,
                right: line.right,
                top: line.top,
                bottom: line.bottom,
                isStructural: false
            };
            columns.push(bestColumn);
        }

        bestColumn.lines.push(line);
        bestColumn.left = Math.min(bestColumn.left, line.left);
        bestColumn.right = Math.max(bestColumn.right, line.right);
        bestColumn.top = Math.min(bestColumn.top, line.top);
        bestColumn.bottom = Math.max(bestColumn.bottom, line.bottom);
    }

    return columns;
}

function getCopyLinesInReadingOrder(words, state) {
    const lines = groupWordsIntoVisualLines(words, state);

    if (lines.length === 0) {
        return [];
    }

    const sortedLines = [...lines].sort(compareLinePosition);
    const output = [];
    let sectionLines = [];

    function flushSection() {
        if (sectionLines.length === 0) {
            return;
        }

        const columns = groupLinesIntoColumns(sectionLines, state)
            .filter(column => !column.isStructural)
            .sort((first, second) => first.left - second.left);

        for (const column of columns) {
            for (const line of column.lines.sort(compareLinePosition)) {
                output.push(line.words);
            }
        }

        sectionLines = [];
    }

    for (const line of sortedLines) {
        if (isStructuralLine(line, state)) {
            flushSection();
            output.push(line.words);
            continue;
        }

        sectionLines.push(line);
    }

    flushSection();
    return output;
}

function shouldInsertSpaceBetweenWords(previous, current) {
    if (!previous || !current) {
        return false;
    }

    const previousText = previous.text ?? "";
    const currentText = current.text ?? "";

    if (!previousText ||
        !currentText ||
        /^[,.;:!?%)\]\}]/.test(currentText) ||
        /[(\[\{]$/.test(previousText)) {
        return false;
    }

    return (current.left - previous.right) >
        Math.max(2, Math.max(previous.height || 0, current.height || 0, 10) * 0.22);
}

function buildCopiedLineText(lineWords) {
    const sortedWords = [...lineWords].sort((first, second) => first.left - second.left);
    let result = "";
    let previous = null;

    for (const word of sortedWords) {
        if (!word.text) {
            continue;
        }

        if (previous && shouldInsertSpaceBetweenWords(previous, word)) {
            result += " ";
        }

        result += word.text;
        previous = word;
    }

    return result
        .replace(/\s+([,.;:!?%)\]\}])/g, "$1")
        .replace(/([(\[\{])\s+/g, "$1")
        .replace(/\s{2,}/g, " ")
        .trim();
}

function shouldSplitHighlightSegment(previous, current, state) {
    if (!previous || !current) {
        return false;
    }

    const gap = current.left - previous.right;
    const fontHeight = Math.max(previous.height || 12, current.height || 12);
    const pageWidth = getRenderedPageWidth(state);

    return gap > Math.max(fontHeight * 1.15, pageWidth * 0.012, 8);
}

function createHighlightSegment(words) {
    const left = Math.min(...words.map(word => word.left));
    const top = Math.min(...words.map(word => word.top));
    const right = Math.max(...words.map(word => word.right));
    const bottom = Math.max(...words.map(word => word.bottom));

    return {
        left,
        top,
        right,
        bottom,
        width: right - left,
        height: bottom - top
    };
}

function buildHighlightSegments(words, state) {
    const segments = [];
    const lines = groupWordsIntoVisualLines(words, state);

    for (const line of lines) {
        const sortedWords = [...line.words].sort((first, second) => first.left - second.left);
        let segmentWords = [];

        for (const word of sortedWords) {
            const previous = segmentWords[segmentWords.length - 1];

            if (previous && shouldSplitHighlightSegment(previous, word, state)) {
                segments.push(createHighlightSegment(segmentWords));
                segmentWords = [];
            }

            segmentWords.push(word);
        }

        if (segmentWords.length > 0) {
            segments.push(createHighlightSegment(segmentWords));
        }
    }

    return segments;
}

function getCustomSelectedText() {
    if (!customSelection) {
        return "";
    }

    const selectedLines = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const pageLines = getCopyLinesInReadingOrder(words, state)
            .map(lineWords => buildCopiedLineText(lineWords))
            .filter(line => line.length > 0);

        selectedLines.push(...pageLines);
    }

    return selectedLines.join("\n");
}

function getSelectedHighlightRects() {
    if (!customSelection) {
        return [];
    }

    const result = [];

    for (const state of pageStates.values()) {
        const words = getSelectedWordsForPage(state);

        if (words.length === 0) {
            continue;
        }

        const scale = state.renderedScale || currentScale || 1;

        for (const segment of buildHighlightSegments(words, state)) {
            result.push({
                pageNumber: state.pageNumber,
                left: segment.left / scale,
                top: segment.top / scale,
                width: segment.width / scale,
                height: segment.height / scale
            });
        }
    }

    return result;
}

function renderStoredHighlightsForPage(state) {
    if (!state.highlightLayer) {
        return;
    }

    state.highlightLayer.innerHTML = "";

    const scale = state.renderedScale || currentScale || 1;

    for (const highlight of storedHighlights) {
        const rects = highlight.rects ?? highlight.Rects ?? [];

        for (const rect of rects) {
            const pageNumber = rect.pageNumber ?? rect.PageNumber;

            if (pageNumber !== state.pageNumber) {
                continue;
            }

            const left = rect.left ?? rect.Left ?? 0;
            const top = rect.top ?? rect.Top ?? 0;
            const width = rect.width ?? rect.Width ?? 0;
            const height = rect.height ?? rect.Height ?? 0;
            const item = document.createElement("div");

            item.className = "highlightItem";
            item.dataset.highlightId = highlight.id ?? highlight.Id ?? "";
            item.style.left = `${left * scale}px`;
            item.style.top = `${top * scale}px`;
            item.style.width = `${width * scale}px`;
            item.style.height = `${height * scale}px`;

            state.highlightLayer.appendChild(item);
        }
    }
}

function renderAllStoredHighlights() {
    for (const state of pageStates.values()) {
        renderStoredHighlightsForPage(state);
    }
}

function setStoredHighlights(highlights) {
    storedHighlights = Array.isArray(highlights)
        ? highlights
        : [];
    renderAllStoredHighlights();
}

function navigateToStoredHighlight(highlightId) {
    const highlight = storedHighlights.find(item =>
        (item.id ?? item.Id) === highlightId
    );

    if (!highlight) {
        return;
    }

    const rects = highlight.rects ?? highlight.Rects ?? [];

    if (rects.length === 0) {
        return;
    }

    const firstRect = rects[0];
    const pageNumber = firstRect.pageNumber ?? firstRect.PageNumber ?? 1;

    clearCustomSelection();
    scrollToPage(pageNumber);

    setTimeout(async () => {
        await renderVisiblePages(true);
        renderAllStoredHighlights();

        const state = pageStates.get(pageNumber);

        if (!state) {
            return;
        }

        const scale = state.renderedScale || currentScale || 1;
        const top = (firstRect.top ?? firstRect.Top ?? 0) * scale;

        viewer.scrollTop = state.wrapper.offsetTop + top - 80;
    }, 120);
}

function createHighlightFromSelection() {
    const text = getCustomSelectedText();
    const rects = getSelectedHighlightRects();

    if (!text || rects.length === 0) {
        return;
    }

    const firstRect = rects[0];

    sendToCSharp("highlightCreated", {
        text,
        pageNumber: firstRect.pageNumber,
        rects
    });

    clearCustomSelection();
}

function scheduleZoom(newScale, anchorClientX = null, anchorClientY = null) {
    clearCustomSelection();
    window.getSelection()?.removeAllRanges();

    const anchor = getZoomAnchor(anchorClientX, anchorClientY);

    visualScale = clampScale(newScale);
    isLiveZooming = true;

    viewer.classList.add("viewerLiveZoom");

    for (const state of pageStates.values()) {
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(anchor);
    clearTimeout(zoomTimer);

    zoomTimer = setTimeout(async () => {
        await finishZoom(visualScale, anchor);
    }, 300);
}

async function finishZoom(finalScale, zoomAnchor = null) {
    currentScale = clampScale(finalScale);
    visualScale = currentScale;
    isLiveZooming = false;

    viewer.classList.remove("viewerLiveZoom");

    await cancelActiveRenderTasks();

    for (const state of pageStates.values()) {
        state.isRendered = false;
        applyPageVisualScale(state, visualScale);
    }

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());

    await renderVisiblePages(true);

    restoreZoomAnchor(zoomAnchor ?? getZoomAnchor());
    updateCurrentPageFromScroll();
    sendToCSharp("zoomChanged", {
        pageNumber: currentPage
    });
}

window.miniZoteroPdf = {
    goToPage(pageNumber) {
        scrollToPage(pageNumber);
        renderVisiblePages();
    },

    zoomIn() {
        scheduleZoom(visualScale + 0.25);
    },

    zoomOut() {
        scheduleZoom(visualScale - 0.25);
    },

    setZoom(percent) {
        scheduleZoom(percent / 100);
    },

    setToolMode(toolMode) {
        setToolMode(toolMode);
    },

    setHighlights(highlights) {
        setStoredHighlights(highlights);
    },

    goToHighlight(highlightId) {
        navigateToStoredHighlight(highlightId);
    },

    getState() {
        sendToCSharp("state", {
            pageNumber: currentPage
        });
    }
};

async function boot() {
    try {
        setToolMode(currentToolMode);

        const fileUrl = getQueryValue("file");

        if (!fileUrl) {
            throw new Error("Missing file query parameter.");
        }

        const startPage = Number(getHashValue("page", "1"));
        const startZoom = Number(getHashValue("zoom", "120"));

        currentPage = Number.isFinite(startPage) && startPage > 0 ? startPage : 1;
        currentScale = Number.isFinite(startZoom) && startZoom > 0
            ? clampScale(startZoom / 100)
            : 1.2;
        visualScale = currentScale;

        statusBar.textContent = "Loading PDF...";

        pdfDocument = await pdfjsLib.getDocument({
            url: fileUrl,
            cMapUrl: "/PdfJs/cmaps/",
            cMapPacked: true,
            standardFontDataUrl: "/PdfJs/standard_fonts/",
            useSystemFonts: true
        }).promise;

        await createPagePlaceholders();

        setTimeout(async () => {
            scrollToPage(currentPage, false);
            await renderVisiblePages(true);
            statusBar.textContent = `Page ${currentPage} / ${pdfDocument.numPages}`;
            sendToCSharp("loaded", { pageNumber: currentPage });
        }, 150);
    } catch (error) {
        statusBar.textContent = "Failed to load PDF";

        const errorBox = document.createElement("div");
        errorBox.className = "error";
        errorBox.textContent = error?.message || String(error);

        viewer.innerHTML = "";
        viewer.appendChild(errorBox);
    }
}

viewer.addEventListener("scroll", () => {
    clearTimeout(scrollTimer);

    scrollTimer = setTimeout(async () => {
        updateCurrentPageFromScroll();
        await renderVisiblePages();
        renderCustomSelection();
    }, 120);
}, { passive: true });

viewer.addEventListener("pointerdown", event => {
    if (currentToolMode === "hand") {
        startHandPan(event);
        return;
    }

    if (event.button !== 0 || isLiveZooming) {
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY, false);

    if (!hit) {
        const pageState = findRenderedPageAtClientPoint(event.clientX, event.clientY);

        if (!pageState) {
            clearCustomSelection();
            return;
        }

        event.preventDefault();

        customSelection = {
            mode: "area",
            startClientX: event.clientX,
            startClientY: event.clientY,
            endClientX: event.clientX,
            endClientY: event.clientY,
            isDragging: true,
            wordIndexesByPage: new Map()
        };

        viewer.setPointerCapture?.(event.pointerId);
        clearAllSelectionOverlays();
        return;
    }

    event.preventDefault();

    customSelection = {
        mode: "word",
        startPage: hit.state.pageNumber,
        startWordIndex: hit.word.index,
        endPage: hit.state.pageNumber,
        endWordIndex: hit.word.index,
        isDragging: true
    };

    viewer.setPointerCapture?.(event.pointerId);
    renderCustomSelection();
});

viewer.addEventListener("pointermove", event => {
    if (currentToolMode === "hand") {
        moveHandPan(event);
        return;
    }

    if (!customSelection?.isDragging || isLiveZooming) {
        return;
    }

    if (customSelection.mode === "area") {
        event.preventDefault();

        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;

        renderAreaSelectionBox(customSelection);
        updateAreaSelectionWords(customSelection);
        renderCustomSelection();
        return;
    }

    const hit = findWordAtClientPoint(event.clientX, event.clientY);

    if (!hit) {
        return;
    }

    event.preventDefault();

    customSelection.endPage = hit.state.pageNumber;
    customSelection.endWordIndex = hit.word.index;

    renderCustomSelection();
});

viewer.addEventListener("pointerup", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;

    if (customSelection.mode === "area") {
        customSelection.endClientX = event.clientX;
        customSelection.endClientY = event.clientY;
        updateAreaSelectionWords(customSelection);
    }

    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }

    renderCustomSelection();

    if (currentToolMode === "highlight") {
        createHighlightFromSelection();
    }
});

viewer.addEventListener("pointercancel", event => {
    if (stopHandPan(event)) {
        return;
    }

    if (!customSelection) {
        return;
    }

    customSelection.isDragging = false;
    clearAreaSelectionBox();

    try {
        viewer.releasePointerCapture?.(event.pointerId);
    } catch {
    }
});

viewer.addEventListener("wheel", event => {
    if (!event.ctrlKey) {
        return;
    }

    event.preventDefault();

    const direction = event.deltaY < 0 ? 1 : -1;
    const factor = direction > 0 ? 1.1 : 0.9;

    scheduleZoom(visualScale * factor, event.clientX, event.clientY);
}, { passive: false });

document.addEventListener("copy", event => {
    const text = getCustomSelectedText();

    if (!text) {
        return;
    }

    event.preventDefault();
    event.clipboardData?.setData("text/plain", text);
});

document.addEventListener("keydown", event => {
    if (event.key === "Escape") {
        clearCustomSelection();
        window.getSelection()?.removeAllRanges();
        return;
    }

    if (event.ctrlKey && event.key.toLowerCase() === "h") {
        event.preventDefault();
        createHighlightFromSelection();
    }
});

boot();

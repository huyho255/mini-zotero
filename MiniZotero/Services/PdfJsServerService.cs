using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public sealed class PdfJsServerService
    {
        private readonly HttpListener _listener = new();
        private readonly ConcurrentDictionary<string, string> _pdfFiles = new();

        private bool _isStarted;

        public int Port { get; } = 51234;

        public string BaseUrl => $"http://127.0.0.1:{Port}";

        public void Start()
        {
            if (_isStarted)
            {
                return;
            }

            _listener.Prefixes.Add($"{BaseUrl}/");
            _listener.Start();

            _isStarted = true;

            Task.Run(ListenLoop);
        }

        public string RegisterPdf(string documentKey, string filePath, int pageNumber = 1)
        {
            _pdfFiles[documentKey] = filePath;

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            string pdfUrl = $"{BaseUrl}/pdf/{Uri.EscapeDataString(documentKey)}";

            string viewerUrl =
                $"{BaseUrl}/viewer/index.html" +
                $"?file={Uri.EscapeDataString(pdfUrl)}" +
                $"#page={pageNumber}&zoom=120";

            return viewerUrl;
        }

        private async Task ListenLoop()
        {
            while (_listener.IsListening)
            {
                try
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    _ = Task.Run(() => HandleRequest(context));
                }
                catch
                {
                    // Ignore listener errors.
                }
            }
        }

        private void HandleRequest(HttpListenerContext context)
        {
            try
            {
                string path = context.Request.Url?.AbsolutePath ?? "/";

                if (path.StartsWith("/viewer/", StringComparison.OrdinalIgnoreCase))
                {
                    ServeAssetFile(context, "PdfViewer", path.Replace("/viewer/", string.Empty));
                    return;
                }

                if (path.StartsWith("/PdfJs/", StringComparison.OrdinalIgnoreCase) ||
                    path.StartsWith("/pdfjs/", StringComparison.OrdinalIgnoreCase))
                {
                    string relativePath = path
                        .Replace("/PdfJs/", string.Empty)
                        .Replace("/pdfjs/", string.Empty);

                    ServeAssetFile(context, "PdfJs", relativePath);
                    return;
                }

                if (path.StartsWith("/pdf/", StringComparison.OrdinalIgnoreCase))
                {
                    ServePdfFile(context, path);
                    return;
                }

                WriteText(context, "MiniZotero PDF server is running.");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                WriteText(context, ex.Message);
            }
            finally
            {
                try
                {
                    context.Response.OutputStream.Close();
                }
                catch
                {
                    // Ignore.
                }
            }
        }

        private void ServeAssetFile(HttpListenerContext context, string rootFolder, string relativePath)
        {
            relativePath = Uri.UnescapeDataString(relativePath)
                .Replace('/', Path.DirectorySeparatorChar);

            string filePath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                rootFolder,
                relativePath
            ));

            string rootPath = Path.GetFullPath(Path.Combine(
                AppContext.BaseDirectory,
                "Assets",
                rootFolder
            ));

            if (!filePath.StartsWith(rootPath, StringComparison.OrdinalIgnoreCase))
            {
                context.Response.StatusCode = 403;
                WriteText(context, "Asset path is not allowed.");
                return;
            }

            if (!File.Exists(filePath))
            {
                context.Response.StatusCode = 404;
                WriteText(context, $"Asset not found: {filePath}");
                return;
            }

            byte[] data = File.ReadAllBytes(filePath);

            context.Response.ContentType = GetContentType(filePath);
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(data, 0, data.Length);
        }

        private void ServePdfFile(HttpListenerContext context, string path)
        {
            string documentKey = Uri.UnescapeDataString(
                path.Replace("/pdf/", string.Empty)
            );

            if (!_pdfFiles.TryGetValue(documentKey, out string? pdfPath))
            {
                context.Response.StatusCode = 404;
                WriteText(context, "PDF is not registered.");
                return;
            }

            if (!File.Exists(pdfPath))
            {
                context.Response.StatusCode = 404;
                WriteText(context, $"PDF file not found: {pdfPath}");
                return;
            }

            byte[] data = File.ReadAllBytes(pdfPath);

            context.Response.ContentType = "application/pdf";
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(data, 0, data.Length);
        }

        private static string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLowerInvariant();

            return extension switch
            {
                ".html" => "text/html; charset=utf-8",
                ".css" => "text/css; charset=utf-8",
                ".js" => "text/javascript; charset=utf-8",
                ".mjs" => "text/javascript; charset=utf-8",
                ".json" => "application/json; charset=utf-8",
                ".wasm" => "application/wasm",
                ".png" => "image/png",
                ".svg" => "image/svg+xml",
                ".pdf" => "application/pdf",
                _ => "application/octet-stream"
            };
        }

        private static void WriteText(HttpListenerContext context, string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);

            context.Response.ContentType = "text/plain; charset=utf-8";
            context.Response.ContentLength64 = data.Length;
            context.Response.OutputStream.Write(data, 0, data.Length);
        }
    }
}

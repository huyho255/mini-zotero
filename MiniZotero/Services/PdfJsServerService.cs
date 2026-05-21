using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniZotero.Services;

public class PdfJsServerService
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

    public string RegisterPdf(string documentId, string filePath)
    {
        _pdfFiles[documentId] = filePath;

        string pdfUrl = $"{BaseUrl}/pdf/{Uri.EscapeDataString(documentId)}";
        string viewerUrl = $"{BaseUrl}/pdfjs/web/viewer.html?file={Uri.EscapeDataString(pdfUrl)}";

        return viewerUrl;
    }

    private async Task ListenLoop()
    {
        while (_listener.IsListening)
        {
            try
            {
                var context = await _listener.GetContextAsync();
                _ = Task.Run(() => HandleRequest(context));
            }
            catch
            {
                // Server stopped or request failed.
            }
        }
    }

    private void HandleRequest(HttpListenerContext context)
    {
        try
        {
            string path = context.Request.Url?.AbsolutePath ?? "/";

            if (path.StartsWith("/pdfjs/", StringComparison.OrdinalIgnoreCase))
            {
                ServePdfJsFile(context, path);
                return;
            }

            if (path.StartsWith("/pdf/", StringComparison.OrdinalIgnoreCase))
            {
                ServePdfFile(context, path);
                return;
            }

            WriteText(context, "MiniZotero local server is running.");
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

    private void ServePdfJsFile(HttpListenerContext context, string path)
    {
        string relativePath = path.Replace("/pdfjs/", string.Empty)
            .Replace('/', Path.DirectorySeparatorChar);

        string filePath = Path.Combine(
            AppContext.BaseDirectory,
            "Assets",
            "PdfJs",
            relativePath
        );

        if (!File.Exists(filePath))
        {
            context.Response.StatusCode = 404;
            WriteText(context, $"PDF.js file not found: {filePath}");
            return;
        }

        byte[] data = File.ReadAllBytes(filePath);

        context.Response.ContentType = GetContentType(filePath);
        context.Response.ContentLength64 = data.Length;
        context.Response.OutputStream.Write(data, 0, data.Length);
    }

    private void ServePdfFile(HttpListenerContext context, string path)
    {
        string documentId = Uri.UnescapeDataString(path.Replace("/pdf/", string.Empty));

        if (!_pdfFiles.TryGetValue(documentId, out string? pdfPath))
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

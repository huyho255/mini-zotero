using System;
using System.IO;
using System.Text.Json;

namespace MiniZotero.Services
{
    public sealed class JsonFileStore
    {
        public static readonly JsonSerializerOptions DefaultJsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly JsonSerializerOptions _jsonOptions;

        public JsonFileStore()
            : this(DefaultJsonOptions)
        {
        }

        public JsonFileStore(JsonSerializerOptions jsonOptions)
        {
            _jsonOptions = jsonOptions;
        }

        public T Load<T>(string path, T fallback)
        {
            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                return fallback;
            }

            try
            {
                var json = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(json, _jsonOptions) ?? fallback;
            }
            catch (IOException)
            {
                return fallback;
            }
            catch (JsonException)
            {
                return fallback;
            }
            catch (UnauthorizedAccessException)
            {
                return fallback;
            }
        }

        public void Save<T>(string path, T value)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }

            var directoryPath = Path.GetDirectoryName(path);

            if (!string.IsNullOrWhiteSpace(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var temporaryPath = $"{path}.{Guid.NewGuid():N}.tmp";
            var json = JsonSerializer.Serialize(value, _jsonOptions);

            try
            {
                File.WriteAllText(temporaryPath, json);
                File.Move(temporaryPath, path, overwrite: true);
            }
            finally
            {
                try
                {
                    if (File.Exists(temporaryPath))
                    {
                        File.Delete(temporaryPath);
                    }
                }
                catch (IOException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
        }
    }
}

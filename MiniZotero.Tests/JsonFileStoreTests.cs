using System.IO;
using MiniZotero.Services;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class JsonFileStoreTests
    {
        [Fact]
        public void LoadReturnsFallbackWhenFileIsMissing()
        {
            using var directory = new TemporaryDirectory();
            var store = new JsonFileStore();
            var fallback = new SampleData { Name = "fallback" };

            var result = store.Load(Path.Combine(directory.Path, "missing.json"), fallback);

            Assert.Same(fallback, result);
        }

        [Fact]
        public void LoadReturnsFallbackWhenJsonIsInvalid()
        {
            using var directory = new TemporaryDirectory();
            var path = Path.Combine(directory.Path, "data.json");
            File.WriteAllText(path, "{ invalid json");

            var store = new JsonFileStore();
            var fallback = new SampleData { Name = "fallback" };

            var result = store.Load(path, fallback);

            Assert.Same(fallback, result);
        }

        [Fact]
        public void SaveCreatesParentDirectoryAndWritesJson()
        {
            using var directory = new TemporaryDirectory();
            var path = Path.Combine(directory.Path, "nested", "data.json");
            var store = new JsonFileStore();

            store.Save(path, new SampleData { Name = "saved" });

            var result = store.Load(path, new SampleData());

            Assert.Equal("saved", result.Name);
        }

        private sealed class SampleData
        {
            public string Name { get; set; } = string.Empty;
        }
    }
}

# MiniZotero - All Code

Generated from the current workspace source files. Build output, IDE folders, node_modules, and Git internals are excluded.

## .gitattributes

``gitattributes
* text=auto

# Keep GitHub language stats focused on C#.
* linguist-vendored
*.cs linguist-vendored=false linguist-language=C#
``

## .gitignore

``gitignore
bin/
obj/
.vs/
*.user
*.suo
*.userosscache
*.sln.docstates

# Build output
[Bb]in/
[Oo]bj/

# Rider
.idea/

# Visual Studio Code
.vscode/

# Node packages used only to vendor PDF.js assets.
node_modules/
``

## AGENTS.md

``markdown
# Repository rules

- After every code change, update `ALL_CODE.md` so it reflects the current project code.

## Project Coding Style

This project must be written in a clean, simple, and maintainable C# desktop application style.

Use the following style as the main reference:

**Microsoft official .NET coding conventions + Avalonia MVVM sample style + simple service layer.**

The goal is to produce code that is easy to understand, easy to explain in an OOP course/project, and easy to extend later. Do not write overly abstract enterprise-style code unless it is truly necessary.

---

## Technology Stack

* Language: C#
* Framework: .NET 8 or newer
* UI Framework: Avalonia UI
* Architecture Pattern: MVVM
* Application Type: Desktop application

---

## General Rules

1. Follow official Microsoft C# naming conventions.
2. Keep the code readable and beginner-to-intermediate friendly.
3. Prefer simple OOP design over complex enterprise architecture.
4. Do not put all logic into `MainWindow` or code-behind files.
5. Do not write script-like code.
6. Do not over-engineer the project with unnecessary abstractions.
7. Every class should have one clear responsibility.
8. Avoid large classes that handle too many things.
9. Avoid hardcoded paths, magic numbers, and temporary demo logic.
10. Use `async`/`await` for file I/O, database I/O, PDF processing, and other long-running tasks.

---

## Folder Structure

Use a clear folder structure:

```text
Models/
ViewModels/
Views/
Services/
Repositories/
Helpers/
Assets/
```

### Models

Models should only represent data.

Rules:

* Do not put UI logic in Models.
* Do not put file system or database logic in Models.
* Keep Models simple and clean.

Example responsibility:

```text
Document
Annotation
Tag
LibraryItem
```

---

### Views

Views are responsible only for UI layout.

Rules:

* Use `.axaml` files for Avalonia UI.
* Avoid code-behind logic.
* Use data binding to connect Views with ViewModels.
* Do not access Services directly from Views.
* Do not read or write files directly in Views.
* Do not put business logic in button click handlers.

---

### ViewModels

ViewModels manage UI state and user actions.

Rules:

* ViewModels expose properties for binding.
* ViewModels expose commands for user actions.
* ViewModels may call Services.
* ViewModels should not directly access the file system, database, or PDF parser.
* ViewModels should not know about concrete Views.
* Use `ObservableCollection<T>` for lists displayed in the UI.
* Use `INotifyPropertyChanged` or CommunityToolkit.Mvvm if available.

Example responsibilities:

```text
MainWindowViewModel
LibraryViewModel
PdfWorkspaceViewModel
NotePanelViewModel
```

---

### Services

Services contain business logic.

Rules:

* Put document import logic in Services.
* Put PDF handling logic in Services.
* Put file management logic in Services.
* Put search, tagging, and library management logic in Services.
* Services should be reusable and testable.
* Services should not directly control UI elements.

Example services:

```text
IDocumentImportService
DocumentImportService

ILibraryService
LibraryService

IPdfService
PdfService

INoteService
NoteService
```

Use interfaces for important services, especially when they represent core project behavior.
Do not create interfaces for every tiny class if there is only one simple implementation and no clear benefit.

---

### Repositories

Repositories are responsible for data persistence.

Rules:

* Use Repositories for database access, JSON storage, or local file metadata storage.
* ViewModels must not directly access Repositories unless the project is very small.
* Prefer ViewModel → Service → Repository flow.

Example:

```text
IDocumentRepository
DocumentRepository
```

---

## Recommended Flow

Use this general dependency flow:

```text
View
  ↓ binding
ViewModel
  ↓ calls
Service
  ↓ uses
Repository / File System / Database / PDF Library
```

Do not reverse this dependency direction.

Bad example:

```text
View directly reads PDF files.
View directly writes to database.
Model directly updates UI.
Service directly modifies Avalonia controls.
```

Good example:

```text
View binds to ViewModel.
ViewModel calls LibraryService.
LibraryService calls DocumentRepository.
Repository saves or loads data.
```

---

## UI Rules for Avalonia

1. Write UI layout in `.axaml`.
2. Use binding instead of manually updating UI controls.
3. Use commands instead of button click logic when possible.
4. Keep code-behind minimal.
5. Use clean and modern layout.
6. Keep UI components separated when the screen becomes large.

---

## OOP Requirements

The code should clearly demonstrate OOP principles:

### Encapsulation

Keep data and behavior organized inside meaningful classes.

### Abstraction

Use interfaces for core services when useful.

### Inheritance

Use inheritance only when it makes sense. Do not force inheritance just to look object-oriented.

### Polymorphism

Use polymorphism naturally through interfaces or base classes when there are multiple implementations.

---

## Error Handling

Use simple and practical error handling.

Rules:

* Catch exceptions at the service level when appropriate.
* Do not silently ignore errors.
* Return meaningful error messages or results to the ViewModel.
* Avoid showing raw exception details directly in the UI unless debugging.

---

## Comments

Use comments only when they help explain important logic.

Good comments:

```text
// Extracts basic metadata from the selected PDF before adding it to the library.
```

Bad comments:

```text
// Set name to name
// Loop through list
```

Do not over-comment obvious code.

---

## What To Avoid

Avoid the following styles:

```text
- Putting everything in MainWindow.axaml.cs
- Mixing UI logic with file/database logic
- Huge static helper classes
- Unnecessary Clean Architecture layers
- Too many DTOs, mappers, factories, and use cases for simple features
- Hardcoded absolute paths
- Random sample data inside production classes
- Complex enterprise patterns that are hard to explain
- Code that only works as a quick demo
```

---

## Feature Implementation Rule

When implementing a new feature, follow this structure:

```text
1. Add or update Model if new data is needed.
2. Add or update Service if business logic is needed.
3. Add or update Repository if data must be saved or loaded.
4. Add or update ViewModel for UI state and commands.
5. Add or update View for visual layout and binding.
```

Do not start by putting logic directly into the View.

---

## Explanation Requirement

After writing or modifying code, always explain:

```text
1. Which files were created or changed.
2. What each class does.
3. How the View, ViewModel, Service, and Repository interact.
4. Why the design follows OOP and MVVM.
5. How to run or test the feature.
```

---

## Preferred Style Summary

Write code as if it were a clean official .NET sample:

```text
Simple.
Readable.
MVVM-based.
OOP-friendly.
Not over-engineered.
Easy to explain in a student project.
```
``

## MiniZotero.sln

``text

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.14.36518.9 d17.14
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "MiniZotero", "MiniZotero\MiniZotero.csproj", "{8C38B81B-B5CC-48CB-A61B-590819D69E6F}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "MiniZotero.Tests", "MiniZotero.Tests\MiniZotero.Tests.csproj", "{0F25A389-C06E-45B7-9736-6F8E4B1B89E8}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Release|Any CPU = Release|Any CPU
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{8C38B81B-B5CC-48CB-A61B-590819D69E6F}.Release|Any CPU.Build.0 = Release|Any CPU
		{0F25A389-C06E-45B7-9736-6F8E4B1B89E8}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{0F25A389-C06E-45B7-9736-6F8E4B1B89E8}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{0F25A389-C06E-45B7-9736-6F8E4B1B89E8}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{0F25A389-C06E-45B7-9736-6F8E4B1B89E8}.Release|Any CPU.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {57A150A0-920C-443B-A780-8D6D4F0656F7}
	EndGlobalSection
EndGlobal
``

## MiniZotero.Tests/JsonFileStoreTests.cs

``csharp
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
``

## MiniZotero.Tests/MiniZotero.Tests.csproj

``xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
    <PackageReference Include="xunit" Version="2.9.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\MiniZotero\MiniZotero.csproj" />
  </ItemGroup>
</Project>
``

## MiniZotero.Tests/RepositoryAndServiceTests.cs

``csharp
using System;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;
using Xunit;

namespace MiniZotero.Tests
{
    public sealed class RepositoryAndServiceTests
    {
        [Fact]
        public void ImportDocumentCopiesPdfAndDoesNotDuplicateExistingDocument()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new DocumentRepository(storage, new AutoTagService());
            var sourcePath = Path.Combine(directory.Path, "Class.pdf");
            File.WriteAllBytes(sourcePath, [1, 2, 3]);

            var firstDocument = repository.ImportDocument(sourcePath, []);
            var secondDocument = repository.ImportDocument(sourcePath, [firstDocument]);

            Assert.Equal(firstDocument.Id, secondDocument.Id);
            Assert.True(File.Exists(firstDocument.FilePath));
            Assert.StartsWith(storage.PdfFolderPath, firstDocument.FilePath, StringComparison.OrdinalIgnoreCase);
        }

        [Fact]
        public void HighlightRepositoryAddsDeletesSavesAndLoadsByDocumentId()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new HighlightRepository(storage);
            var firstHighlight = new HighlightItem
            {
                DocumentId = "doc-1",
                Text = "First"
            };
            var secondHighlight = new HighlightItem
            {
                DocumentId = "doc-2",
                Text = "Second"
            };

            repository.AddHighlight(firstHighlight);
            repository.AddHighlight(secondHighlight);
            repository.DeleteHighlight("doc-1", firstHighlight.Id);

            Assert.Empty(repository.LoadHighlights("doc-1"));
            Assert.Single(repository.LoadHighlights("doc-2"));
        }

        [Fact]
        public void NoteRepositorySanitizesDocumentIdAndReturnsEmptyTextForMissingNote()
        {
            using var directory = new TemporaryDirectory();
            var storage = new AppStorageService(Path.Combine(directory.Path, "app"));
            var repository = new NoteRepository(storage);

            repository.SaveNote("bad:id", "hello");

            Assert.Equal("hello", repository.LoadNote("bad:id"));
            Assert.Equal(string.Empty, repository.LoadNote("missing"));
            Assert.True(File.Exists(Path.Combine(storage.NotesFolderPath, "bad_id.md")));
        }

        [Fact]
        public void MarkdownExportOrdersHighlightsByPage()
        {
            using var directory = new TemporaryDirectory();
            var service = new MarkdownExportService();
            var document = new DocumentItem(
                "doc",
                "Document",
                "stored.pdf",
                "source.pdf",
                new DateTimeOffset(2026, 5, 28, 10, 0, 0, TimeSpan.Zero),
                lastOpenedAt: null,
                lastReadPage: 1);
            var outputPath = Path.Combine(directory.Path, "notes.md");
            var highlights = new[]
            {
                new HighlightItem { DocumentId = "doc", PageNumber = 3, Text = "Third" },
                new HighlightItem { DocumentId = "doc", PageNumber = 1, Text = "First" }
            };

            service.ExportDocumentNotes(document, "note", highlights, outputPath);

            var markdown = File.ReadAllText(outputPath);

            Assert.True(markdown.IndexOf("### Page 1", StringComparison.Ordinal) <
                        markdown.IndexOf("### Page 3", StringComparison.Ordinal));
        }

        [Fact]
        public void StorageUsageServiceCountsActiveExistingDocumentsOnly()
        {
            using var directory = new TemporaryDirectory();
            var activePath = Path.Combine(directory.Path, "active.pdf");
            var deletedPath = Path.Combine(directory.Path, "deleted.pdf");
            File.WriteAllBytes(activePath, [1, 2, 3, 4]);
            File.WriteAllBytes(deletedPath, [1, 2, 3, 4, 5]);
            var service = new StorageUsageService();
            var documents = new[]
            {
                new DocumentItem { FilePath = activePath },
                new DocumentItem { FilePath = deletedPath, IsDeleted = true },
                new DocumentItem { FilePath = Path.Combine(directory.Path, "missing.pdf") }
            };

            var bytes = service.GetLibraryUsageBytes(documents);

            Assert.Equal(4, bytes);
            Assert.Equal("4 B", service.FormatByteCount(bytes));
        }
    }
}
``

## MiniZotero.Tests/TemporaryDirectory.cs

``csharp
using System;
using System.IO;

namespace MiniZotero.Tests
{
    internal sealed class TemporaryDirectory : IDisposable
    {
        public TemporaryDirectory()
        {
            Path = System.IO.Path.Combine(
                System.IO.Path.GetTempPath(),
                $"MiniZotero.Tests.{Guid.NewGuid():N}");

            Directory.CreateDirectory(Path);
        }

        public string Path { get; }

        public void Dispose()
        {
            try
            {
                if (Directory.Exists(Path))
                {
                    Directory.Delete(Path, recursive: true);
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
``

## MiniZotero/App.axaml

``xml
<Application xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             x:Class="MiniZotero.App"
             xmlns:local="using:MiniZotero"
             RequestedThemeVariant="Default">
             <!-- "Default" ThemeVariant follows system theme variant. "Dark" or "Light" are other available options. -->

    <Application.DataTemplates>
        <local:ViewLocator/>
    </Application.DataTemplates>
  
    <Application.Styles>
        <FluentTheme />
    </Application.Styles>
</Application>
``

## MiniZotero/App.axaml.cs

``csharp
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using MiniZotero.ViewModels;
using MiniZotero.Views;

namespace MiniZotero
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}
``

## MiniZotero/app.manifest

``xml
<?xml version="1.0" encoding="utf-8"?>
<assembly manifestVersion="1.0" xmlns="urn:schemas-microsoft-com:asm.v1">
  <!-- This manifest is used on Windows only.
       Don't remove it as it might cause problems with window transparency and embedded controls.
       For more details visit https://learn.microsoft.com/en-us/windows/win32/sbscs/application-manifests -->
  <assemblyIdentity version="1.0.0.0" name="MiniZotero.Desktop"/>

  <compatibility xmlns="urn:schemas-microsoft-com:compatibility.v1">
    <application>
      <!-- A list of the Windows versions that this application has been tested on
           and is designed to work with. Uncomment the appropriate elements
           and Windows will automatically select the most compatible environment. -->

      <!-- Windows 10 -->
      <supportedOS Id="{8e0f7a12-bfb3-4fe8-b9a5-48fd50a15a9a}" />
    </application>
  </compatibility>
</assembly>
``

## MiniZotero/Assets/avalonia-logo.ico

_Skipped binary or large file. Size: 175875 bytes._

## MiniZotero/Assets/PdfJs/build/pdf.mjs

_Skipped binary or large file. Size: 817035 bytes._

## MiniZotero/Assets/PdfJs/build/pdf.worker.mjs

_Skipped binary or large file. Size: 2161149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-EUC-H.bcmap

_Skipped binary or large file. Size: 2404 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-EUC-V.bcmap

_Skipped binary or large file. Size: 173 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-H.bcmap

_Skipped binary or large file. Size: 2379 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78ms-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2651 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78ms-RKSJ-V.bcmap

_Skipped binary or large file. Size: 290 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2398 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-RKSJ-V.bcmap

_Skipped binary or large file. Size: 173 bytes._

## MiniZotero/Assets/PdfJs/cmaps/78-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/Assets/PdfJs/cmaps/83pv-RKSJ-H.bcmap

_Skipped binary or large file. Size: 905 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90msp-RKSJ-H.bcmap

_Skipped binary or large file. Size: 715 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90msp-RKSJ-V.bcmap

_Skipped binary or large file. Size: 291 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90ms-RKSJ-H.bcmap

_Skipped binary or large file. Size: 721 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90ms-RKSJ-V.bcmap

_Skipped binary or large file. Size: 290 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90pv-RKSJ-H.bcmap

_Skipped binary or large file. Size: 982 bytes._

## MiniZotero/Assets/PdfJs/cmaps/90pv-RKSJ-V.bcmap

_Skipped binary or large file. Size: 260 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-H.bcmap

_Skipped binary or large file. Size: 2419 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2413 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-RKSJ-V.bcmap

_Skipped binary or large file. Size: 287 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Add-V.bcmap

_Skipped binary or large file. Size: 282 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-0.bcmap

_Skipped binary or large file. Size: 317 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-1.bcmap

_Skipped binary or large file. Size: 371 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-2.bcmap

_Skipped binary or large file. Size: 376 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-3.bcmap

_Skipped binary or large file. Size: 401 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-4.bcmap

_Skipped binary or large file. Size: 405 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-5.bcmap

_Skipped binary or large file. Size: 406 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-6.bcmap

_Skipped binary or large file. Size: 406 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-CNS1-UCS2.bcmap

_Skipped binary or large file. Size: 41193 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-0.bcmap

_Skipped binary or large file. Size: 217 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-1.bcmap

_Skipped binary or large file. Size: 250 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-2.bcmap

_Skipped binary or large file. Size: 465 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-3.bcmap

_Skipped binary or large file. Size: 470 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-4.bcmap

_Skipped binary or large file. Size: 601 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-5.bcmap

_Skipped binary or large file. Size: 625 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-GB1-UCS2.bcmap

_Skipped binary or large file. Size: 33974 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-0.bcmap

_Skipped binary or large file. Size: 225 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-1.bcmap

_Skipped binary or large file. Size: 226 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-2.bcmap

_Skipped binary or large file. Size: 233 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-3.bcmap

_Skipped binary or large file. Size: 242 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-4.bcmap

_Skipped binary or large file. Size: 337 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-5.bcmap

_Skipped binary or large file. Size: 430 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-6.bcmap

_Skipped binary or large file. Size: 485 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Japan1-UCS2.bcmap

_Skipped binary or large file. Size: 40951 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-0.bcmap

_Skipped binary or large file. Size: 241 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-1.bcmap

_Skipped binary or large file. Size: 386 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-2.bcmap

_Skipped binary or large file. Size: 391 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Adobe-Korea1-UCS2.bcmap

_Skipped binary or large file. Size: 23293 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5-H.bcmap

_Skipped binary or large file. Size: 1086 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5pc-H.bcmap

_Skipped binary or large file. Size: 1099 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5pc-V.bcmap

_Skipped binary or large file. Size: 144 bytes._

## MiniZotero/Assets/PdfJs/cmaps/B5-V.bcmap

_Skipped binary or large file. Size: 142 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS1-H.bcmap

_Skipped binary or large file. Size: 706 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS1-V.bcmap

_Skipped binary or large file. Size: 143 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS2-H.bcmap

_Skipped binary or large file. Size: 504 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS2-V.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE�CNS2-H
``

## MiniZotero/Assets/PdfJs/cmaps/CNS-EUC-H.bcmap

_Skipped binary or large file. Size: 1780 bytes._

## MiniZotero/Assets/PdfJs/cmaps/CNS-EUC-V.bcmap

_Skipped binary or large file. Size: 1920 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETen-B5-H.bcmap

_Skipped binary or large file. Size: 1125 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETen-B5-V.bcmap

_Skipped binary or large file. Size: 158 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETenms-B5-H.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE�	ETen-B5-H` ^
``

## MiniZotero/Assets/PdfJs/cmaps/ETenms-B5-V.bcmap

_Skipped binary or large file. Size: 172 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETHK-B5-H.bcmap

_Skipped binary or large file. Size: 4426 bytes._

## MiniZotero/Assets/PdfJs/cmaps/ETHK-B5-V.bcmap

_Skipped binary or large file. Size: 158 bytes._

## MiniZotero/Assets/PdfJs/cmaps/EUC-H.bcmap

_Skipped binary or large file. Size: 578 bytes._

## MiniZotero/Assets/PdfJs/cmaps/EUC-V.bcmap

_Skipped binary or large file. Size: 170 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-H.bcmap

_Skipped binary or large file. Size: 2536 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-RKSJ-H.bcmap

_Skipped binary or large file. Size: 2542 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-RKSJ-V.bcmap

_Skipped binary or large file. Size: 218 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Ext-V.bcmap

_Skipped binary or large file. Size: 215 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-EUC-H.bcmap

_Skipped binary or large file. Size: 549 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-EUC-V.bcmap

_Skipped binary or large file. Size: 179 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-H.bcmap

``text
�RCopyright 1990-2009 Adobe Systems Incorporated.
All rights reserved.
See ./LICENSE!!��]aX!!]`�21�>	�p�z�$]��"R�d�-U�7�*�4�%�+ �Z �{�/�%�<�9K�b�1]�.�"��`]�,�"]�
�"]�h�"]�F�"]�$�"]��"]�`�"]�>�"]��"]�z�"]�X�"]�6�"]��"]�r�"]�P�"]�.�"]��"]�j�"]�H�"]�&�"]��"]�b�"]�@�"]��"]�|�"]�Z�"]�8�"]��"]�t�"]�R�"]�0�"]��"]�l�"]�J�"]�(�"]��"]�d�"]�B�"]� �"X�~�']�W�"]�5�"]��"]�q�"]�O�"]�-�"]��"]�i�"]�G�"]�%�"]��"]�a�"]�?�"]��"]�{�"]�Y�"]�7�"]��"]�s�"]�Q�"]�/�"]��"]�k�"]�I�"]�'�"]��"]�c�"]�A�"]��"]�}�"]�[�"]�9
``

## MiniZotero/Assets/PdfJs/cmaps/GBK2K-H.bcmap

_Skipped binary or large file. Size: 19662 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBK2K-V.bcmap

_Skipped binary or large file. Size: 219 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBK-EUC-H.bcmap

_Skipped binary or large file. Size: 14692 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBK-EUC-V.bcmap

_Skipped binary or large file. Size: 180 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBKp-EUC-H.bcmap

_Skipped binary or large file. Size: 14686 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBKp-EUC-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBpc-EUC-H.bcmap

_Skipped binary or large file. Size: 557 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBpc-EUC-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-EUC-H.bcmap

_Skipped binary or large file. Size: 7290 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-EUC-V.bcmap

_Skipped binary or large file. Size: 180 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-H.bcmap

_Skipped binary or large file. Size: 7269 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBTpc-EUC-H.bcmap

_Skipped binary or large file. Size: 7298 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBTpc-EUC-V.bcmap

_Skipped binary or large file. Size: 182 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GBT-V.bcmap

_Skipped binary or large file. Size: 176 bytes._

## MiniZotero/Assets/PdfJs/cmaps/GB-V.bcmap

_Skipped binary or large file. Size: 175 bytes._

## MiniZotero/Assets/PdfJs/cmaps/H.bcmap

_Skipped binary or large file. Size: 553 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Hankaku.bcmap

_Skipped binary or large file. Size: 132 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Hiragana.bcmap

_Skipped binary or large file. Size: 124 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdla-B5-H.bcmap

_Skipped binary or large file. Size: 2654 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdla-B5-V.bcmap

_Skipped binary or large file. Size: 148 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdlb-B5-H.bcmap

_Skipped binary or large file. Size: 2414 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKdlb-B5-V.bcmap

_Skipped binary or large file. Size: 148 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKgccs-B5-H.bcmap

_Skipped binary or large file. Size: 2292 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKgccs-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm314-B5-H.bcmap

_Skipped binary or large file. Size: 1772 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm314-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm471-B5-H.bcmap

_Skipped binary or large file. Size: 2171 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKm471-B5-V.bcmap

_Skipped binary or large file. Size: 149 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKscs-B5-H.bcmap

_Skipped binary or large file. Size: 4437 bytes._

## MiniZotero/Assets/PdfJs/cmaps/HKscs-B5-V.bcmap

_Skipped binary or large file. Size: 159 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Katakana.bcmap

_Skipped binary or large file. Size: 100 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-EUC-H.bcmap

_Skipped binary or large file. Size: 1848 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-EUC-V.bcmap

_Skipped binary or large file. Size: 164 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-H.bcmap

_Skipped binary or large file. Size: 1831 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-Johab-H.bcmap

_Skipped binary or large file. Size: 16791 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-Johab-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-H.bcmap

_Skipped binary or large file. Size: 2787 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-HW-H.bcmap

_Skipped binary or large file. Size: 2789 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-HW-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCms-UHC-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCpc-EUC-H.bcmap

_Skipped binary or large file. Size: 2024 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSCpc-EUC-V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/KSC-V.bcmap

_Skipped binary or large file. Size: 160 bytes._

## MiniZotero/Assets/PdfJs/cmaps/LICENSE

``text
%%Copyright: -----------------------------------------------------------
%%Copyright: Copyright 1990-2009 Adobe Systems Incorporated.
%%Copyright: All rights reserved.
%%Copyright:
%%Copyright: Redistribution and use in source and binary forms, with or
%%Copyright: without modification, are permitted provided that the
%%Copyright: following conditions are met:
%%Copyright:
%%Copyright: Redistributions of source code must retain the above
%%Copyright: copyright notice, this list of conditions and the following
%%Copyright: disclaimer.
%%Copyright:
%%Copyright: Redistributions in binary form must reproduce the above
%%Copyright: copyright notice, this list of conditions and the following
%%Copyright: disclaimer in the documentation and/or other materials
%%Copyright: provided with the distribution. 
%%Copyright:
%%Copyright: Neither the name of Adobe Systems Incorporated nor the names
%%Copyright: of its contributors may be used to endorse or promote
%%Copyright: products derived from this software without specific prior
%%Copyright: written permission. 
%%Copyright:
%%Copyright: THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
%%Copyright: CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
%%Copyright: INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF
%%Copyright: MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
%%Copyright: DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR
%%Copyright: CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
%%Copyright: SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
%%Copyright: NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
%%Copyright: LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
%%Copyright: HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN
%%Copyright: CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR
%%Copyright: OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
%%Copyright: SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
%%Copyright: -----------------------------------------------------------
``

## MiniZotero/Assets/PdfJs/cmaps/NWP-H.bcmap

_Skipped binary or large file. Size: 2765 bytes._

## MiniZotero/Assets/PdfJs/cmaps/NWP-V.bcmap

_Skipped binary or large file. Size: 252 bytes._

## MiniZotero/Assets/PdfJs/cmaps/RKSJ-H.bcmap

_Skipped binary or large file. Size: 534 bytes._

## MiniZotero/Assets/PdfJs/cmaps/RKSJ-V.bcmap

_Skipped binary or large file. Size: 170 bytes._

## MiniZotero/Assets/PdfJs/cmaps/Roman.bcmap

_Skipped binary or large file. Size: 96 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UCS2-H.bcmap

_Skipped binary or large file. Size: 48280 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UCS2-V.bcmap

_Skipped binary or large file. Size: 156 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF16-H.bcmap

_Skipped binary or large file. Size: 50419 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF16-V.bcmap

_Skipped binary or large file. Size: 156 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF32-H.bcmap

_Skipped binary or large file. Size: 52679 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF32-V.bcmap

_Skipped binary or large file. Size: 160 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF8-H.bcmap

_Skipped binary or large file. Size: 53629 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniCNS-UTF8-V.bcmap

_Skipped binary or large file. Size: 157 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UCS2-H.bcmap

_Skipped binary or large file. Size: 43366 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UCS2-V.bcmap

_Skipped binary or large file. Size: 193 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF16-H.bcmap

_Skipped binary or large file. Size: 44086 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF16-V.bcmap

_Skipped binary or large file. Size: 178 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF32-H.bcmap

_Skipped binary or large file. Size: 45738 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF32-V.bcmap

_Skipped binary or large file. Size: 182 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF8-H.bcmap

_Skipped binary or large file. Size: 46837 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniGB-UTF8-V.bcmap

_Skipped binary or large file. Size: 181 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF16-H.bcmap

_Skipped binary or large file. Size: 39534 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF16-V.bcmap

_Skipped binary or large file. Size: 647 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF32-H.bcmap

_Skipped binary or large file. Size: 40630 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF32-V.bcmap

_Skipped binary or large file. Size: 681 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF8-H.bcmap

_Skipped binary or large file. Size: 41779 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS2004-UTF8-V.bcmap

_Skipped binary or large file. Size: 682 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISPro-UCS2-HW-V.bcmap

_Skipped binary or large file. Size: 705 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISPro-UCS2-V.bcmap

_Skipped binary or large file. Size: 689 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISPro-UTF8-V.bcmap

_Skipped binary or large file. Size: 726 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-H.bcmap

_Skipped binary or large file. Size: 25439 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-HW-H.bcmap

_Skipped binary or large file. Size: 119 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-HW-V.bcmap

_Skipped binary or large file. Size: 680 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UCS2-V.bcmap

_Skipped binary or large file. Size: 664 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF16-H.bcmap

_Skipped binary or large file. Size: 39443 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF16-V.bcmap

_Skipped binary or large file. Size: 643 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF32-H.bcmap

_Skipped binary or large file. Size: 40539 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF32-V.bcmap

_Skipped binary or large file. Size: 677 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF8-H.bcmap

_Skipped binary or large file. Size: 41695 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJIS-UTF8-V.bcmap

_Skipped binary or large file. Size: 678 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX02132004-UTF32-H.bcmap

_Skipped binary or large file. Size: 40608 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX02132004-UTF32-V.bcmap

_Skipped binary or large file. Size: 688 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX0213-UTF32-H.bcmap

_Skipped binary or large file. Size: 40517 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniJISX0213-UTF32-V.bcmap

_Skipped binary or large file. Size: 684 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UCS2-H.bcmap

_Skipped binary or large file. Size: 25783 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UCS2-V.bcmap

_Skipped binary or large file. Size: 178 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF16-H.bcmap

_Skipped binary or large file. Size: 26327 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF16-V.bcmap

_Skipped binary or large file. Size: 164 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF32-H.bcmap

_Skipped binary or large file. Size: 26451 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF32-V.bcmap

_Skipped binary or large file. Size: 168 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF8-H.bcmap

_Skipped binary or large file. Size: 27790 bytes._

## MiniZotero/Assets/PdfJs/cmaps/UniKS-UTF8-V.bcmap

_Skipped binary or large file. Size: 169 bytes._

## MiniZotero/Assets/PdfJs/cmaps/V.bcmap

_Skipped binary or large file. Size: 166 bytes._

## MiniZotero/Assets/PdfJs/cmaps/WP-Symbol.bcmap

_Skipped binary or large file. Size: 179 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitDingbats.pfb

_Skipped binary or large file. Size: 29513 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixed.pfb

_Skipped binary or large file. Size: 17597 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixedBold.pfb

_Skipped binary or large file. Size: 18055 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixedBoldItalic.pfb

_Skipped binary or large file. Size: 19151 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitFixedItalic.pfb

_Skipped binary or large file. Size: 18746 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerif.pfb

_Skipped binary or large file. Size: 19469 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerifBold.pfb

_Skipped binary or large file. Size: 19395 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerifBoldItalic.pfb

_Skipped binary or large file. Size: 20733 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSerifItalic.pfb

_Skipped binary or large file. Size: 21227 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/FoxitSymbol.pfb

_Skipped binary or large file. Size: 16729 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-Bold.ttf

_Skipped binary or large file. Size: 137052 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-BoldItalic.ttf

_Skipped binary or large file. Size: 135124 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-Italic.ttf

_Skipped binary or large file. Size: 162036 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LiberationSans-Regular.ttf

_Skipped binary or large file. Size: 139512 bytes._

## MiniZotero/Assets/PdfJs/standard_fonts/LICENSE_FOXIT

``text
// Copyright 2014 PDFium Authors. All rights reserved.
//
// Redistribution and use in source and binary forms, with or without
// modification, are permitted provided that the following conditions are
// met:
//
//    * Redistributions of source code must retain the above copyright
// notice, this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above
// copyright notice, this list of conditions and the following disclaimer
// in the documentation and/or other materials provided with the
// distribution.
//    * Neither the name of Google Inc. nor the names of its
// contributors may be used to endorse or promote products derived from
// this software without specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
// "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT
// LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR
// A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT
// OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
// SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
// LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
// DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
// THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
// (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
// OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
``

## MiniZotero/Assets/PdfJs/standard_fonts/LICENSE_LIBERATION

``text
Digitized data copyright (c) 2010 Google Corporation
	with Reserved Font Arimo, Tinos and Cousine.
Copyright (c) 2012 Red Hat, Inc.
	with Reserved Font Name Liberation.

This Font Software is licensed under the SIL Open Font License,
Version 1.1.

This license is copied below, and is also available with a FAQ at:
http://scripts.sil.org/OFL

SIL OPEN FONT LICENSE Version 1.1 - 26 February 2007

PREAMBLE The goals of the Open Font License (OFL) are to stimulate
worldwide development of collaborative font projects, to support the font
creation efforts of academic and linguistic communities, and to provide
a free and open framework in which fonts may be shared and improved in
partnership with others.

The OFL allows the licensed fonts to be used, studied, modified and
redistributed freely as long as they are not sold by themselves.
The fonts, including any derivative works, can be bundled, embedded,
redistributed and/or sold with any software provided that any reserved
names are not used by derivative works.  The fonts and derivatives,
however, cannot be released under any other type of license.  The
requirement for fonts to remain under this license does not apply to
any document created using the fonts or their derivatives.

 

DEFINITIONS
"Font Software" refers to the set of files released by the Copyright
Holder(s) under this license and clearly marked as such.
This may include source files, build scripts and documentation.

"Reserved Font Name" refers to any names specified as such after the
copyright statement(s).

"Original Version" refers to the collection of Font Software components
as distributed by the Copyright Holder(s).

"Modified Version" refers to any derivative made by adding to, deleting,
or substituting ? in part or in whole ?
any of the components of the Original Version, by changing formats or
by porting the Font Software to a new environment.

"Author" refers to any designer, engineer, programmer, technical writer
or other person who contributed to the Font Software.


PERMISSION & CONDITIONS

Permission is hereby granted, free of charge, to any person obtaining a
copy of the Font Software, to use, study, copy, merge, embed, modify,
redistribute, and sell modified and unmodified copies of the Font
Software, subject to the following conditions:

1) Neither the Font Software nor any of its individual components,in
   Original or Modified Versions, may be sold by itself.

2) Original or Modified Versions of the Font Software may be bundled,
   redistributed and/or sold with any software, provided that each copy
   contains the above copyright notice and this license. These can be
   included either as stand-alone text files, human-readable headers or
   in the appropriate machine-readable metadata fields within text or
   binary files as long as those fields can be easily viewed by the user.

3) No Modified Version of the Font Software may use the Reserved Font
   Name(s) unless explicit written permission is granted by the
   corresponding Copyright Holder. This restriction only applies to the
   primary font name as presented to the users.

4) The name(s) of the Copyright Holder(s) or the Author(s) of the Font
   Software shall not be used to promote, endorse or advertise any
   Modified Version, except to acknowledge the contribution(s) of the
   Copyright Holder(s) and the Author(s) or with their explicit written
   permission.

5) The Font Software, modified or unmodified, in part or in whole, must
   be distributed entirely under this license, and must not be distributed
   under any other license. The requirement for fonts to remain under
   this license does not apply to any document created using the Font
   Software.


 
TERMINATION
This license becomes null and void if any of the above conditions are not met.

 

DISCLAIMER
THE FONT SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO ANY WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT
OF COPYRIGHT, PATENT, TRADEMARK, OR OTHER RIGHT.  IN NO EVENT SHALL THE
COPYRIGHT HOLDER BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
INCLUDING ANY GENERAL, SPECIAL, INDIRECT, INCIDENTAL, OR CONSEQUENTIAL
DAMAGES, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF THE USE OR INABILITY TO USE THE FONT SOFTWARE OR FROM OTHER
DEALINGS IN THE FONT SOFTWARE.
``

## MiniZotero/Assets/PdfViewer/index.html

``html
<!doctype html>
<html lang="en">
<head>
    <meta charset="utf-8" />
    <title>MiniZotero PDF Viewer</title>
    <link rel="stylesheet" href="style.css" />
</head>
<body>
    <div id="app">
        <div id="status">Loading PDF...</div>
        <div id="viewer"></div>
    </div>

    <script type="module" src="viewer.js"></script>
</body>
</html>
``

## MiniZotero/Assets/PdfViewer/style.css

``css
html,
body {
    margin: 0;
    padding: 0;
    height: 100%;
    background: #e8ecf2;
    font-family: Segoe UI, Arial, sans-serif;
    overflow: hidden;
    user-select: text;
    -webkit-user-select: text;
}

#app {
    height: 100%;
    display: flex;
    flex-direction: column;
}

#status {
    display: none;
}

#viewer {
    position: relative;
    flex: 1;
    overflow: auto;
    padding: 24px 0;
    box-sizing: border-box;
    user-select: none;
    -webkit-user-select: none;
}

#viewer.toolSelect {
    cursor: text;
}

#viewer.toolHighlight {
    cursor: text;
}

#viewer.toolHand {
    cursor: grab;
}

#viewer.toolHand.panning {
    cursor: grabbing;
}

#viewer.viewerLiveZoom .textLayer,
.viewerLiveZoom .textLayer {
    pointer-events: none;
    user-select: none;
}

.page {
    position: relative;
    display: block;
    margin: 0 auto 22px auto;
    background: transparent;
}

.pageContent {
    position: absolute;
    top: 0;
    left: 0;
    background: white;
    overflow: hidden;
    transform-origin: 0 0;
    box-shadow: 0 4px 18px rgba(0, 0, 0, 0.18);
    user-select: text;
    -webkit-user-select: text;
}

.canvasLayer {
    position: absolute;
    left: 0;
    top: 0;
    display: block;
    image-rendering: auto;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
    z-index: 0;
}

.textLayer {
    position: absolute;
    inset: 0;
    overflow: hidden;
    opacity: 1;
    line-height: 1;
    text-align: initial;
    transform-origin: 0 0;
    forced-color-adjust: none;
    z-index: 2;
    cursor: text;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
}

.textLayer span,
.textLayer br {
    position: absolute;
    color: transparent;
    white-space: pre;
    cursor: text;
    transform-origin: 0% 0%;
    pointer-events: none;
    user-select: none;
    -webkit-user-select: none;
}

.textLayer ::selection,
.textLayer span::selection {
    background: transparent !important;
}

.textLayer .markedContent {
    display: contents;
}

.textLayer .endOfContent {
    display: block;
    position: absolute;
    inset: 100% 0 0;
    z-index: 0;
    cursor: default;
    user-select: none;
}

.highlightLayer {
    position: absolute;
    left: 0;
    top: 0;
    pointer-events: none;
    z-index: 1;
}

.highlightLayer .highlightItem {
    position: absolute;
    background: rgba(250, 204, 21, 0.34);
    border-radius: 2px;
    pointer-events: none;
}

.highlightLayer .highlightItem:hover {
    background: rgba(250, 204, 21, 0.52);
}

.highlightLayer.isInteractive {
    z-index: 3;
    pointer-events: auto;
}

.highlightLayer.isInteractive .highlightItem {
    cursor: pointer;
    pointer-events: auto;
}

.selectionOverlay {
    position: absolute;
    inset: 0;
    pointer-events: none;
    z-index: 3;
}

.selectionOverlayRect {
    position: absolute;
    background: rgba(245, 158, 11, 0.28);
    border-radius: 2px;
    pointer-events: none;
}

.selectionDragBox {
    position: absolute;
    border: 1px solid rgba(59, 130, 246, 0.7);
    background: rgba(59, 130, 246, 0.08);
    border-radius: 3px;
    pointer-events: none;
    z-index: 10;
}

.error {
    margin: 40px auto;
    max-width: 520px;
    background: white;
    color: #b91c1c;
    border: 1px solid #fecaca;
    border-radius: 8px;
    padding: 16px;
    font-size: 13px;
}
``

## MiniZotero/Assets/PdfViewer/viewer.js

``javascript
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
``

## MiniZotero/Converters/StarredBrushConverter.cs

``csharp
using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace MiniZotero.Converters
{
    public sealed class StarredBrushConverter : IValueConverter
    {
        private static readonly IBrush StarredBrush = new SolidColorBrush(Color.Parse("#FACC15"));
        private static readonly IBrush DefaultBrush = new SolidColorBrush(Color.Parse("#AAB6C6"));

        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return value is true ? StarredBrush : DefaultBrush;
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
``

## MiniZotero/MiniZotero.csproj

``xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <Nullable>enable</Nullable>
    <ApplicationManifest>app.manifest</ApplicationManifest>
    <AvaloniaUseCompiledBindingsByDefault>true</AvaloniaUseCompiledBindingsByDefault>
  </PropertyGroup>

  <ItemGroup>
    <Folder Include="Models\" />
    <AvaloniaResource Include="Assets\**" />
  </ItemGroup>

  <ItemGroup>
    <Content Include="Assets\PdfJs\**\*.*" CopyToOutputDirectory="PreserveNewest" />
    <Content Include="Assets\PdfViewer\**\*.*" CopyToOutputDirectory="PreserveNewest" />
  </ItemGroup>

  <ItemGroup>
    <PackageReference Include="Avalonia" Version="12.0.3" />
    <PackageReference Include="Avalonia.Controls.WebView" Version="12.0.1" />
    <PackageReference Include="Avalonia.Desktop" Version="12.0.3" />
    <PackageReference Include="Avalonia.Themes.Fluent" Version="12.0.3" />
    <PackageReference Include="Avalonia.Fonts.Inter" Version="12.0.3" />
    <PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.1" />
  </ItemGroup>
</Project>
``

## MiniZotero/Models/AppSettings.cs

``csharp
namespace MiniZotero.Models
{
    public sealed class AppSettings
    {
        public string? WatchFolderPath { get; set; }
    }
}
``

## MiniZotero/Models/DocumentItem.cs

``csharp
using System;
using System.Collections.Generic;

namespace MiniZotero.Models
{
    public sealed class DocumentItem
    {
        public DocumentItem()
        {
        }

        public DocumentItem(
            string id,
            string title,
            string filePath,
            string originalFilePath,
            DateTimeOffset addedAt,
            DateTimeOffset? lastOpenedAt,
            int lastReadPage,
            int lastZoomPercent = 120,
            bool isStarred = false)
        {
            Id = id;
            Title = title;
            FilePath = filePath;
            OriginalFilePath = originalFilePath;
            AddedAt = addedAt;
            LastOpenedAt = lastOpenedAt;
            LastReadPage = lastReadPage;
            LastZoomPercent = lastZoomPercent;
            IsStarred = isStarred;
        }

        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string OriginalFilePath { get; set; } = string.Empty;

        public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? LastOpenedAt { get; set; }

        public int LastReadPage { get; set; } = 1;

        public int LastZoomPercent { get; set; } = 120;

        public bool IsStarred { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset? DeletedAt { get; set; }

        public List<string> Tags { get; set; } = [];
    }
}
``

## MiniZotero/Models/HighlightItem.cs

``csharp
using System;
using System.Collections.Generic;

namespace MiniZotero.Models
{
    public sealed class HighlightItem
    {
        public string Id { get; set; } = Guid.NewGuid().ToString("N");

        public string DocumentId { get; set; } = string.Empty;

        public int PageNumber { get; set; } = 1;

        public string Text { get; set; } = string.Empty;

        public string Color { get; set; } = "yellow";

        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;

        public List<HighlightRect> Rects { get; set; } = [];
    }
}
``

## MiniZotero/Models/HighlightRect.cs

``csharp
namespace MiniZotero.Models
{
    public sealed class HighlightRect
    {
        public int PageNumber { get; set; }

        public double Left { get; set; }

        public double Top { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
    }
}
``

## MiniZotero/Program.cs

``csharp
using System;
using Avalonia;

namespace MiniZotero
{
    internal sealed class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args) => BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);

        // Avalonia configuration, don't remove; also used by visual designer.
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
    }
}
``

## MiniZotero/Repositories/AppSettingsRepository.cs

``csharp
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class AppSettingsRepository
    {
        private readonly AppStorageService _storageService;
        private readonly JsonFileStore _jsonFileStore;

        public AppSettingsRepository(AppStorageService storageService)
            : this(storageService, new JsonFileStore())
        {
        }

        public AppSettingsRepository(
            AppStorageService storageService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _jsonFileStore = jsonFileStore;
        }

        public AppSettings LoadSettings()
        {
            return _jsonFileStore.Load(_storageService.SettingsFilePath, new AppSettings());
        }

        public void SaveSettings(AppSettings settings)
        {
            _jsonFileStore.Save(_storageService.SettingsFilePath, settings);
        }
    }
}
``

## MiniZotero/Repositories/DocumentRepository.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class DocumentRepository
    {
        private readonly AppStorageService _storageService;
        private readonly AutoTagService _autoTagService;
        private readonly JsonFileStore _jsonFileStore;

        public DocumentRepository(AppStorageService storageService)
            : this(storageService, new AutoTagService())
        {
        }

        public DocumentRepository(
            AppStorageService storageService,
            AutoTagService autoTagService)
            : this(storageService, autoTagService, new JsonFileStore())
        {
        }

        public DocumentRepository(
            AppStorageService storageService,
            AutoTagService autoTagService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _autoTagService = autoTagService;
            _jsonFileStore = jsonFileStore;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            var documents = _jsonFileStore
                .Load(_storageService.LibraryFilePath, new List<DocumentItem>());
            var changed = NormalizeDocuments(documents);
            changed |= MigrateDocumentsToStorage(documents);
            changed |= ApplyMissingAutoTags(documents);

            if (changed)
            {
                SaveDocuments(documents);
            }

            return documents;
        }

        public DocumentItem ImportDocument(string sourceFilePath, IEnumerable<DocumentItem> existingDocuments)
        {
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException("The selected PDF file does not exist.", sourceFilePath);
            }

            var normalizedSourcePath = Path.GetFullPath(sourceFilePath);
            var existingDocument = existingDocuments.FirstOrDefault(document =>
                IsSamePath(document.OriginalFilePath, normalizedSourcePath) ||
                IsSamePath(document.FilePath, normalizedSourcePath));

            if (existingDocument is not null)
            {
                ApplyAutoTags(existingDocument, normalizedSourcePath);
                return existingDocument;
            }

            var documentId = Guid.NewGuid().ToString("N");
            var destinationPath = Path.Combine(_storageService.PdfFolderPath, $"{documentId}.pdf");
            File.Copy(normalizedSourcePath, destinationPath, overwrite: false);

            var document = new DocumentItem(
                documentId,
                Path.GetFileNameWithoutExtension(normalizedSourcePath),
                destinationPath,
                normalizedSourcePath,
                DateTimeOffset.Now,
                lastOpenedAt: null,
                lastReadPage: 1);

            ApplyAutoTags(document, normalizedSourcePath);

            return document;
        }

        public DocumentItem AddDocument(string filePath)
        {
            var documents = LoadDocuments().ToList();
            var document = ImportDocument(filePath, documents);

            if (!documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                documents.Add(document);
            }

            SaveDocuments(documents);

            return document;
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            _jsonFileStore.Save(_storageService.LibraryFilePath, documents);
        }

        public void DeleteStoredPdfFile(DocumentItem document)
        {
            if (string.IsNullOrWhiteSpace(document.FilePath))
            {
                return;
            }

            try
            {
                if (File.Exists(document.FilePath) && IsStoredPdfPath(document.FilePath))
                {
                    File.Delete(document.FilePath);
                }
            }
            catch (IOException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
        }

        private static bool IsSamePath(string? left, string right)
        {
            if (string.IsNullOrWhiteSpace(left))
            {
                return false;
            }

            return string.Equals(Path.GetFullPath(left), right, StringComparison.OrdinalIgnoreCase);
        }

        private bool MigrateDocumentsToStorage(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                if (string.IsNullOrWhiteSpace(document.FilePath) ||
                    IsStoredPdfPath(document.FilePath) ||
                    !File.Exists(document.FilePath))
                {
                    continue;
                }

                if (string.IsNullOrWhiteSpace(document.OriginalFilePath))
                {
                    document.OriginalFilePath = document.FilePath;
                }

                var destinationPath = Path.Combine(_storageService.PdfFolderPath, $"{document.Id}.pdf");
                if (!File.Exists(destinationPath))
                {
                    File.Copy(document.FilePath, destinationPath, overwrite: false);
                }

                document.FilePath = destinationPath;
                changed = true;
            }

            return changed;
        }

        private bool IsStoredPdfPath(string filePath)
        {
            var normalizedFilePath = Path.GetFullPath(filePath);
            var normalizedPdfFolderPath = Path.GetFullPath(_storageService.PdfFolderPath);

            return normalizedFilePath.StartsWith(
                normalizedPdfFolderPath,
                StringComparison.OrdinalIgnoreCase);
        }

        private bool ApplyMissingAutoTags(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                var sourcePath = !string.IsNullOrWhiteSpace(document.OriginalFilePath)
                    ? document.OriginalFilePath
                    : document.FilePath;

                if (string.IsNullOrWhiteSpace(sourcePath))
                {
                    continue;
                }

                changed |= ApplyAutoTags(document, sourcePath);
            }

            return changed;
        }

        private bool ApplyAutoTags(DocumentItem document, string sourceFilePath)
        {
            document.Tags ??= [];
            var changed = false;

            foreach (var tag in _autoTagService.GenerateTags(sourceFilePath, document.Title))
            {
                var exists = document.Tags.Any(existingTag =>
                    string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

                if (exists)
                {
                    continue;
                }

                document.Tags.Add(tag);
                changed = true;
            }

            return changed;
        }

        private static bool NormalizeDocuments(IEnumerable<DocumentItem> documents)
        {
            var changed = false;

            foreach (var document in documents)
            {
                if (string.IsNullOrWhiteSpace(document.Id))
                {
                    document.Id = Guid.NewGuid().ToString("N");
                    changed = true;
                }

                if (string.IsNullOrWhiteSpace(document.OriginalFilePath))
                {
                    document.OriginalFilePath = document.FilePath;
                    changed = true;
                }

                if (string.IsNullOrWhiteSpace(document.Title) &&
                    !string.IsNullOrWhiteSpace(document.FilePath))
                {
                    document.Title = Path.GetFileNameWithoutExtension(document.FilePath);
                    changed = true;
                }

                if (document.LastReadPage < 1)
                {
                    document.LastReadPage = 1;
                    changed = true;
                }

                if (document.LastZoomPercent < 50 || document.LastZoomPercent > 400)
                {
                    document.LastZoomPercent = 120;
                    changed = true;
                }

                if (document.Tags is null)
                {
                    document.Tags = [];
                    changed = true;
                }

                if (!document.IsDeleted && document.DeletedAt is not null)
                {
                    document.DeletedAt = null;
                    changed = true;
                }

                if (document.IsDeleted && document.DeletedAt is null)
                {
                    document.DeletedAt = DateTimeOffset.Now;
                    changed = true;
                }
            }

            return changed;
        }
    }
}
``

## MiniZotero/Repositories/HighlightRepository.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class HighlightRepository
    {
        private readonly AppStorageService _storageService;
        private readonly JsonFileStore _jsonFileStore;

        public HighlightRepository(AppStorageService storageService)
            : this(storageService, new JsonFileStore())
        {
        }

        public HighlightRepository(
            AppStorageService storageService,
            JsonFileStore jsonFileStore)
        {
            _storageService = storageService;
            _jsonFileStore = jsonFileStore;
        }

        public IReadOnlyList<HighlightItem> LoadHighlights(string documentId)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return [];
            }

            return _jsonFileStore.Load(GetHighlightFilePath(documentId), new List<HighlightItem>());
        }

        public HighlightItem AddHighlight(HighlightItem highlight)
        {
            if (string.IsNullOrWhiteSpace(highlight.DocumentId))
            {
                throw new InvalidOperationException("Highlight must have a document id.");
            }

            if (string.IsNullOrWhiteSpace(highlight.Id))
            {
                highlight.Id = Guid.NewGuid().ToString("N");
            }

            if (highlight.CreatedAt == default)
            {
                highlight.CreatedAt = DateTimeOffset.Now;
            }

            var highlights = LoadHighlights(highlight.DocumentId).ToList();
            highlights.Add(highlight);

            SaveHighlights(highlight.DocumentId, highlights);

            return highlight;
        }

        public void DeleteHighlight(string documentId, string highlightId)
        {
            if (string.IsNullOrWhiteSpace(documentId) ||
                string.IsNullOrWhiteSpace(highlightId))
            {
                return;
            }

            var highlights = LoadHighlights(documentId).ToList();
            highlights.RemoveAll(highlight => highlight.Id == highlightId);

            SaveHighlights(documentId, highlights);
        }

        public void SaveHighlights(string documentId, IEnumerable<HighlightItem> highlights)
        {
            if (string.IsNullOrWhiteSpace(documentId))
            {
                return;
            }

            var path = GetHighlightFilePath(documentId);
            _jsonFileStore.Save(path, highlights);
        }

        private string GetHighlightFilePath(string documentId)
        {
            return Path.Combine(_storageService.HighlightsFolderPath, $"{documentId}.json");
        }
    }
}
``

## MiniZotero/Repositories/NoteRepository.cs

``csharp
using System.IO;
using System.Linq;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class NoteRepository
    {
        private readonly AppStorageService _storageService;

        public NoteRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public string LoadNote(string documentId)
        {
            var notePath = GetNotePath(documentId);

            return File.Exists(notePath)
                ? File.ReadAllText(notePath)
                : string.Empty;
        }

        public void SaveNote(string documentId, string text)
        {
            var notePath = GetNotePath(documentId);
            File.WriteAllText(notePath, text);
        }

        private string GetNotePath(string documentId)
        {
            var safeDocumentId = string.Concat(
                documentId.Select(character =>
                    Path.GetInvalidFileNameChars().Contains(character) ? '_' : character));

            if (string.IsNullOrWhiteSpace(safeDocumentId))
            {
                safeDocumentId = "untitled";
            }

            return Path.Combine(_storageService.NotesFolderPath, $"{safeDocumentId}.md");
        }
    }
}
``

## MiniZotero/Services/AppStorageService.cs

``csharp
using System;
using System.IO;

namespace MiniZotero.Services
{
    public sealed class AppStorageService
    {
        private const string AppFolderName = "MiniZotero";
        private const string LibraryFileName = "library.json";
        private const string SettingsFileName = "settings.json";
        private const string PdfFolderName = "pdfs";
        private const string NotesFolderName = "notes";
        private const string HighlightsFolderName = "highlights";

        public AppStorageService()
            : this(Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                AppFolderName))
        {
        }

        public AppStorageService(string rootPath)
        {
            RootPath = rootPath;

            Directory.CreateDirectory(RootPath);
            Directory.CreateDirectory(PdfFolderPath);
            Directory.CreateDirectory(NotesFolderPath);
            Directory.CreateDirectory(HighlightsFolderPath);
        }

        public string RootPath { get; }

        public string AppDataPath => RootPath;

        public string PdfFolderPath => Path.Combine(RootPath, PdfFolderName);

        public string NotesFolderPath => Path.Combine(RootPath, NotesFolderName);

        public string HighlightsFolderPath => Path.Combine(RootPath, HighlightsFolderName);

        public string LibraryFilePath => Path.Combine(RootPath, LibraryFileName);

        public string SettingsFilePath => Path.Combine(RootPath, SettingsFileName);
    }
}
``

## MiniZotero/Services/AutoTagService.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MiniZotero.Services
{
    public sealed class AutoTagService
    {
        private static readonly Dictionary<string, string[]> Rules = new(StringComparer.OrdinalIgnoreCase)
        {
            ["C#"] = ["csharp", "c#", ".net", "dotnet", "avalonia", "wpf", "oop", "class", "inheritance"],
            ["CMOS"] = ["cmos", "mosfet", "inverter", "spice", "cadence", "opamp"],
            ["Embedded"] = ["stm32", "esp32", "arduino", "uart", "adc", "pwm", "freertos"],
            ["Datasheet"] = ["datasheet", "specification", "max30102", "mpu6050"],
            ["Paper"] = ["abstract", "ieee", "references", "journal", "conference"],
            ["Circuit"] = ["schematic", "pcb", "altium", "ltspice", "simulation"]
        };

        public IReadOnlyList<string> GenerateTags(string filePath, string title)
        {
            var folderName = Path.GetDirectoryName(filePath) is { } folderPath
                ? Path.GetFileName(folderPath)
                : string.Empty;

            var source = $"{filePath} {folderName} {title}".ToLowerInvariant();
            var tags = new List<string>();

            foreach (var rule in Rules)
            {
                if (rule.Value.Any(keyword => source.Contains(keyword.ToLowerInvariant())))
                {
                    tags.Add(rule.Key);
                }
            }

            return tags
                .Distinct(StringComparer.OrdinalIgnoreCase)
                .ToList();
        }
    }
}
``

## MiniZotero/Services/JsonFileStore.cs

``csharp
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
``

## MiniZotero/Services/MarkdownExportService.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class MarkdownExportService
    {
        public void ExportDocumentNotes(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights,
            string outputPath)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return;
            }

            var markdown = BuildMarkdown(document, noteText, highlights);
            File.WriteAllText(outputPath, markdown, Encoding.UTF8);
        }

        private static string BuildMarkdown(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights)
        {
            var builder = new StringBuilder();

            builder.AppendLine($"# {document.Title}");
            builder.AppendLine();
            builder.AppendLine("## Document");
            builder.AppendLine();
            builder.AppendLine($"- File: `{document.FilePath}`");
            builder.AppendLine($"- Original: `{document.OriginalFilePath}`");
            builder.AppendLine($"- Added: {document.AddedAt:yyyy-MM-dd HH:mm}");
            builder.AppendLine($"- Last page: {document.LastReadPage}");
            builder.AppendLine();

            builder.AppendLine("## Notes");
            builder.AppendLine();

            if (string.IsNullOrWhiteSpace(noteText))
            {
                builder.AppendLine("_No notes yet._");
            }
            else
            {
                builder.AppendLine(noteText.Trim());
            }

            builder.AppendLine();
            builder.AppendLine("## Highlights");
            builder.AppendLine();

            var orderedHighlights = highlights
                .OrderBy(highlight => highlight.PageNumber)
                .ThenBy(highlight => highlight.CreatedAt)
                .ToList();

            if (orderedHighlights.Count == 0)
            {
                builder.AppendLine("_No highlights yet._");
                return builder.ToString();
            }

            foreach (var highlight in orderedHighlights)
            {
                builder.AppendLine($"### Page {highlight.PageNumber}");
                builder.AppendLine();
                builder.AppendLine($"> {NormalizeQuote(highlight.Text)}");
                builder.AppendLine();
                builder.AppendLine($"- Created: {highlight.CreatedAt:yyyy-MM-dd HH:mm}");
                builder.AppendLine($"- Highlight Id: `{highlight.Id}`");
                builder.AppendLine();
            }

            return builder.ToString();
        }

        private static string NormalizeQuote(string? text)
        {
            return (text ?? string.Empty)
                .Replace("\r\n", "\n")
                .Replace("\r", "\n")
                .Replace("\n", "\n> ")
                .Trim();
        }
    }
}
``

## MiniZotero/Services/PdfJsServerService.cs

``csharp
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public sealed class PdfJsServerService : IDisposable
    {
        private const int DefaultPort = 51234;
        private const int LastFallbackPort = 51244;

        private readonly ConcurrentDictionary<string, string> _pdfFiles = new();

        private HttpListener? _listener;
        private bool _isStarted;

        public int Port { get; private set; } = DefaultPort;

        public string BaseUrl => $"http://127.0.0.1:{Port}";

        public void Start()
        {
            if (_isStarted)
            {
                return;
            }

            _listener = StartListener();

            _isStarted = true;

            Task.Run(ListenLoop);
        }

        public void Stop()
        {
            if (!_isStarted)
            {
                return;
            }

            _isStarted = false;

            try
            {
                _listener?.Stop();
                _listener?.Close();
            }
            catch
            {
                // Ignore shutdown errors.
            }
            finally
            {
                _listener = null;
            }
        }

        public string RegisterPdf(
            string documentKey,
            string filePath,
            int pageNumber = 1,
            int zoomPercent = 120,
            string? reloadToken = null)
        {
            _pdfFiles[documentKey] = filePath;

            if (pageNumber < 1)
            {
                pageNumber = 1;
            }

            zoomPercent = Math.Clamp(zoomPercent, 50, 400);

            string pdfUrl = $"{BaseUrl}/pdf/{Uri.EscapeDataString(documentKey)}";

            string viewerUrl =
                $"{BaseUrl}/viewer/index.html" +
                $"?file={Uri.EscapeDataString(pdfUrl)}" +
                $"&documentId={Uri.EscapeDataString(documentKey)}" +
                $"&v={Uri.EscapeDataString(reloadToken ?? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString())}" +
                $"#page={pageNumber}&zoom={zoomPercent}";

            return viewerUrl;
        }

        private async Task ListenLoop()
        {
            while (_listener?.IsListening == true)
            {
                try
                {
                    HttpListenerContext context = await _listener.GetContextAsync();
                    _ = Task.Run(() => HandleRequest(context));
                }
                catch (ObjectDisposedException)
                {
                    break;
                }
                catch (HttpListenerException)
                {
                    if (_listener?.IsListening != true)
                    {
                        break;
                    }
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

        private HttpListener StartListener()
        {
            for (var port = DefaultPort; port <= LastFallbackPort; port++)
            {
                var listener = new HttpListener();
                var prefix = $"http://127.0.0.1:{port}/";
                listener.Prefixes.Add(prefix);

                try
                {
                    listener.Start();
                    Port = port;
                    return listener;
                }
                catch (HttpListenerException)
                {
                    listener.Close();
                }
            }

            throw new InvalidOperationException("Unable to start the local PDF server.");
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
``

## MiniZotero/Services/StorageUsageService.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;

namespace MiniZotero.Services
{
    public sealed class StorageUsageService
    {
        public long GetLibraryUsageBytes(IEnumerable<DocumentItem> documents)
        {
            return documents
                .Where(document => !document.IsDeleted)
                .Sum(GetDocumentFileSize);
        }

        public string FormatByteCount(long bytes)
        {
            string[] units = ["B", "KB", "MB", "GB", "TB"];
            var size = (double)Math.Max(bytes, 0);
            var unitIndex = 0;

            while (size >= 1024 && unitIndex < units.Length - 1)
            {
                size /= 1024;
                unitIndex++;
            }

            return unitIndex == 0
                ? $"{size:0} {units[unitIndex]}"
                : $"{size:0.#} {units[unitIndex]}";
        }

        private static long GetDocumentFileSize(DocumentItem document)
        {
            try
            {
                return !string.IsNullOrWhiteSpace(document.FilePath) && File.Exists(document.FilePath)
                    ? new FileInfo(document.FilePath).Length
                    : 0;
            }
            catch (IOException)
            {
                return 0;
            }
            catch (UnauthorizedAccessException)
            {
                return 0;
            }
        }
    }
}
``

## MiniZotero/Services/WatchFolderService.cs

``csharp
using System;
using System.IO;
using System.Threading.Tasks;

namespace MiniZotero.Services
{
    public sealed class WatchFolderService : IDisposable
    {
        private FileSystemWatcher? _watcher;

        public event Action<string>? PdfDetected;

        public string? FolderPath { get; private set; }

        public bool IsWatching => _watcher is not null;

        public void Start(string folderPath)
        {
            Stop();

            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return;
            }

            FolderPath = folderPath;

            _watcher = new FileSystemWatcher(folderPath)
            {
                Filter = "*.pdf",
                IncludeSubdirectories = false,
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime | NotifyFilters.Size
            };

            _watcher.Created += OnPdfCreated;
            _watcher.Renamed += OnPdfRenamed;
            _watcher.EnableRaisingEvents = true;

            ImportExistingPdfs(folderPath);
        }

        public void Stop()
        {
            if (_watcher is null)
            {
                return;
            }

            _watcher.EnableRaisingEvents = false;
            _watcher.Created -= OnPdfCreated;
            _watcher.Renamed -= OnPdfRenamed;
            _watcher.Dispose();
            _watcher = null;
        }

        private void ImportExistingPdfs(string folderPath)
        {
            foreach (var filePath in Directory.EnumerateFiles(folderPath, "*.pdf"))
            {
                _ = NotifyWhenReadyAsync(filePath);
            }
        }

        private void OnPdfCreated(object sender, FileSystemEventArgs e)
        {
            _ = NotifyWhenReadyAsync(e.FullPath);
        }

        private void OnPdfRenamed(object sender, RenamedEventArgs e)
        {
            _ = NotifyWhenReadyAsync(e.FullPath);
        }

        private async Task NotifyWhenReadyAsync(string filePath)
        {
            if (!filePath.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            var isReady = await WaitUntilFileReadyAsync(filePath);

            if (isReady)
            {
                PdfDetected?.Invoke(filePath);
            }
        }

        private static async Task<bool> WaitUntilFileReadyAsync(string filePath)
        {
            for (var attempt = 0; attempt < 20; attempt++)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        return false;
                    }

                    using var stream = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                    return stream.Length > 0;
                }
                catch (IOException)
                {
                    await Task.Delay(300);
                }
                catch (UnauthorizedAccessException)
                {
                    await Task.Delay(300);
                }
            }

            return false;
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
``

## MiniZotero/ViewLocator.cs

``csharp
using System;
using System.Diagnostics.CodeAnalysis;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using MiniZotero.ViewModels;

namespace MiniZotero
{
    /// <summary>
    /// Given a view model, returns the corresponding view if possible.
    /// </summary>
    [RequiresUnreferencedCode(
        "Default implementation of ViewLocator involves reflection which may be trimmed away.",
        Url = "https://docs.avaloniaui.net/docs/concepts/view-locator")]
    public class ViewLocator : IDataTemplate
    {
        public Control? Build(object? param)
        {
            if (param is null)
                return null;

            var name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
            var type = Type.GetType(name);

            if (type != null)
            {
                return (Control)Activator.CreateInstance(type)!;
            }

            return new TextBlock { Text = "Not Found: " + name };
        }

        public bool Match(object? data)
        {
            return data is ViewModelBase;
        }
    }
}
``

## MiniZotero/ViewModels/MainWindowViewModel.cs

``csharp
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var storageService = new AppStorageService();
            var autoTagService = new AutoTagService();
            var documentRepository = new DocumentRepository(storageService, autoTagService);
            var noteRepository = new NoteRepository(storageService);
            var highlightRepository = new HighlightRepository(storageService);
            var settingsRepository = new AppSettingsRepository(storageService);
            var watchFolderService = new WatchFolderService();
            var markdownExportService = new MarkdownExportService();
            var storageUsageService = new StorageUsageService();

            Sidebar = new SidebarViewModel(
                documentRepository,
                settingsRepository,
                watchFolderService,
                storageUsageService);
            Notes = new NotePreviewPanelViewModel(
                noteRepository,
                highlightRepository,
                markdownExportService);
            Workspace = new TabWorkspaceViewModel(document =>
                documentRepository.SaveDocuments(Sidebar.Documents));

            Workspace.PdfViewer.HighlightCreated += (text, pageNumber, rects) =>
            {
                Notes.AddHighlightFromViewer(text, pageNumber, rects);
            };

            Notes.HighlightsChanged += () =>
            {
                Workspace.PdfViewer.LoadHighlightsIntoViewer(Notes.Highlights);
            };

            Notes.HighlightSelected += highlight =>
            {
                Workspace.PdfViewer.NavigateToHighlight(highlight);
            };

            Workspace.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(TabWorkspaceViewModel.ActiveDocument))
                {
                    OnPropertyChanged(nameof(OpenDocumentCount));
                    OnPropertyChanged(nameof(DocumentsOpenText));
                }
            };

            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.SelectedDocument) &&
                    Sidebar.SelectedDocument is { } document)
                {
                    Workspace.OpenDocument(document);
                    Notes.OpenDocument(document);
                    Workspace.PdfViewer.LoadHighlightsIntoViewer(Notes.Highlights);
                }
            };
        }

        public SidebarViewModel Sidebar { get; }

        public TabWorkspaceViewModel Workspace { get; }

        public NotePreviewPanelViewModel Notes { get; }

        public int OpenDocumentCount => Workspace.ActiveDocument is null ? 0 : 1;

        public string DocumentsOpenText =>
            OpenDocumentCount == 1
                ? "1 document open"
                : $"{OpenDocumentCount} documents open";

        public string LibraryStatusText => "Local library";
    }
}
``

## MiniZotero/ViewModels/NotePreviewPanelViewModel.cs

``csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class NotePreviewPanelViewModel : ViewModelBase
    {
        private readonly NoteRepository _noteRepository;
        private readonly HighlightRepository _highlightRepository;
        private readonly MarkdownExportService _markdownExportService;
        private bool _isLoadingNote;

        public NotePreviewPanelViewModel(
            NoteRepository noteRepository,
            HighlightRepository highlightRepository,
            MarkdownExportService markdownExportService)
        {
            _noteRepository = noteRepository;
            _highlightRepository = highlightRepository;
            _markdownExportService = markdownExportService;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasDocument))]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        [NotifyPropertyChangedFor(nameof(HasHighlights))]
        [NotifyPropertyChangedFor(nameof(IsHighlightEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        [ObservableProperty]
        private string _noteText = string.Empty;

        public ObservableCollection<HighlightItem> Highlights { get; } = [];

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public bool HasHighlights => Highlights.Count > 0;

        public bool IsHighlightEmptyViewVisible => HasDocument && !HasHighlights;

        public event Action<HighlightItem>? HighlightSelected;

        public event Action? HighlightsChanged;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            _isLoadingNote = true;

            try
            {
                NoteText = _noteRepository.LoadNote(document.Id);
            }
            finally
            {
                _isLoadingNote = false;
            }

            LoadHighlights(document.Id);
        }

        public void AddHighlightFromViewer(
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (ActiveDocument is null ||
                string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            var highlight = new HighlightItem
            {
                DocumentId = ActiveDocument.Id,
                PageNumber = pageNumber < 1 ? 1 : pageNumber,
                Text = text.Trim(),
                Color = "yellow",
                Rects = rects.ToList()
            };

            _highlightRepository.AddHighlight(highlight);
            LoadHighlights(ActiveDocument.Id);
        }

        public void ExportActiveDocumentToMarkdown(string outputPath)
        {
            if (ActiveDocument is null)
            {
                return;
            }

            _markdownExportService.ExportDocumentNotes(
                ActiveDocument,
                NoteText,
                Highlights,
                outputPath);
        }

        private void LoadHighlights(string documentId)
        {
            Highlights.Clear();

            foreach (var highlight in _highlightRepository.LoadHighlights(documentId))
            {
                Highlights.Add(highlight);
            }

            OnPropertyChanged(nameof(HasHighlights));
            OnPropertyChanged(nameof(IsHighlightEmptyViewVisible));
            HighlightsChanged?.Invoke();
        }

        [RelayCommand]
        private void SelectHighlight(HighlightItem? highlight)
        {
            if (highlight is null)
            {
                return;
            }

            HighlightSelected?.Invoke(highlight);
        }

        [RelayCommand]
        private void DeleteHighlight(HighlightItem? highlight)
        {
            if (highlight is null || ActiveDocument is null)
            {
                return;
            }

            _highlightRepository.DeleteHighlight(ActiveDocument.Id, highlight.Id);
            LoadHighlights(ActiveDocument.Id);
        }

        partial void OnNoteTextChanged(string value)
        {
            if (_isLoadingNote || ActiveDocument is not { } document)
            {
                return;
            }

            _noteRepository.SaveNote(document.Id, value);
        }
    }
}
``

## MiniZotero/ViewModels/PdfViewerViewModel.cs

``csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class PdfViewerViewModel : ViewModelBase
    {
        private static readonly PdfJsServerService PdfServer = new();
        private readonly Action<DocumentItem> _persistReadingState;
        private DocumentItem? _activeDocument;
        private IReadOnlyList<HighlightItem> _currentHighlights = [];

        public PdfViewerViewModel()
            : this(_ => { })
        {
        }

        public PdfViewerViewModel(Action<DocumentItem> persistReadingState)
        {
            _persistReadingState = persistReadingState;
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private bool _hasDocumentLoaded;

        [ObservableProperty]
        private string _documentPath = string.Empty;

        [ObservableProperty]
        private Uri? _viewerSource;

        [ObservableProperty]
        private int _currentPage = 1;

        [ObservableProperty]
        private int _zoomPercent = 120;

        [ObservableProperty]
        private string _statusText = "Ready";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsHandToolActive))]
        [NotifyPropertyChangedFor(nameof(IsSelectToolActive))]
        [NotifyPropertyChangedFor(nameof(IsHighlightToolActive))]
        private string _toolMode = "select";

        [ObservableProperty]
        private string _emptyTitle = "Select a document to view";

        [ObservableProperty]
        private string _emptyMessage = "Import a PDF file from the sidebar.";

        public bool IsEmptyViewVisible => !HasDocumentLoaded;

        public bool IsHandToolActive => ToolMode == "hand";

        public bool IsSelectToolActive => ToolMode == "select";

        public bool IsHighlightToolActive => ToolMode == "highlight";

        public event Action<string, int, IReadOnlyList<HighlightRect>>? HighlightCreated;

        public event Action<string>? ScriptRequested;

        public void LoadDocument(DocumentItem document)
        {
            _activeDocument = document;

            if (!File.Exists(document.FilePath))
            {
                DocumentPath = document.FilePath;
                StatusText = "File not found";
                EmptyTitle = document.Title;
                EmptyMessage = "The selected PDF file does not exist.";
                HasDocumentLoaded = false;
                return;
            }

            DocumentPath = document.FilePath;
            CurrentPage = Math.Max(1, document.LastReadPage);
            ZoomPercent = ClampZoomPercent(document.LastZoomPercent);

            PdfServer.Start();

            var documentKey = string.IsNullOrWhiteSpace(document.Id)
                ? Path.GetFileNameWithoutExtension(document.FilePath)
                : document.Id;

            string viewerUrl = PdfServer.RegisterPdf(
                documentKey,
                document.FilePath,
                CurrentPage,
                ZoomPercent,
                DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString()
            );

            ViewerSource = new Uri(viewerUrl);

            StatusText = "Document loaded";
            EmptyTitle = document.Title;
            EmptyMessage = string.Empty;
            HasDocumentLoaded = true;
        }

        public void UpdateReadingStateFromViewer(int pageNumber, int zoomPercent)
        {
            CurrentPage = Math.Max(1, pageNumber);
            ZoomPercent = ClampZoomPercent(zoomPercent);

            if (_activeDocument is not null &&
                (_activeDocument.LastReadPage != CurrentPage ||
                 _activeDocument.LastZoomPercent != ZoomPercent))
            {
                _activeDocument.LastReadPage = CurrentPage;
                _activeDocument.LastZoomPercent = ZoomPercent;
                _persistReadingState(_activeDocument);
            }

            StatusText = $"Page {CurrentPage}";
        }

        public void SetHandTool()
        {
            ToolMode = "hand";
        }

        public void SetSelectTool()
        {
            ToolMode = "select";
        }

        public void SetHighlightTool()
        {
            ToolMode = "highlight";
        }

        public void AddHighlightFromViewer(
            string text,
            int pageNumber,
            IReadOnlyList<HighlightRect> rects)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return;
            }

            HighlightCreated?.Invoke(text, pageNumber, rects);
        }

        public void LoadHighlightsIntoViewer(IReadOnlyList<HighlightItem> highlights)
        {
            _currentHighlights = highlights;
            SendHighlightsToViewer();
        }

        public void SendHighlightsToViewer()
        {
            var json = JsonSerializer.Serialize(_currentHighlights);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.setHighlights?.({json});");
        }

        public void NavigateToHighlight(HighlightItem highlight)
        {
            if (string.IsNullOrWhiteSpace(highlight.Id))
            {
                return;
            }

            var idJson = JsonSerializer.Serialize(highlight.Id);
            ScriptRequested?.Invoke($"window.miniZoteroPdf?.goToHighlight?.({idJson});");
        }

        private static int ClampZoomPercent(int zoomPercent)
        {
            return Math.Clamp(zoomPercent <= 0 ? 120 : zoomPercent, 50, 400);
        }
    }
}
``

## MiniZotero/ViewModels/SidebarViewModel.cs

``csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public sealed partial class SidebarNavigationItem : ObservableObject
    {
        public SidebarNavigationItem(
            string name,
            string icon,
            string? countText = null)
        {
            Name = name;
            Icon = icon;
            CountText = countText;
        }

        public string Name { get; }

        public string Icon { get; }

        [ObservableProperty]
        private string? _countText;
    }

    public sealed partial class SmartCollectionItem : ObservableObject
    {
        public SmartCollectionItem(
            string name,
            string kind,
            string icon,
            string iconColor,
            int count = 0)
        {
            Name = name;
            Kind = kind;
            Icon = icon;
            IconColor = iconColor;
            Count = count;
        }

        public string Name { get; }

        public string Kind { get; }

        public string Icon { get; }

        public string IconColor { get; }

        [ObservableProperty]
        private int _count;

    }

    public sealed partial class TagItem : ObservableObject
    {
        public TagItem(string name, string? countText = null)
        {
            Name = name;
            CountText = countText;
        }

        public string Name { get; }

        [ObservableProperty]
        private string? _countText;
    }

    public sealed class DocumentExplorerItem
    {
        private DocumentExplorerItem(
            string name,
            string icon,
            bool isFolder,
            DocumentItem? document,
            int count = 0,
            bool isExpanded = false)
        {
            Name = name;
            Icon = icon;
            IsFolder = isFolder;
            Document = document;
            Count = count;
            IsExpanded = isExpanded;
        }

        public string Name { get; }

        public string Icon { get; }

        public bool IsFolder { get; }

        public bool IsDocument => Document is not null;

        public DocumentItem? Document { get; }

        public int Count { get; }

        public bool IsExpanded { get; }

        public string ChevronIcon => IsFolder
            ? IsExpanded ? "\uE70D" : "\uE76C"
            : string.Empty;

        public string IconForeground => IsFolder ? "#7DD3FC" : "#52C7FF";

        public int IconFontSize => IsFolder ? 13 : 12;

        public string NameForeground => IsFolder ? "#F2F6FC" : "#E4EBF4";

        public string NameFontWeight => IsFolder ? "SemiBold" : "Normal";

        public bool IsStarred => Document?.IsStarred == true;

        public bool IsStarButtonVisible => IsDocument && Document?.IsDeleted != true;

        public static DocumentExplorerItem Folder(string name, int count, bool isExpanded)
        {
            return new DocumentExplorerItem(name, "\uE8B7", isFolder: true, document: null, count, isExpanded);
        }

        public static DocumentExplorerItem File(DocumentItem document)
        {
            return new DocumentExplorerItem(document.Title, "\uE7C3", isFolder: false, document);
        }
    }

    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly DocumentRepository _documentRepository;
        private readonly AppSettingsRepository _settingsRepository;
        private readonly WatchFolderService _watchFolderService;
        private readonly StorageUsageService _storageUsageService;
        private readonly SidebarNavigationItem _libraryNavigationItem;
        private readonly SidebarNavigationItem _recentNavigationItem;
        private readonly SidebarNavigationItem _starredNavigationItem;
        private readonly SidebarNavigationItem _trashNavigationItem;
        private readonly Dictionary<string, bool> _expandedFolders = new(StringComparer.OrdinalIgnoreCase);
        private bool _isRebuildingTags;

        public SidebarViewModel()
            : this(
                new DocumentRepository(new AppStorageService(), new AutoTagService()),
                new AppSettingsRepository(new AppStorageService()),
                new WatchFolderService(),
                new StorageUsageService())
        {
        }

        public SidebarViewModel(
            DocumentRepository documentRepository,
            AppSettingsRepository settingsRepository,
            WatchFolderService watchFolderService,
            StorageUsageService storageUsageService)
        {
            _documentRepository = documentRepository;
            _settingsRepository = settingsRepository;
            _watchFolderService = watchFolderService;
            _storageUsageService = storageUsageService;
            _watchFolderService.PdfDetected += OnWatchFolderPdfDetected;

            _libraryNavigationItem = new SidebarNavigationItem("Library", "\uE8B7", "0");
            _recentNavigationItem = new SidebarNavigationItem("Recent", "\uE823", "0");
            _starredNavigationItem = new SidebarNavigationItem("Starred", "\uE734", "0");
            _trashNavigationItem = new SidebarNavigationItem("Trash", "\uE74D", "0");

            NavigationItems.Add(_libraryNavigationItem);
            NavigationItems.Add(_recentNavigationItem);
            NavigationItems.Add(_starredNavigationItem);
            NavigationItems.Add(_trashNavigationItem);
            SelectedNavigationItem = _libraryNavigationItem;
            SmartCollections.Clear();
            SmartCollections.Add(new SmartCollectionItem("Đang đọc dở", "reading", "\uE7C1", "#8DD6A5"));
            SmartCollections.Add(new SmartCollectionItem("Mới thêm", "new", "\uE8A5", "#9CCBFF"));
            SmartCollections.Add(new SmartCollectionItem("Đã mở gần đây", "recent", "\uE823", "#D9C7FF"));
            SmartCollections.Add(new SmartCollectionItem("Chưa đọc", "unread", "\uE7BE", "#FBBF24"));
            SelectedSmartCollection = null;
            SelectedNavigationItem = _libraryNavigationItem;

            var settings = _settingsRepository.LoadSettings();
            WatchFolderPath = settings.WatchFolderPath;

            if (!string.IsNullOrWhiteSpace(WatchFolderPath))
            {
                _watchFolderService.Start(WatchFolderPath);
            }

            foreach (var document in _documentRepository.LoadDocuments())
            {
                Documents.Add(document);
            }

            RebuildTags();
            ApplyDocumentFilter();
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasSelectedDocument))]
        [NotifyPropertyChangedFor(nameof(IsMoveToTrashVisible))]
        [NotifyPropertyChangedFor(nameof(IsTrashDocumentActionsVisible))]
        [NotifyPropertyChangedFor(nameof(IsTagEditorVisible))]
        private DocumentItem? _selectedDocument;

        [ObservableProperty]
        private DocumentExplorerItem? _selectedExplorerItem;

        [ObservableProperty]
        private string _searchText = string.Empty;

        [ObservableProperty]
        private string _newTagText = string.Empty;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsWatchFolderConfigured))]
        [NotifyPropertyChangedFor(nameof(WatchFolderStatusText))]
        private string? _watchFolderPath;

        [ObservableProperty]
        private SidebarNavigationItem? _selectedNavigationItem;

        [ObservableProperty]
        private SmartCollectionItem? _selectedSmartCollection;

        [ObservableProperty]
        private TagItem? _selectedTag;

        public ObservableCollection<SidebarNavigationItem> NavigationItems { get; } = new();

        public ObservableCollection<SmartCollectionItem> SmartCollections { get; } = new();

        public ObservableCollection<TagItem> Tags { get; } = new();

        public ObservableCollection<DocumentItem> Documents { get; } = new();

        public ObservableCollection<DocumentItem> FilteredDocuments { get; } = new();

        public ObservableCollection<DocumentItem> SearchResultDocuments { get; } = new();

        public ObservableCollection<DocumentExplorerItem> DocumentExplorerItems { get; } = new();

        public int DocumentCount => FilteredDocuments.Count;

        public bool HasDocuments => Documents.Count > 0;

        public bool HasVisibleDocuments => FilteredDocuments.Count > 0;

        public bool HasSelectedDocument => SelectedDocument is not null;

        public bool IsEmptyViewVisible => Documents.Count == 0;

        public bool IsTrashSelected => SelectedNavigationItem?.Name == "Trash";

        public bool IsMoveToTrashVisible =>
            HasSelectedDocument && !IsTrashSelected && SelectedDocument?.IsDeleted != true;

        public bool IsTrashDocumentActionsVisible =>
            HasSelectedDocument && IsTrashSelected && SelectedDocument?.IsDeleted == true;

        public bool IsTagEditorVisible =>
            HasSelectedDocument && !IsTrashSelected && SelectedDocument?.IsDeleted != true;

        public bool HasSearchText => !string.IsNullOrWhiteSpace(SearchText);

        public bool HasSearchResults => HasSearchText && SearchResultDocuments.Count > 0;

        public bool IsSearchDropdownVisible => HasSearchText;

        public bool IsNoSearchResultVisible =>
            HasSearchText && SearchResultDocuments.Count == 0;

        public string CurrentDocumentSectionTitle =>
            SelectedSmartCollection is not null
                ? SelectedSmartCollection.Name.ToUpperInvariant()
                : SelectedNavigationItem?.Name switch
                {
                    "Recent" => "RECENT DOCUMENTS",
                    "Starred" => "STARRED",
                    "Trash" => "TRASH",
                    _ => "DOCUMENTS"
                };

        public bool IsWatchFolderConfigured => !string.IsNullOrWhiteSpace(WatchFolderPath);

        public string WatchFolderStatusText =>
            IsWatchFolderConfigured
                ? $"Đang theo dõi: {Path.GetFileName(WatchFolderPath)}"
                : "Not configured";

        public string StorageUsageText
        {
            get
            {
                var bytes = _storageUsageService.GetLibraryUsageBytes(Documents);
                return $"Storage  {_storageUsageService.FormatByteCount(bytes)} used";
            }
        }

        public void AddDocument(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return;
            }

            var document = _documentRepository.ImportDocument(filePath, Documents);
            if (!Documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                Documents.Add(document);
            }
            else if (document.IsDeleted)
            {
                document.IsDeleted = false;
                document.DeletedAt = null;
            }

            PersistDocumentsAndRefresh();

            SelectedDocument = document;
        }

        public void SetWatchFolder(string folderPath)
        {
            if (string.IsNullOrWhiteSpace(folderPath) || !Directory.Exists(folderPath))
            {
                return;
            }

            WatchFolderPath = folderPath;

            _settingsRepository.SaveSettings(new AppSettings
            {
                WatchFolderPath = folderPath
            });

            _watchFolderService.Start(folderPath);
        }

        partial void OnSearchTextChanged(string value)
        {
            ApplySearchFilter();
        }

        partial void OnSelectedTagChanged(TagItem? value)
        {
            if (!_isRebuildingTags)
            {
                ApplyDocumentFilter();
            }
        }

        partial void OnSelectedSmartCollectionChanged(SmartCollectionItem? value)
        {
            if (value is not null)
            {
                SelectedNavigationItem = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        partial void OnSelectedDocumentChanged(DocumentItem? value)
        {
            if (value is null)
            {
                OnPropertyChanged(nameof(IsMoveToTrashVisible));
                OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
                OnPropertyChanged(nameof(IsTagEditorVisible));
                return;
            }

            var matchingExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                item.Document?.Id == value.Id);
            if (matchingExplorerItem is not null && SelectedExplorerItem != matchingExplorerItem)
            {
                SelectedExplorerItem = matchingExplorerItem;
            }

            if (HasSearchText)
            {
                SearchText = string.Empty;
            }

            Dispatcher.UIThread.Post(() =>
            {
                if (value.IsDeleted)
                {
                    return;
                }

                value.LastOpenedAt = DateTimeOffset.Now;
                _documentRepository.SaveDocuments(Documents);

                if (ShouldRefreshDocumentListAfterOpen())
                {
                    ApplyDocumentFilter();
                    ApplySearchFilter();
                }
                else
                {
                    NotifyDocumentStateChanged();
                }
            });
        }

        partial void OnSelectedExplorerItemChanged(DocumentExplorerItem? value)
        {
            if (value?.Document is { } document && SelectedDocument != document)
            {
                SelectedDocument = document;
                return;
            }

            if (value?.IsFolder == true)
            {
                Dispatcher.UIThread.Post(() =>
                {
                    SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                        item.Document?.Id == SelectedDocument?.Id);
                });
            }
        }

        partial void OnSelectedNavigationItemChanged(SidebarNavigationItem? value)
        {
            if (value is not null)
            {
                SelectedSmartCollection = null;
                SelectedTag = null;
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
        }

        [RelayCommand]
        private void ToggleStar(DocumentItem? document)
        {
            if (document is null || document.IsDeleted)
            {
                return;
            }

            document.IsStarred = !document.IsStarred;

            PersistDocumentsAndRefresh(rebuildTags: false);
        }

        [RelayCommand]
        private void ToggleFolder(DocumentExplorerItem? item)
        {
            if (item?.IsFolder != true)
            {
                return;
            }

            _expandedFolders[item.Name] = !item.IsExpanded;
            ApplyDocumentFilter();
        }

        [RelayCommand]
        private void AddTagToSelectedDocument()
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted)
            {
                return;
            }

            var tag = NewTagText.Trim();
            if (string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            SelectedDocument.Tags ??= [];

            var exists = SelectedDocument.Tags.Any(existingTag =>
                string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

            if (!exists)
            {
                SelectedDocument.Tags.Add(tag);
            }

            NewTagText = string.Empty;

            PersistDocumentsAndRefresh();
        }

        [RelayCommand]
        private void RemoveTagFromSelectedDocument(string? tag)
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted || string.IsNullOrWhiteSpace(tag))
            {
                return;
            }

            SelectedDocument.Tags.RemoveAll(existingTag =>
                string.Equals(existingTag, tag, StringComparison.OrdinalIgnoreCase));

            PersistDocumentsAndRefresh();
        }

        private void OnWatchFolderPdfDetected(string filePath)
        {
            Dispatcher.UIThread.Post(() =>
            {
                AddDocument(filePath);
            });
        }

        [RelayCommand]
        private void MoveSelectedDocumentToTrash()
        {
            if (SelectedDocument is null || SelectedDocument.IsDeleted)
            {
                return;
            }

            SelectedDocument.IsDeleted = true;
            SelectedDocument.DeletedAt = DateTimeOffset.Now;

            SelectedDocument = null;
            PersistDocumentsAndRefresh();
        }

        [RelayCommand]
        private void RestoreSelectedDocument()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            SelectedDocument.IsDeleted = false;
            SelectedDocument.DeletedAt = null;

            SelectedDocument = null;
            PersistDocumentsAndRefresh();
        }

        [RelayCommand]
        private void DeleteSelectedDocumentForever()
        {
            if (SelectedDocument is null || !SelectedDocument.IsDeleted)
            {
                return;
            }

            var document = SelectedDocument;
            SelectedDocument = null;

            _documentRepository.DeleteStoredPdfFile(document);
            Documents.Remove(document);

            PersistDocumentsAndRefresh();
        }

        private void PersistDocumentsAndRefresh(bool rebuildTags = true)
        {
            _documentRepository.SaveDocuments(Documents);

            if (rebuildTags)
            {
                RebuildTags();
            }

            ApplyDocumentFilter();
            ApplySearchFilter();
        }

        private bool ShouldRefreshDocumentListAfterOpen()
        {
            return SelectedNavigationItem?.Name == "Recent" ||
                   SelectedSmartCollection?.Kind is "recent" or "unread";
        }

        private void ApplyDocumentFilter()
        {
            FilteredDocuments.Clear();
            DocumentExplorerItems.Clear();

            var documents = ApplySmartCollectionFilter(GetNavigationDocuments());

            if (SelectedTag is not null)
            {
                documents = documents.Where(document =>
                    document.Tags.Any(tag =>
                        string.Equals(tag, SelectedTag.Name, StringComparison.OrdinalIgnoreCase)));
            }

            var filteredDocuments = documents.ToList();

            if (SelectedDocument is not null &&
                filteredDocuments.All(document => document.Id != SelectedDocument.Id))
            {
                SelectedDocument = null;
            }

            foreach (var document in filteredDocuments)
            {
                FilteredDocuments.Add(document);
            }

            BuildDocumentExplorerItems(filteredDocuments);

            NotifyDocumentStateChanged();
        }

        private void RebuildTags()
        {
            var selectedTagName = SelectedTag?.Name;

            _isRebuildingTags = true;

            try
            {
                Tags.Clear();

                var tagGroups = Documents
                    .Where(document => !document.IsDeleted)
                    .SelectMany(document => document.Tags)
                    .Where(tag => !string.IsNullOrWhiteSpace(tag))
                    .GroupBy(tag => tag.Trim(), StringComparer.OrdinalIgnoreCase)
                    .OrderBy(group => group.Key);

                foreach (var group in tagGroups)
                {
                    Tags.Add(new TagItem(group.Key, group.Count().ToString()));
                }

                SelectedTag = !string.IsNullOrWhiteSpace(selectedTagName)
                    ? Tags.FirstOrDefault(tag =>
                        string.Equals(tag.Name, selectedTagName, StringComparison.OrdinalIgnoreCase))
                    : null;
            }
            finally
            {
                _isRebuildingTags = false;
            }
        }

        private void BuildDocumentExplorerItems(IReadOnlyList<DocumentItem> documents)
        {
            var groups = documents
                .GroupBy(GetDocumentFolderName)
                .OrderBy(group => group.Key);

            foreach (var group in groups)
            {
                var isExpanded = IsFolderExpanded(group.Key);
                DocumentExplorerItems.Add(DocumentExplorerItem.Folder(group.Key, group.Count(), isExpanded));

                if (!isExpanded)
                {
                    continue;
                }

                foreach (var document in group)
                {
                    DocumentExplorerItems.Add(DocumentExplorerItem.File(document));
                }
            }

            SelectedExplorerItem = DocumentExplorerItems.FirstOrDefault(item =>
                item.Document?.Id == SelectedDocument?.Id);
        }

        private bool IsFolderExpanded(string folderName)
        {
            if (!_expandedFolders.TryGetValue(folderName, out var isExpanded))
            {
                _expandedFolders[folderName] = false;
                return false;
            }

            return isExpanded;
        }

        private static string GetDocumentFolderName(DocumentItem document)
        {
            var path = !string.IsNullOrWhiteSpace(document.OriginalFilePath)
                ? document.OriginalFilePath
                : document.FilePath;

            var folderPath = Path.GetDirectoryName(path);
            if (string.IsNullOrWhiteSpace(folderPath))
            {
                return "Documents";
            }

            return Path.GetFileName(folderPath) is { Length: > 0 } folderName
                ? folderName
                : folderPath;
        }

        private void ApplySearchFilter()
        {
            SearchResultDocuments.Clear();

            var query = SearchText?.Trim();
            if (string.IsNullOrWhiteSpace(query))
            {
                NotifyDocumentStateChanged();
                return;
            }

            var documents = ApplySmartCollectionFilter(GetNavigationDocuments())
                .Where(document => MatchesSearch(document, query))
                .OrderBy(document => document.Title);

            foreach (var document in documents)
            {
                SearchResultDocuments.Add(document);
            }

            NotifyDocumentStateChanged();
        }

        private static bool MatchesSearch(DocumentItem document, string keyword)
        {
            return Contains(document.Title, keyword) ||
                   Contains(document.FilePath, keyword) ||
                   Contains(document.OriginalFilePath, keyword) ||
                   document.Tags.Any(tag => Contains(tag, keyword));
        }

        private static bool Contains(string? value, string keyword)
        {
            return !string.IsNullOrWhiteSpace(value) &&
                   value.Contains(keyword, StringComparison.OrdinalIgnoreCase);
        }

        private IEnumerable<DocumentItem> GetNavigationDocuments()
        {
            var documents = Documents.AsEnumerable();

            return SelectedNavigationItem?.Name switch
            {
                "Recent" => documents
                    .Where(document => !document.IsDeleted && document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "Starred" => documents
                    .Where(document => !document.IsDeleted && document.IsStarred)
                    .OrderBy(document => document.Title),

                "Trash" => documents
                    .Where(document => document.IsDeleted)
                    .OrderByDescending(document => document.DeletedAt),

                _ => documents
                    .Where(document => !document.IsDeleted)
                    .OrderBy(document => document.Title)
            };
        }

        private IEnumerable<DocumentItem> ApplySmartCollectionFilter(IEnumerable<DocumentItem> documents)
        {
            return SelectedSmartCollection?.Kind switch
            {
                "reading" => documents.Where(document => document.LastReadPage > 1),

                "new" => documents.Where(document =>
                    document.AddedAt >= DateTimeOffset.Now.AddDays(-7)),

                "recent" => documents
                    .Where(document => document.LastOpenedAt is not null)
                    .OrderByDescending(document => document.LastOpenedAt),

                "unread" => documents.Where(document => document.LastOpenedAt is null),

                _ => documents
            };
        }

        private void NotifyDocumentStateChanged()
        {
            RefreshSmartCollectionCounts();

            _libraryNavigationItem.CountText = Documents.Count(document => !document.IsDeleted).ToString();
            _recentNavigationItem.CountText = Documents.Count(document => !document.IsDeleted && document.LastOpenedAt is not null).ToString();
            _starredNavigationItem.CountText = Documents.Count(document => !document.IsDeleted && document.IsStarred).ToString();
            _trashNavigationItem.CountText = Documents.Count(document => document.IsDeleted).ToString();

            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(HasVisibleDocuments));
            OnPropertyChanged(nameof(HasSelectedDocument));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
            OnPropertyChanged(nameof(HasSearchText));
            OnPropertyChanged(nameof(HasSearchResults));
            OnPropertyChanged(nameof(IsSearchDropdownVisible));
            OnPropertyChanged(nameof(IsNoSearchResultVisible));
            OnPropertyChanged(nameof(IsTrashSelected));
            OnPropertyChanged(nameof(IsMoveToTrashVisible));
            OnPropertyChanged(nameof(IsTrashDocumentActionsVisible));
            OnPropertyChanged(nameof(IsTagEditorVisible));
            OnPropertyChanged(nameof(CurrentDocumentSectionTitle));
            OnPropertyChanged(nameof(StorageUsageText));
        }

        private void RefreshSmartCollectionCounts()
        {
            var newDocumentThreshold = DateTimeOffset.Now.AddDays(-7);

            foreach (var collection in SmartCollections)
            {
                collection.Count = collection.Kind switch
                {
                    "reading" => Documents.Count(document =>
                        !document.IsDeleted && document.LastReadPage > 1),

                    "new" => Documents.Count(document =>
                        !document.IsDeleted && document.AddedAt >= newDocumentThreshold),

                    "recent" => Documents.Count(document =>
                        !document.IsDeleted && document.LastOpenedAt is not null),

                    "unread" => Documents.Count(document =>
                        !document.IsDeleted && document.LastOpenedAt is null),

                    _ => 0
                };
            }
        }

    }
}
``

## MiniZotero/ViewModels/TabWorkspaceViewModel.cs

``csharp
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class TabWorkspaceViewModel : ViewModelBase
    {
        public TabWorkspaceViewModel()
            : this(_ => { })
        {
        }

        public TabWorkspaceViewModel(Action<DocumentItem> persistReadingState)
        {
            PdfViewer = new PdfViewerViewModel(persistReadingState);
        }

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        public PdfViewerViewModel PdfViewer { get; }

        public bool IsEmptyViewVisible => ActiveDocument is null;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            PdfViewer.LoadDocument(document);
        }
    }
}
``

## MiniZotero/ViewModels/ViewModelBase.cs

``csharp
using CommunityToolkit.Mvvm.ComponentModel;

namespace MiniZotero.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
    }
}
``

## MiniZotero/Views/MainWindow.axaml

``xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:models="using:MiniZotero.Models"
        xmlns:views="using:MiniZotero.Views"
        xmlns:vm="using:MiniZotero.ViewModels"
        mc:Ignorable="d"
        d:DesignWidth="1280"
        d:DesignHeight="820"
        Width="1280"
        Height="820"
        MinWidth="1120"
        MinHeight="720"
        x:Class="MiniZotero.Views.MainWindow"
        x:DataType="vm:MainWindowViewModel"
        Title="MiniZotero"
        Background="#0B1118"
        Foreground="#E7EDF6"
        FontFamily="Segoe UI">

    <Window.Styles>
        <Style Selector="Button">
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Padding" Value="8,4"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Foreground" Value="#D8E1EC"/>
        </Style>
        <Style Selector="Button:pointerover">
            <Setter Property="Background" Value="#243042"/>
        </Style>
        <Style Selector="Button.IconButton">
            <Setter Property="Width" Value="30"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#AAB6C6"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="TextBlock.Muted">
            <Setter Property="Foreground" Value="#8D9AAB"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,0,4"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.SearchResultsList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#263242"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
    </Window.Styles>

    <Grid RowDefinitions="48,*,30" ColumnDefinitions="224,*,492">
        <views:SidebarView Grid.Row="0"
                           Grid.RowSpan="3"
                           Grid.Column="0"
                           DataContext="{Binding Sidebar}"/>

        <Border Grid.Row="0"
                Grid.Column="1"
                Grid.ColumnSpan="2"
                Background="#101720"
                BorderBrush="#202B38"
                BorderThickness="0,0,0,1">
            <Grid ColumnDefinitions="Auto,*,Auto" Margin="8,0,10,0">
                <StackPanel Orientation="Horizontal" Spacing="8" VerticalAlignment="Center">
                    <Button Classes="IconButton" Content="&#xE710;" Click="OnImportPdfClicked"/>

                    <Border Background="#F7F9FC"
                            BorderBrush="#CAD3DF"
                            BorderThickness="1"
                            CornerRadius="7,7,0,0"
                            MinWidth="210"
                            Height="34"
                            Padding="10,0">
                        <Grid ColumnDefinitions="Auto,*,Auto">
                            <Border Width="16" Height="18" CornerRadius="3" Background="#EF4444" VerticalAlignment="Center">
                                <TextBlock Text="PDF"
                                           Foreground="White"
                                           FontSize="7"
                                           FontWeight="Bold"
                                           HorizontalAlignment="Center"
                                           VerticalAlignment="Center"/>
                            </Border>
                            <TextBlock Grid.Column="1"
                                       Text="{Binding Workspace.ActiveDocument.Title, FallbackValue=No document open}"
                                       Foreground="#172033"
                                       FontSize="12"
                                       FontWeight="SemiBold"
                                       Margin="8,0"
                                       VerticalAlignment="Center"
                                       TextTrimming="CharacterEllipsis"/>
                            <Button Grid.Column="2"
                                    Content="&#xE711;"
                                    FontFamily="Segoe MDL2 Assets"
                                    Foreground="#667386"
                                    Width="24"
                                    Height="24"
                                    Padding="0"
                                    HorizontalContentAlignment="Center"
                                    VerticalContentAlignment="Center"/>
                        </Grid>
                    </Border>
                </StackPanel>

                <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                    <Border Background="#172230" CornerRadius="7" Height="30" Width="48">
                        <Grid ColumnDefinitions="*,Auto" Margin="8,0">
                            <TextBlock Text="&#xE7F4;" FontFamily="Segoe MDL2 Assets" Foreground="#AEB9C8" VerticalAlignment="Center"/>
                            <TextBlock Grid.Column="1" Text="&#xE70D;" FontFamily="Segoe MDL2 Assets" Foreground="#8795A8" FontSize="9" VerticalAlignment="Center"/>
                        </Grid>
                    </Border>

                    <Border Background="#172230" CornerRadius="7" Height="30" Width="260" Padding="10,0">
                        <Grid ColumnDefinitions="Auto,*">
                            <TextBlock Text="&#xE721;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13" VerticalAlignment="Center"/>
                            <TextBox Grid.Column="1"
                                     Text="{Binding Sidebar.SearchText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                     PlaceholderText="Search documents."
                                     Background="Transparent"
                                     BorderThickness="0"
                                     Foreground="#D8E1EC"
                                     FontSize="12"
                                     Margin="8,0,0,0"
                                     Padding="0"
                                     VerticalAlignment="Center"
                                     VerticalContentAlignment="Center"/>
                        </Grid>
                    </Border>

                    <Button Classes="IconButton" Content="&#xE72D;"/>
                    <Button Classes="IconButton" Content="&#xE712;"/>
                    <Button Classes="IconButton" Content="&#xE713;"/>
                </StackPanel>
            </Grid>
        </Border>

        <views:TabWorkspaceView Grid.Row="1"
                                Grid.Column="1"
                                DataContext="{Binding Workspace}"/>

        <views:NotePreviewPanelView Grid.Row="1"
                                    Grid.Column="2"
                                    DataContext="{Binding Notes}"/>

        <Border Grid.Row="1"
                Grid.Column="2"
                Width="360"
                MaxHeight="320"
                Margin="54,8,0,0"
                HorizontalAlignment="Left"
                VerticalAlignment="Top"
                Background="#101720"
                BorderBrush="#263242"
                BorderThickness="1"
                CornerRadius="8"
                Padding="10"
                IsVisible="{Binding Sidebar.IsSearchDropdownVisible}">
            <Grid RowDefinitions="Auto,*">
                <Grid ColumnDefinitions="*,Auto" Margin="2,0,2,8">
                    <TextBlock Text="Search results"
                               Foreground="#E7EDF6"
                               FontSize="12"
                               FontWeight="SemiBold"/>
                    <TextBlock Grid.Column="1"
                               Text="{Binding Sidebar.SearchResultDocuments.Count}"
                               Foreground="#8D9AAB"
                               FontSize="11"/>
                </Grid>

                <Border Grid.Row="1"
                        Background="#1E293B"
                        CornerRadius="8"
                        Padding="12"
                        IsVisible="{Binding Sidebar.IsNoSearchResultVisible}">
                    <TextBlock Text="No matching documents."
                               Foreground="#94A3B8"
                               FontSize="12"
                               TextWrapping="Wrap"/>
                </Border>

                <ScrollViewer Grid.Row="1"
                              MaxHeight="260"
                              IsVisible="{Binding Sidebar.HasSearchResults}">
                    <ListBox Classes="SearchResultsList"
                             ItemsSource="{Binding Sidebar.SearchResultDocuments}"
                             SelectedItem="{Binding Sidebar.SelectedDocument, Mode=TwoWay}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="models:DocumentItem">
                                <Border Padding="9,7">
                                    <StackPanel Spacing="3">
                                        <TextBlock Text="{Binding Title}"
                                                   Foreground="#F2F6FC"
                                                   FontWeight="SemiBold"
                                                   FontSize="12"
                                                   TextTrimming="CharacterEllipsis"/>
                                        <TextBlock Text="{Binding FilePath}"
                                                   Foreground="#8D9AAB"
                                                   FontSize="10"
                                                   TextTrimming="CharacterEllipsis"/>
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </ScrollViewer>
            </Grid>
        </Border>

        <Border Grid.Row="2"
                Grid.Column="1"
                Grid.ColumnSpan="2"
                Background="#0B1118"
                BorderBrush="#202B38"
                BorderThickness="0,1,0,0">
            <Grid ColumnDefinitions="*,Auto,Auto,Auto" Margin="16,0">
                <TextBlock Text="Ready"
                           Classes="Muted"
                           FontSize="11"
                           VerticalAlignment="Center"/>
                <TextBlock Grid.Column="1"
                           Text="{Binding DocumentsOpenText}"
                           Classes="Muted"
                           FontSize="11"
                           VerticalAlignment="Center"
                           Margin="0,0,22,0"/>
                <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center" Margin="0,0,22,0">
                    <TextBlock Text="Library:"
                               Classes="Muted"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                    <TextBlock Text="{Binding LibraryStatusText}"
                               Foreground="#AAB6C6"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                    <Ellipse Width="8" Height="8" Stroke="#22C55E" StrokeThickness="1.5"/>
                </StackPanel>
                <StackPanel Grid.Column="3" Orientation="Horizontal" Spacing="8" VerticalAlignment="Center">
                    <TextBlock Text="&#xE713;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13"/>
                    <TextBlock Text="&#xE897;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13"/>
                    <TextBlock Text="&#xE710;" FontFamily="Segoe MDL2 Assets" Foreground="#8D9AAB" FontSize="13"/>
                </StackPanel>
            </Grid>
        </Border>
    </Grid>
</Window>
``

## MiniZotero/Views/MainWindow.axaml.cs

``csharp
using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void OnImportPdfClicked(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not MainWindowViewModel viewModel)
            {
                return;
            }

            var pdfFiles = await StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Import PDF",
                AllowMultiple = true,
                FileTypeFilter =
                [
                    new FilePickerFileType("PDF documents")
                    {
                        Patterns = ["*.pdf"],
                        MimeTypes = ["application/pdf"]
                    }
                ]
            });

            foreach (var file in pdfFiles.Where(file => file.Path.IsFile))
            {
                viewModel.Sidebar.AddDocument(Uri.UnescapeDataString(file.Path.LocalPath));
            }
        }
    }
}
``

## MiniZotero/Views/NotePreviewPanelView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:models="using:MiniZotero.Models"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.NotePreviewPanelView"
             x:Name="Root"
             x:DataType="vm:NotePreviewPanelViewModel">

    <UserControl.Styles>
        <Style Selector="Border.PanelCard">
            <Setter Property="Background" Value="#FFFFFF"/>
            <Setter Property="BorderBrush" Value="#D5DDE7"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="8"/>
        </Style>
        <Style Selector="Button.PanelIconButton">
            <Setter Property="Width" Value="28"/>
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#64748B"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="Button.PanelIconButton:pointerover">
            <Setter Property="Background" Value="#F1F5F9"/>
        </Style>
        <Style Selector="Border.PanelZoomChip">
            <Setter Property="Background" Value="#F8FAFC"/>
            <Setter Property="BorderBrush" Value="#D5DDE7"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Height" Value="28"/>
            <Setter Property="MinWidth" Value="50"/>
            <Setter Property="Padding" Value="9,0"/>
        </Style>
        <Style Selector="Button.ExportButton">
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="10,0"/>
            <Setter Property="Background" Value="#F8FAFC"/>
            <Setter Property="BorderBrush" Value="#D5DDE7"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Foreground" Value="#334155"/>
            <Setter Property="FontSize" Value="12"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="Button.ExportButton:pointerover">
            <Setter Property="Background" Value="#F1F5F9"/>
        </Style>
        <Style Selector="Button.FormatButton">
            <Setter Property="Width" Value="27"/>
            <Setter Property="Height" Value="27"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="5"/>
            <Setter Property="Foreground" Value="#64748B"/>
            <Setter Property="FontSize" Value="12"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="Button.FormatButton:pointerover">
            <Setter Property="Background" Value="#F1F5F9"/>
        </Style>
    </UserControl.Styles>

    <Grid Background="#E6EBF2" RowDefinitions="280,6,*">
        <Border Grid.Row="0" Classes="PanelCard" Margin="8,8,8,0">
            <Grid RowDefinitions="42,34,*">
                <Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto" Margin="12,0,10,0">
                    <TextBlock Text="&#xE734;"
                               FontFamily="Segoe MDL2 Assets"
                               Foreground="#64748B"
                               FontSize="14"
                               VerticalAlignment="Center"/>
                    <TextBlock Grid.Column="1"
                               Text="Note taking"
                               Foreground="#111827"
                               FontWeight="SemiBold"
                               Margin="9,0,0,0"
                               VerticalAlignment="Center"/>
                    <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="5" VerticalAlignment="Center">
                        <Border Classes="PanelZoomChip">
                            <TextBlock Text="100%" Foreground="#334155" FontSize="12" TextAlignment="Center" VerticalAlignment="Center"/>
                        </Border>
                        <Button Classes="PanelIconButton" Content="&#xE738;"/>
                        <Button Classes="PanelIconButton" Content="&#xE710;"/>
                        <Button Classes="PanelIconButton" Content="&#xE8A7;"/>
                        <Button Classes="ExportButton"
                                Content="Export"
                                Click="OnExportMarkdownClicked"
                                IsVisible="{Binding HasDocument}"/>
                        <Button Classes="PanelIconButton" Content="&#xE713;"/>
                    </StackPanel>
                </Grid>

                <Border Grid.Row="1"
                        BorderBrush="#E5EAF0"
                        BorderThickness="0,1,0,1"
                        Padding="12,0">
                    <StackPanel Orientation="Horizontal" Spacing="3" VerticalAlignment="Center">
                        <Button Classes="FormatButton" Content="H"/>
                        <Button Classes="FormatButton" Content="B" FontWeight="Bold"/>
                        <Button Classes="FormatButton" Content="I" FontStyle="Italic"/>
                        <Button Classes="FormatButton" Content="&#xE943;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8FD;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8FD;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE9D5;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8B0;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE7C3;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE8A5;" FontFamily="Segoe MDL2 Assets"/>
                        <Button Classes="FormatButton" Content="&#xE80A;" FontFamily="Segoe MDL2 Assets"/>
                    </StackPanel>
                </Border>

                <Grid Grid.Row="2">
                    <TextBox Text="{Binding NoteText, Mode=TwoWay}"
                             AcceptsReturn="True"
                             TextWrapping="Wrap"
                             Background="White"
                             Foreground="#111827"
                             BorderThickness="0"
                             Padding="16"
                             FontSize="13"
                             PlaceholderText="Ghi chú nhanh bằng Markdown..."
                             IsVisible="{Binding HasDocument}"/>

                    <StackPanel IsVisible="{Binding IsEmptyViewVisible}"
                                HorizontalAlignment="Center"
                                VerticalAlignment="Center"
                                Spacing="8"
                                Width="280">
                        <TextBlock Text="No note selected"
                                   Foreground="#111827"
                                   FontSize="16"
                                   FontWeight="SemiBold"
                                   HorizontalAlignment="Center"/>
                        <TextBlock Text="Select a document to create notes."
                                   Foreground="#7C8A9E"
                                   FontSize="13"
                                   TextAlignment="Center"/>
                    </StackPanel>
                </Grid>
            </Grid>
        </Border>

        <Border Grid.Row="1"
                Width="30"
                Height="14"
                CornerRadius="4"
                Background="#FFFFFF"
                BorderBrush="#D5DDE7"
                BorderThickness="1"
                HorizontalAlignment="Center"
                VerticalAlignment="Center">
            <TextBlock Text="::::"
                       Foreground="#64748B"
                       FontSize="11"
                       HorizontalAlignment="Center"
                       VerticalAlignment="Center"
                       Margin="0,-2,0,0"/>
        </Border>

        <Border Grid.Row="2" Classes="PanelCard" Margin="8,0,8,8">
            <Grid RowDefinitions="42,*">
                <Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto" Margin="12,0,10,0">
                    <TextBlock Text="&#xE8A5;"
                               FontFamily="Segoe MDL2 Assets"
                               Foreground="#64748B"
                               FontSize="14"
                               VerticalAlignment="Center"/>
                    <TextBlock Grid.Column="1"
                               Text="Preview"
                               Foreground="#111827"
                               FontWeight="SemiBold"
                               FontSize="12"
                               Margin="9,0,0,0"
                               VerticalAlignment="Center"/>
                    <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="5" VerticalAlignment="Center">
                        <Border Classes="PanelZoomChip">
                            <TextBlock Text="100%" Foreground="#334155" FontSize="12" TextAlignment="Center" VerticalAlignment="Center"/>
                        </Border>
                        <Button Classes="PanelIconButton" Content="&#xE738;"/>
                        <Button Classes="PanelIconButton" Content="&#xE710;"/>
                        <Button Classes="PanelIconButton" Content="&#xE713;"/>
                    </StackPanel>
                </Grid>

                <Border Grid.Row="1"
                        BorderBrush="#E5EAF0"
                        BorderThickness="0,1,0,0"
                        Padding="16">
                    <Grid>
                        <StackPanel IsVisible="{Binding IsEmptyViewVisible}"
                                    HorizontalAlignment="Center"
                                    VerticalAlignment="Center"
                                    Spacing="8"
                                    Width="300">
                            <TextBlock Text="No highlights"
                                       Foreground="#111827"
                                       FontSize="16"
                                       FontWeight="SemiBold"
                                       HorizontalAlignment="Center"/>
                            <TextBlock Text="Highlights will appear here after reading a document."
                                       Foreground="#7C8A9E"
                                       FontSize="13"
                                       TextWrapping="Wrap"
                                       TextAlignment="Center"/>
                        </StackPanel>

                        <StackPanel IsVisible="{Binding IsHighlightEmptyViewVisible}"
                                    HorizontalAlignment="Center"
                                    VerticalAlignment="Center"
                                    Spacing="8"
                                    Width="300">
                            <TextBlock Text="No highlights"
                                       Foreground="#111827"
                                       FontSize="16"
                                       FontWeight="SemiBold"
                                       HorizontalAlignment="Center"/>
                            <TextBlock Text="Highlights will appear here after reading a document."
                                       Foreground="#7C8A9E"
                                       FontSize="13"
                                       TextWrapping="Wrap"
                                       TextAlignment="Center"/>
                        </StackPanel>

                        <ScrollViewer IsVisible="{Binding HasHighlights}">
                            <ItemsControl ItemsSource="{Binding Highlights}">
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate x:DataType="models:HighlightItem">
                                        <Border Padding="10"
                                                Margin="0,0,0,8"
                                                CornerRadius="8"
                                                Background="#FFF7CC"
                                                BorderBrush="#EAB308"
                                                BorderThickness="1">
                                            <Grid ColumnDefinitions="*,Auto" RowDefinitions="Auto,Auto">
                                                <Button Grid.Row="0"
                                                        Grid.Column="0"
                                                        Command="{Binding #Root.DataContext.SelectHighlightCommand}"
                                                        CommandParameter="{Binding}"
                                                        Background="Transparent"
                                                        BorderThickness="0"
                                                        Padding="0"
                                                        HorizontalAlignment="Stretch"
                                                        HorizontalContentAlignment="Stretch">
                                                    <TextBlock Text="{Binding Text}"
                                                               TextWrapping="Wrap"
                                                               MaxLines="4"
                                                               FontSize="12"/>
                                                </Button>

                                                <Button Grid.Row="0"
                                                        Grid.Column="1"
                                                        Classes="PanelIconButton"
                                                        Content="&#xE74D;"
                                                        Width="24"
                                                        Height="24"
                                                        Padding="0"
                                                        Margin="8,0,0,0"
                                                        FontSize="12"
                                                        Command="{Binding #Root.DataContext.DeleteHighlightCommand}"
                                                        CommandParameter="{Binding}"/>

                                                <TextBlock Grid.Row="1"
                                                           Grid.Column="0"
                                                           Grid.ColumnSpan="2"
                                                           Text="{Binding PageNumber, StringFormat='Page {0}'}"
                                                           FontSize="11"
                                                           Opacity="0.65"
                                                           Margin="0,6,0,0"/>
                                            </Grid>
                                        </Border>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </ScrollViewer>
                    </Grid>
                </Border>
            </Grid>
        </Border>
    </Grid>
</UserControl>
``

## MiniZotero/Views/NotePreviewPanelView.axaml.cs

``csharp
using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class NotePreviewPanelView : UserControl
    {
        public NotePreviewPanelView()
        {
            InitializeComponent();
        }

        private async void OnExportMarkdownClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);

            if (topLevel is null || DataContext is not NotePreviewPanelViewModel viewModel)
            {
                return;
            }

            var documentTitle = viewModel.ActiveDocument?.Title ?? "MiniZotero Notes";
            var safeFileName = MakeSafeFileName(documentTitle);

            var file = await topLevel.StorageProvider.SaveFilePickerAsync(
                new FilePickerSaveOptions
                {
                    Title = "Export notes and highlights",
                    SuggestedFileName = $"{safeFileName}.md",
                    FileTypeChoices =
                    [
                        new FilePickerFileType("Markdown")
                        {
                            Patterns = ["*.md"],
                            MimeTypes = ["text/markdown", "text/plain"]
                        }
                    ]
                });

            if (file is null)
            {
                return;
            }

            var outputPath = Uri.UnescapeDataString(file.Path.LocalPath);

            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return;
            }

            viewModel.ExportActiveDocumentToMarkdown(outputPath);
        }

        private static string MakeSafeFileName(string value)
        {
            var invalidCharacters = System.IO.Path.GetInvalidFileNameChars();

            var safe = new string(value
                .Select(character => invalidCharacters.Contains(character) ? '_' : character)
                .ToArray());

            return string.IsNullOrWhiteSpace(safe)
                ? "MiniZotero Notes"
                : safe.Trim();
        }
    }
}
``

## MiniZotero/Views/PdfViewerView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.PdfViewerView"
             x:DataType="vm:PdfViewerViewModel">

    <Grid Background="#E6EBF2">
        <Border Background="#F8FAFC"
                BorderBrush="#D5DDE7"
                BorderThickness="1"
                CornerRadius="8"
                Margin="20"
                IsVisible="{Binding IsEmptyViewVisible}">
            <StackPanel HorizontalAlignment="Center"
                        VerticalAlignment="Center"
                        Spacing="8"
                        Width="360">
                <TextBlock Text="{Binding EmptyTitle}"
                           Foreground="#172033"
                           FontSize="18"
                           FontWeight="SemiBold"
                           HorizontalAlignment="Center"/>
                <TextBlock Text="{Binding EmptyMessage}"
                           Foreground="#7C8A9E"
                           FontSize="13"
                           TextWrapping="Wrap"
                           TextAlignment="Center"/>
            </StackPanel>
        </Border>

        <Grid IsVisible="{Binding HasDocumentLoaded}" RowDefinitions="*,28">
            <Border Grid.Row="0"
                    Background="#E6EBF2">
                <NativeWebView x:Name="PdfWebView"
                               Source="{Binding ViewerSource}"
                               WebMessageReceived="OnPdfWebViewMessageReceived"/>
            </Border>

            <Border Grid.Row="1"
                    Background="#F8FAFC"
                    BorderBrush="#D5DDE7"
                    BorderThickness="0,1,0,0"
                    Padding="12,0">
                <Grid ColumnDefinitions="Auto,*,Auto">
                    <TextBlock Text="File"
                               Foreground="#94A3B8"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                    <TextBlock Grid.Column="1"
                               Text="{Binding DocumentPath}"
                               Foreground="#64748B"
                               FontSize="11"
                               Margin="8,0"
                               VerticalAlignment="Center"
                               TextTrimming="CharacterEllipsis"/>
                    <TextBlock Grid.Column="2"
                               Text="{Binding StatusText}"
                               Foreground="#64748B"
                               FontSize="11"
                               VerticalAlignment="Center"/>
                </Grid>
            </Border>
        </Grid>
    </Grid>
</UserControl>
``

## MiniZotero/Views/PdfViewerView.axaml.cs

``csharp
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Avalonia.Controls;
using MiniZotero.Models;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class PdfViewerView : UserControl
    {
        public PdfViewerView()
        {
            InitializeComponent();
            DataContextChanged += OnDataContextChanged;
        }

        private PdfViewerViewModel? BoundViewModel { get; set; }

        private void OnDataContextChanged(object? sender, System.EventArgs e)
        {
            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged -= OnViewModelPropertyChanged;
                BoundViewModel.ScriptRequested -= OnScriptRequested;
            }

            BoundViewModel = DataContext as PdfViewerViewModel;

            if (BoundViewModel is not null)
            {
                BoundViewModel.PropertyChanged += OnViewModelPropertyChanged;
                BoundViewModel.ScriptRequested += OnScriptRequested;
                ApplyToolMode(BoundViewModel.ToolMode);
            }
        }

        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PdfViewerViewModel.ToolMode) &&
                BoundViewModel is not null)
            {
                ApplyToolMode(BoundViewModel.ToolMode);
            }
        }

        private void OnScriptRequested(string script)
        {
            try
            {
                _ = PdfWebView.InvokeScript(script);
            }
            catch
            {
            }
        }

        private void ApplyToolMode(string toolMode)
        {
            try
            {
                _ = PdfWebView.InvokeScript(
                    $"window.miniZoteroPdf?.setToolMode?.('{toolMode}');"
                );
            }
            catch
            {
            }
        }

        private void OnPdfWebViewMessageReceived(
            object? sender,
            WebMessageReceivedEventArgs e
        )
        {
            if (DataContext is not PdfViewerViewModel viewModel)
            {
                return;
            }

            try
            {
                if (string.IsNullOrWhiteSpace(e.Body))
                {
                    return;
                }

                PdfViewerMessage? message =
                    JsonSerializer.Deserialize<PdfViewerMessage>(
                        e.Body,
                        new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        }
                    );

                if (message is null)
                {
                    return;
                }

                if (message.Type == "highlightCreated")
                {
                    viewModel.AddHighlightFromViewer(
                        message.Text ?? string.Empty,
                        message.PageNumber,
                        message.Rects ?? []);

                    return;
                }

                viewModel.UpdateReadingStateFromViewer(
                    message.PageNumber,
                    message.ZoomPercent
                );

                if (message.Type == "loaded")
                {
                    ApplyToolMode(viewModel.ToolMode);
                    viewModel.SendHighlightsToViewer();
                }
            }
            catch
            {
            }
        }

        private sealed class PdfViewerMessage
        {
            [JsonPropertyName("type")]
            public string? Type { get; set; }

            [JsonPropertyName("pageNumber")]
            public int PageNumber { get; set; }

            [JsonPropertyName("zoomPercent")]
            public int ZoomPercent { get; set; }

            [JsonPropertyName("text")]
            public string? Text { get; set; }

            [JsonPropertyName("rects")]
            public List<HighlightRect>? Rects { get; set; }
        }
    }
}
``

## MiniZotero/Views/SidebarView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:converters="using:MiniZotero.Converters"
             xmlns:models="using:MiniZotero.Models"
             xmlns:sys="clr-namespace:System;assembly=System.Runtime"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.SidebarView"
             x:Name="Root"
             x:DataType="vm:SidebarViewModel">

    <UserControl.Resources>
        <converters:StarredBrushConverter x:Key="StarredBrushConverter"/>
    </UserControl.Resources>

    <UserControl.Styles>
        <Style Selector="Button.SidebarIconButton">
            <Setter Property="Width" Value="28"/>
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#AAB6C6"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="Button.SidebarIconButton:pointerover">
            <Setter Property="Background" Value="#273242"/>
        </Style>
        <Style Selector="Button.DocumentActionButton">
            <Setter Property="Height" Value="28"/>
            <Setter Property="Padding" Value="9,0"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="Background" Value="#182231"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="5"/>
            <Setter Property="Foreground" Value="#D7DEE8"/>
            <Setter Property="FontSize" Value="12"/>
        </Style>
        <Style Selector="Button.DocumentActionButton:pointerover">
            <Setter Property="Background" Value="#243246"/>
        </Style>
        <Style Selector="TextBlock.SectionTitle">
            <Setter Property="Foreground" Value="#8795A8"/>
            <Setter Property="FontSize" Value="10"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
        </Style>
        <Style Selector="TextBlock.Muted">
            <Setter Property="Foreground" Value="#8D9AAB"/>
        </Style>
        <Style Selector="Border.NavItem">
            <Setter Property="Height" Value="31"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Padding" Value="10,0"/>
        </Style>
        <Style Selector="Border.NavItem.Active">
            <Setter Property="Background" Value="#263242"/>
        </Style>
        <Style Selector="Border.TagChip">
            <Setter Property="Background" Value="#202B39"/>
            <Setter Property="CornerRadius" Value="5"/>
            <Setter Property="Padding" Value="9,4"/>
            <Setter Property="Margin" Value="0,0,6,6"/>
        </Style>
        <Style Selector="ListBox.NavigationList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,0,4"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#263242"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.NavigationList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#263242"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="ListBox.DocumentList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.DocumentList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,0,4"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#1C2633"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.SmartCollectionList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="Padding" Value="0"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem">
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Margin" Value="0,0,6,6"/>
            <Setter Property="Background" Value="Transparent"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem /template/ ContentPresenter">
            <Setter Property="Background" Value="#202B39"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#2A3646"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem:selected /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
        <Style Selector="ListBox.TagList ListBoxItem:selected:pointerover /template/ ContentPresenter">
            <Setter Property="Background" Value="#5D2CCB"/>
            <Setter Property="CornerRadius" Value="5"/>
        </Style>
    </UserControl.Styles>

    <Border Background="#0E151E"
            BorderBrush="#1E2937"
            BorderThickness="0,0,1,0">
        <Grid RowDefinitions="48,*,Auto" Margin="12,0,12,10">
            <Grid Grid.Row="0" ColumnDefinitions="Auto,*,Auto">
                <Border Width="22" Height="22" CornerRadius="5" Background="#745CFF" VerticalAlignment="Center">
                    <TextBlock Text="M"
                               Foreground="White"
                               FontSize="13"
                               FontWeight="Bold"
                               HorizontalAlignment="Center"
                               VerticalAlignment="Center"/>
                </Border>
                <TextBlock Grid.Column="1"
                           Text="MiniZotero"
                           Foreground="#F2F6FC"
                           FontWeight="SemiBold"
                           Margin="8,0,0,0"
                           VerticalAlignment="Center"/>
                <Button Grid.Column="2"
                        Classes="SidebarIconButton"
                        Content="&#xE10C;"
                        Click="OnImportPdfClicked"/>
            </Grid>

            <ScrollViewer Grid.Row="1" VerticalScrollBarVisibility="Hidden">
                <StackPanel Spacing="0">
                    <ListBox Classes="NavigationList"
                             ItemsSource="{Binding NavigationItems}"
                             SelectedItem="{Binding SelectedNavigationItem, Mode=TwoWay}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="vm:SidebarNavigationItem">
                                <Grid Height="31" ColumnDefinitions="Auto,*,Auto" Margin="10,0">
                                    <TextBlock Text="{Binding Icon}"
                                               FontFamily="Segoe MDL2 Assets"
                                               Foreground="#B2BECD"
                                               FontSize="14"
                                               VerticalAlignment="Center"/>
                                    <TextBlock Grid.Column="1"
                                               Text="{Binding Name}"
                                               Foreground="#F2F6FC"
                                               FontSize="12"
                                               FontWeight="SemiBold"
                                               Margin="9,0,0,0"
                                               VerticalAlignment="Center"/>
                                    <TextBlock Grid.Column="2"
                                               Text="{Binding CountText}"
                                               Foreground="#B7C2D1"
                                               FontSize="11"
                                               VerticalAlignment="Center"/>
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <Grid ColumnDefinitions="*,Auto" Margin="4,22,4,8">
                        <TextBlock Text="SMART COLLECTIONS" Classes="SectionTitle"/>
                        <TextBlock Grid.Column="1" Text="+" Foreground="#B9C4D3" FontSize="16" VerticalAlignment="Center"/>
                    </Grid>

                    <ListBox Classes="SmartCollectionList"
                             ItemsSource="{Binding SmartCollections}"
                             SelectedItem="{Binding SelectedSmartCollection, Mode=TwoWay}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="vm:SmartCollectionItem">
                                <Grid Height="25" ColumnDefinitions="Auto,*,Auto" Margin="8,0" VerticalAlignment="Center">
                                    <TextBlock Text="{Binding Icon}"
                                               FontFamily="Segoe MDL2 Assets"
                                               Foreground="{Binding IconColor}"
                                               FontSize="13"
                                               VerticalAlignment="Center"/>
                                    <TextBlock Grid.Column="1"
                                               Text="{Binding Name}"
                                               Foreground="#F2F6FC"
                                               FontSize="12"
                                               Margin="8,0,0,0"
                                               VerticalAlignment="Center"
                                               TextTrimming="CharacterEllipsis"/>
                                    <TextBlock Grid.Column="2"
                                               Text="{Binding Count}"
                                               Foreground="#D9DFF0"
                                               FontSize="11"
                                               VerticalAlignment="Center"/>
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <Grid Height="25" ColumnDefinitions="Auto,*" Margin="17,1,0,0">
                        <TextBlock Text="+" Foreground="#C2CAD8" FontSize="16" VerticalAlignment="Center"/>
                        <TextBlock Grid.Column="1" Text="New Collection" Foreground="#C2CAD8" FontSize="12" Margin="9,0,0,0" VerticalAlignment="Center"/>
                    </Grid>

                    <Grid IsVisible="{Binding HasDocuments}" RowDefinitions="Auto,*" Margin="0,14,0,0">
                        <Grid ColumnDefinitions="*,Auto" Margin="4,0,4,8">
                            <TextBlock Text="{Binding CurrentDocumentSectionTitle}" Classes="SectionTitle"/>
                            <TextBlock Grid.Column="1" Text="{Binding DocumentCount}" Foreground="#9EABBB" FontSize="11"/>
                        </Grid>

                        <ListBox Grid.Row="1"
                                 Classes="DocumentList"
                                 ItemsSource="{Binding DocumentExplorerItems}"
                                 IsVisible="{Binding HasVisibleDocuments}"
                                 SelectedItem="{Binding SelectedExplorerItem, Mode=TwoWay}">
                            <ListBox.ItemTemplate>
                                <DataTemplate x:DataType="vm:DocumentExplorerItem">
                                    <Border Padding="2,0">
                                        <Grid Height="24" ColumnDefinitions="Auto,Auto,*,Auto">
                                            <Button Classes="SidebarIconButton"
                                                    Content="{Binding ChevronIcon}"
                                                    Width="24"
                                                    Height="24"
                                                    Padding="0"
                                                    Margin="0,1,0,0"
                                                    FontSize="8"
                                                    HorizontalContentAlignment="Center"
                                                    VerticalContentAlignment="Center"
                                                    Command="{Binding #Root.DataContext.ToggleFolderCommand}"
                                                    CommandParameter="{Binding}"
                                                    IsVisible="{Binding IsFolder}"/>
                                            <Border Width="24"
                                                       IsVisible="{Binding IsDocument}"/>

                                            <Grid Grid.Column="1"
                                                  Width="20"
                                                  Margin="0,0,5,0"
                                                  VerticalAlignment="Center">
                                                <TextBlock Text="{Binding Icon}"
                                                           FontFamily="Segoe MDL2 Assets"
                                                           Foreground="{Binding IconForeground}"
                                                           FontSize="{Binding IconFontSize}"
                                                           VerticalAlignment="Center"
                                                           IsVisible="{Binding IsFolder}"/>

                                                <Canvas Width="16"
                                                        Height="16"
                                                        VerticalAlignment="Center"
                                                        IsVisible="{Binding IsDocument}">
                                                    <Path Stroke="#EF4444"
                                                          StrokeThickness="1.35"
                                                          StrokeLineCap="Round"
                                                          Fill="Transparent"
                                                          Data="M4,2.5 L9.6,2.5 L12.5,5.4 L12.5,13.5 L4,13.5 Z"/>
                                                    <Path Stroke="#EF4444"
                                                          StrokeThickness="1.35"
                                                          StrokeLineCap="Round"
                                                          Data="M9.6,2.5 L9.6,5.4 L12.5,5.4"/>
                                                </Canvas>
                                            </Grid>

                                            <TextBlock Grid.Column="2"
                                                       Text="{Binding Name}"
                                                       Foreground="{Binding NameForeground}"
                                                       FontWeight="{Binding NameFontWeight}"
                                                       FontSize="12"
                                                       VerticalAlignment="Center"
                                                       TextTrimming="CharacterEllipsis"/>

                                            <TextBlock Grid.Column="3"
                                                       Text="{Binding Count}"
                                                       Foreground="#9EABBB"
                                                       FontSize="11"
                                                       Margin="8,0,4,0"
                                                       VerticalAlignment="Center"
                                                       IsVisible="{Binding IsFolder}"/>

                                            <Button Grid.Column="3"
                                                    Classes="SidebarIconButton"
                                                    Content="&#xE734;"
                                                    Width="24"
                                                    Height="24"
                                                    Foreground="{Binding IsStarred, Converter={StaticResource StarredBrushConverter}}"
                                                    Command="{Binding #Root.DataContext.ToggleStarCommand}"
                                                    CommandParameter="{Binding Document}"
                                                    IsVisible="{Binding IsStarButtonVisible}"/>
                                        </Grid>
                                    </Border>
                                </DataTemplate>
                            </ListBox.ItemTemplate>
                        </ListBox>
                    </Grid>

                    <StackPanel Spacing="6"
                                Margin="4,10,4,0"
                                IsVisible="{Binding HasSelectedDocument}">
                        <Button Classes="DocumentActionButton"
                                Command="{Binding MoveSelectedDocumentToTrashCommand}"
                                IsVisible="{Binding IsMoveToTrashVisible}">
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <TextBlock Text="&#xE74D;"
                                           FontFamily="Segoe MDL2 Assets"
                                           FontSize="12"
                                           VerticalAlignment="Center"/>
                                <TextBlock Text="Move to Trash"
                                           VerticalAlignment="Center"/>
                            </StackPanel>
                        </Button>

                        <Button Classes="DocumentActionButton"
                                Command="{Binding RestoreSelectedDocumentCommand}"
                                IsVisible="{Binding IsTrashDocumentActionsVisible}">
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <TextBlock Text="&#xE845;"
                                           FontFamily="Segoe MDL2 Assets"
                                           FontSize="12"
                                           VerticalAlignment="Center"/>
                                <TextBlock Text="Restore"
                                           VerticalAlignment="Center"/>
                            </StackPanel>
                        </Button>

                        <Button Classes="DocumentActionButton"
                                Command="{Binding DeleteSelectedDocumentForeverCommand}"
                                IsVisible="{Binding IsTrashDocumentActionsVisible}">
                            <StackPanel Orientation="Horizontal" Spacing="8">
                                <TextBlock Text="&#xE107;"
                                           FontFamily="Segoe MDL2 Assets"
                                           FontSize="12"
                                           VerticalAlignment="Center"/>
                                <TextBlock Text="Delete Forever"
                                           VerticalAlignment="Center"/>
                            </StackPanel>
                        </Button>
                    </StackPanel>

                    <Grid ColumnDefinitions="*,Auto" Margin="4,18,4,8">
                        <TextBlock Text="TAGS" Classes="SectionTitle"/>
                        <TextBlock Grid.Column="1" Text="+" Foreground="#B9C4D3" FontSize="16" VerticalAlignment="Center"/>
                    </Grid>

                    <ListBox Classes="TagList"
                             ItemsSource="{Binding Tags}"
                             SelectedItem="{Binding SelectedTag, Mode=TwoWay}"
                             Margin="4,0,0,0">
                        <ListBox.ItemsPanel>
                            <ItemsPanelTemplate>
                                <WrapPanel/>
                            </ItemsPanelTemplate>
                        </ListBox.ItemsPanel>
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="vm:TagItem">
                                <Border Classes="TagChip">
                                    <StackPanel Orientation="Horizontal" Spacing="7">
                                        <TextBlock Text="{Binding Name}"
                                                   Foreground="#E5ECF5"
                                                   FontSize="11"/>
                                        <TextBlock Text="{Binding CountText}"
                                                   Foreground="#A9B6C7"
                                                   FontSize="11"/>
                                    </StackPanel>
                                </Border>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>

                    <Border Margin="4,12,4,0"
                            Padding="8"
                            CornerRadius="8"
                            Background="#111B27"
                            IsVisible="{Binding IsTagEditorVisible}">
                        <StackPanel Spacing="6">
                            <TextBlock Text="ADD TAG TO SELECTED PDF"
                                       Classes="SectionTitle"/>

                            <Grid ColumnDefinitions="*,Auto">
                                <TextBox Grid.Column="0"
                                         Text="{Binding NewTagText, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"
                                         PlaceholderText="e.g. OOP, CMOS, Paper"
                                         Height="30"
                                         FontSize="12"
                                         VerticalContentAlignment="Center"/>

                                <Button Grid.Column="1"
                                        Content="+"
                                        Width="32"
                                        Height="30"
                                        Margin="6,0,0,0"
                                        Command="{Binding AddTagToSelectedDocumentCommand}"/>
                            </Grid>

                            <ItemsControl ItemsSource="{Binding SelectedDocument.Tags}">
                                <ItemsControl.ItemsPanel>
                                    <ItemsPanelTemplate>
                                        <WrapPanel/>
                                    </ItemsPanelTemplate>
                                </ItemsControl.ItemsPanel>
                                <ItemsControl.ItemTemplate>
                                    <DataTemplate x:DataType="sys:String">
                                        <Border Classes="TagChip">
                                            <StackPanel Orientation="Horizontal" Spacing="6">
                                                <TextBlock Text="{Binding}"
                                                           Foreground="#E5ECF5"
                                                           FontSize="11"/>
                                                <Button Classes="SidebarIconButton"
                                                        Content="&#xE711;"
                                                        Width="18"
                                                        Height="18"
                                                        FontSize="8"
                                                        Command="{Binding #Root.DataContext.RemoveTagFromSelectedDocumentCommand}"
                                                        CommandParameter="{Binding}"/>
                                            </StackPanel>
                                        </Border>
                                    </DataTemplate>
                                </ItemsControl.ItemTemplate>
                            </ItemsControl>
                        </StackPanel>
                    </Border>
                </StackPanel>
            </ScrollViewer>

            <StackPanel Grid.Row="2" Spacing="10">
                <Border Background="#1C2633" CornerRadius="7" Padding="10">
                    <Grid RowDefinitions="Auto,Auto" ColumnDefinitions="Auto,*,Auto">
                        <TextBlock Text="&#xE8F1;" FontFamily="Segoe MDL2 Assets" Foreground="#D7DEE8" FontSize="13" VerticalAlignment="Center"/>
                        <StackPanel Grid.Column="1" Orientation="Horizontal" Spacing="4" Margin="8,0,0,0" VerticalAlignment="Center">
                            <TextBlock Text="Watch Folder" Foreground="#E8EDF4" FontSize="12" FontWeight="SemiBold"/>
                            <Ellipse Width="5" Height="5" Fill="#24E38C" VerticalAlignment="Center"/>
                        </StackPanel>
                        <Button Grid.Column="2"
                                Classes="SidebarIconButton"
                                Width="24"
                                Height="24"
                                Content="&#xE713;"
                                Click="OnConfigureWatchFolderClicked"/>
                        <TextBlock Grid.Row="1"
                                   Grid.Column="0"
                                   Grid.ColumnSpan="3"
                                   Text="{Binding WatchFolderStatusText}"
                                   Foreground="#9EABBB"
                                   FontSize="11"
                                   Margin="0,9,0,0"/>
                    </Grid>
                </Border>

                <Grid RowDefinitions="4,Auto">
                    <Border Background="#303B4A" CornerRadius="2" Height="4">
                        <Border Background="#8B5CF6" CornerRadius="2" HorizontalAlignment="Left" Width="65"/>
                    </Border>
                    <TextBlock Grid.Row="1" Text="{Binding StorageUsageText}" Foreground="#8D9AAB" FontSize="10" Margin="0,8,0,0"/>
                </Grid>
            </StackPanel>
        </Grid>
    </Border>
</UserControl>
``

## MiniZotero/Views/SidebarView.axaml.cs

``csharp
using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class SidebarView : UserControl
    {
        public SidebarView()
        {
            InitializeComponent();
        }

        private async void OnImportPdfClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null || DataContext is not SidebarViewModel viewModel)
            {
                return;
            }

            var pdfFiles = await topLevel.StorageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Import PDF",
                AllowMultiple = true,
                FileTypeFilter =
                [
                    new FilePickerFileType("PDF documents")
                    {
                        Patterns = ["*.pdf"],
                        MimeTypes = ["application/pdf"]
                    }
                ]
            });

            foreach (var file in pdfFiles.Where(file => file.Path.IsFile))
            {
                viewModel.AddDocument(Uri.UnescapeDataString(file.Path.LocalPath));
            }
        }

        private async void OnConfigureWatchFolderClicked(object? sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel is null || DataContext is not SidebarViewModel viewModel)
            {
                return;
            }

            var folders = await topLevel.StorageProvider.OpenFolderPickerAsync(
                new FolderPickerOpenOptions
                {
                    Title = "Choose Watch Folder",
                    AllowMultiple = false
                });

            var folder = folders.FirstOrDefault();
            var folderPath = folder is null
                ? string.Empty
                : Uri.UnescapeDataString(folder.Path.LocalPath);

            if (!string.IsNullOrWhiteSpace(folderPath))
            {
                viewModel.SetWatchFolder(folderPath);
            }
        }
    }
}
``

## MiniZotero/Views/TabWorkspaceView.axaml

``xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:views="using:MiniZotero.Views"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.TabWorkspaceView"
             x:DataType="vm:TabWorkspaceViewModel">

    <UserControl.Styles>
        <Style Selector="Button.ToolButton">
            <Setter Property="Width" Value="30"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#64748B"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="Button.ToolButton:pointerover">
            <Setter Property="Background" Value="#EEF2F7"/>
        </Style>
        <Style Selector="Border.ZoomChip">
            <Setter Property="Background" Value="#F2F5F9"/>
            <Setter Property="BorderBrush" Value="#D5DDE7"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Height" Value="30"/>
            <Setter Property="MinWidth" Value="68"/>
            <Setter Property="Padding" Value="9,0"/>
        </Style>
        <Style Selector="Button.RailButton">
            <Setter Property="Width" Value="34"/>
            <Setter Property="Height" Value="34"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="7"/>
            <Setter Property="FontFamily" Value="Segoe MDL2 Assets"/>
            <Setter Property="Foreground" Value="#64748B"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="Button.RailButton:pointerover">
            <Setter Property="Background" Value="#EEF2F7"/>
        </Style>
        <Style Selector="Button.RailButton.Active">
            <Setter Property="Background" Value="#FFF7CC"/>
            <Setter Property="Foreground" Value="#B68A00"/>
        </Style>
        <Style Selector="ToggleButton.RailButton">
            <Setter Property="Width" Value="34"/>
            <Setter Property="Height" Value="34"/>
            <Setter Property="Padding" Value="0"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
            <Setter Property="CornerRadius" Value="7"/>
            <Setter Property="Foreground" Value="#64748B"/>
            <Setter Property="HorizontalContentAlignment" Value="Center"/>
            <Setter Property="VerticalContentAlignment" Value="Center"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:pointerover">
            <Setter Property="Background" Value="#EEF2F7"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:checked">
            <Setter Property="Background" Value="#E8EEF6"/>
            <Setter Property="Foreground" Value="#475569"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:checked:pointerover">
            <Setter Property="Background" Value="#E8EEF6"/>
            <Setter Property="Foreground" Value="#475569"/>
        </Style>
        <Style Selector="ToggleButton.RailButton:checked:pressed">
            <Setter Property="Background" Value="#DDE5EF"/>
            <Setter Property="Foreground" Value="#475569"/>
        </Style>
    </UserControl.Styles>

    <Grid Background="#E6EBF2" RowDefinitions="44,*" ColumnDefinitions="42,*">
        <Border Grid.Row="0"
                Grid.Column="0"
                Grid.ColumnSpan="2"
                Background="#FAFBFD"
                BorderBrush="#D5DDE7"
                BorderThickness="0,0,1,1">
            <Grid ColumnDefinitions="Auto,*,Auto" Margin="7,0,10,0">
                <StackPanel Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                    <Button Classes="ToolButton" Content="&#xE72B;"/>
                    <TextBlock Text="{Binding PdfViewer.CurrentPage}"
                               Foreground="#172033"
                               FontWeight="SemiBold"
                               FontSize="12"
                               VerticalAlignment="Center"
                               MinWidth="24"
                               TextAlignment="Center"/>
                    <TextBlock Text="/"
                               Foreground="#94A3B8"
                               FontSize="12"
                               VerticalAlignment="Center"/>
                    <TextBlock Text="--"
                               Foreground="#94A3B8"
                               FontSize="12"
                               VerticalAlignment="Center"/>
                    <Button Classes="ToolButton" Content="&#xE72A;"/>

                    <Border Width="1" Height="20" Background="#D5DDE7" Margin="4,0"/>

                    <Button Classes="ToolButton" Content="&#xE710;"/>
                    <Button Classes="ToolButton" Content="&#xE738;"/>
                    <Border Classes="ZoomChip">
                        <StackPanel Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                            <TextBlock Text="{Binding PdfViewer.ZoomPercent, StringFormat='{}{0}%'}"
                                       Foreground="#334155"
                                       FontSize="12"
                                       MinWidth="35"
                                       TextAlignment="Center"
                                       VerticalAlignment="Center"/>
                            <TextBlock Text="&#xE70D;" FontFamily="Segoe MDL2 Assets" Foreground="#94A3B8" FontSize="9" VerticalAlignment="Center"/>
                        </StackPanel>
                    </Border>

                    <Border Width="1" Height="20" Background="#D5DDE7" Margin="4,0"/>

                    <Button Classes="ToolButton" Content="&#xE740;"/>
                    <Button Classes="ToolButton" Content="&#xE8A7;"/>
                    <Button Classes="ToolButton" Content="&#xE734;"/>
                </StackPanel>

                <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                    <Button Classes="ToolButton" Content="&#xE8A7;"/>
                    <Button Classes="ToolButton" Content="&#xE8A9;"/>
                    <Button Classes="ToolButton" Content="&#xE713;"/>
                </StackPanel>
            </Grid>
        </Border>

        <Border Grid.Row="1"
                Grid.Column="0"
                Background="#F8FAFC"
                BorderBrush="#D5DDE7"
                BorderThickness="0,0,1,0">
            <StackPanel Margin="4,10" Spacing="8">
                <Button Classes="RailButton">
                    <Grid Width="20" Height="24">
                        <TextBlock Text="&#xE8A5;"
                                   FontFamily="Segoe MDL2 Assets"
                                   FontSize="15"
                                   Foreground="{Binding $parent[Button].Foreground}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"/>
                    </Grid>
                </Button>
                <ToggleButton Classes="RailButton"
                              IsChecked="{Binding PdfViewer.IsHandToolActive, Mode=OneWay}"
                              Click="OnHandToolClicked">
                    <Grid Width="20" Height="24">
                        <TextBlock Text="&#xE7C9;"
                                   FontFamily="Segoe MDL2 Assets"
                                   FontSize="15"
                                   Foreground="{Binding $parent[ToggleButton].Foreground}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"/>
                    </Grid>
                </ToggleButton>
                <ToggleButton Classes="RailButton"
                              IsChecked="{Binding PdfViewer.IsSelectToolActive, Mode=OneWay}"
                              Click="OnSelectToolClicked">
                    <Canvas Width="20" Height="24">
                        <TextBlock Text="T"
                                   FontFamily="Segoe UI"
                                   FontSize="18"
                                   FontWeight="SemiBold"
                                   Foreground="{Binding $parent[ToggleButton].Foreground}"
                                   Canvas.Left="2"
                                   Canvas.Top="1"/>
                        <Path Data="M 11,12 L 11,21 L 13.5,18.5 L 15.5,22 L 17.2,21 L 15.2,17.6 L 18.5,17.6 Z"
                              Fill="{Binding $parent[ToggleButton].Foreground}"/>
                    </Canvas>
                </ToggleButton>
                <ToggleButton Classes="RailButton"
                              IsChecked="{Binding PdfViewer.IsHighlightToolActive, Mode=OneWay}"
                              Click="OnHighlightToolClicked">
                    <Grid Width="20" Height="24">
                        <TextBlock Text="&#xE70F;"
                                   FontFamily="Segoe MDL2 Assets"
                                   FontSize="15"
                                   Foreground="{Binding $parent[ToggleButton].Foreground}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"/>
                    </Grid>
                </ToggleButton>
                <Button Classes="RailButton">
                    <Grid Width="20" Height="24">
                        <TextBlock Text="&#xE8A7;"
                                   FontFamily="Segoe MDL2 Assets"
                                   FontSize="15"
                                   Foreground="{Binding $parent[Button].Foreground}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"/>
                    </Grid>
                </Button>
                <Button Classes="RailButton">
                    <Grid Width="20" Height="24">
                        <TextBlock Text="&#xE712;"
                                   FontFamily="Segoe MDL2 Assets"
                                   FontSize="15"
                                   Foreground="{Binding $parent[Button].Foreground}"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"/>
                    </Grid>
                </Button>
            </StackPanel>
        </Border>

        <views:PdfViewerView Grid.Row="1"
                             Grid.Column="1"
                             DataContext="{Binding PdfViewer}"/>
    </Grid>
</UserControl>
``

## MiniZotero/Views/TabWorkspaceView.axaml.cs

``csharp
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using MiniZotero.ViewModels;

namespace MiniZotero.Views
{
    public partial class TabWorkspaceView : UserControl
    {
        public TabWorkspaceView()
        {
            InitializeComponent();
        }

        private void OnHandToolClicked(object? sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            if (DataContext is TabWorkspaceViewModel viewModel)
            {
                viewModel.PdfViewer.SetHandTool();
            }
        }

        private void OnSelectToolClicked(object? sender, RoutedEventArgs e)
        {
            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            if (DataContext is TabWorkspaceViewModel viewModel)
            {
                viewModel.PdfViewer.SetSelectTool();
            }
        }

        private void OnHighlightToolClicked(object? sender, RoutedEventArgs e)
        {
            if (DataContext is not TabWorkspaceViewModel viewModel)
            {
                return;
            }

            if (sender is ToggleButton { IsChecked: false })
            {
                viewModel.PdfViewer.SetSelectTool();
                return;
            }

            if (sender is ToggleButton button)
            {
                button.IsChecked = true;
            }

            viewModel.PdfViewer.SetHighlightTool();
        }
    }
}
``

## Planning/OOP Diagram_5_21_2026, 3_29_00 PM.png

_Skipped binary or large file. Size: 1331217 bytes._

## Planning/OOP Diagram_5_21_2026, 3_30_17 PM.png

_Skipped binary or large file. Size: 668079 bytes._

## Planning/user flow_5_21_2026, 3_29_32 PM.png

_Skipped binary or large file. Size: 262863 bytes._

## tools/Update-AllCode.ps1

``powershell
$ErrorActionPreference = "Stop"

$rootPath = (Resolve-Path (Join-Path $PSScriptRoot "..")).Path
$outputPath = Join-Path $rootPath "ALL_CODE.md"
$excludedDirectoryNames = @(
    ".git",
    ".vs",
    ".idea",
    ".vscode",
    "bin",
    "obj",
    "node_modules"
)
$largeFileThresholdBytes = 100000

$languageByExtension = @{
    ".axaml" = "xml"
    ".cs" = "csharp"
    ".css" = "css"
    ".csproj" = "xml"
    ".gitattributes" = "gitattributes"
    ".gitignore" = "gitignore"
    ".html" = "html"
    ".js" = "javascript"
    ".json" = "json"
    ".manifest" = "xml"
    ".md" = "markdown"
    ".ps1" = "powershell"
    ".sln" = "text"
    ".txt" = "text"
    ".xml" = "xml"
}

function Get-RelativePath {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $normalizedRootPath = $rootPath

    if (-not $normalizedRootPath.EndsWith([System.IO.Path]::DirectorySeparatorChar)) {
        $normalizedRootPath += [System.IO.Path]::DirectorySeparatorChar
    }

    $rootUri = [Uri]$normalizedRootPath
    $pathUri = [Uri]([System.IO.Path]::GetFullPath($Path))

    return [Uri]::UnescapeDataString($rootUri.MakeRelativeUri($pathUri).ToString()).Replace("\", "/")
}

function Test-IsExcludedPath {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $relativePath = Get-RelativePath -Path $Path

    if ($relativePath -eq "ALL_CODE.md") {
        return $true
    }

    $segments = $relativePath -split "/"

    foreach ($segment in $segments) {
        if ($excludedDirectoryNames -contains $segment) {
            return $true
        }
    }

    return $false
}

function Test-IsBinaryFile {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $buffer = New-Object byte[] 8192

    try {
        $stream = [System.IO.File]::Open($Path, [System.IO.FileMode]::Open, [System.IO.FileAccess]::Read, [System.IO.FileShare]::ReadWrite)
        try {
            $bytesRead = $stream.Read($buffer, 0, $buffer.Length)

            for ($index = 0; $index -lt $bytesRead; $index++) {
                if ($buffer[$index] -eq 0) {
                    return $true
                }
            }
        }
        finally {
            $stream.Dispose()
        }
    }
    catch {
        return $true
    }

    return $false
}

function Get-CodeFenceLanguage {
    param(
        [Parameter(Mandatory = $true)]
        [string] $Path
    )

    $extension = [System.IO.Path]::GetExtension($Path).ToLowerInvariant()

    if ($languageByExtension.ContainsKey($extension)) {
        return $languageByExtension[$extension]
    }

    return "text"
}

$builder = [System.Text.StringBuilder]::new()
[void]$builder.AppendLine("# MiniZotero - All Code")
[void]$builder.AppendLine()
[void]$builder.AppendLine("Generated from the current workspace source files. Build output, IDE folders, node_modules, and Git internals are excluded.")

$files = Get-ChildItem -LiteralPath $rootPath -File -Recurse |
    Where-Object { -not (Test-IsExcludedPath -Path $_.FullName) } |
    Sort-Object { Get-RelativePath -Path $_.FullName }

foreach ($file in $files) {
    $relativePath = Get-RelativePath -Path $file.FullName

    [void]$builder.AppendLine()
    [void]$builder.AppendLine("## $relativePath")
    [void]$builder.AppendLine()

    if ($file.Length -gt $largeFileThresholdBytes -or (Test-IsBinaryFile -Path $file.FullName)) {
        [void]$builder.AppendLine("_Skipped binary or large file. Size: $($file.Length) bytes._")
        continue
    }

    $language = Get-CodeFenceLanguage -Path $file.FullName
    $content = [System.IO.File]::ReadAllText($file.FullName)

    [void]$builder.AppendLine("````$language")
    [void]$builder.AppendLine($content.TrimEnd())
    [void]$builder.AppendLine("````")
}

[System.IO.File]::WriteAllText($outputPath, $builder.ToString(), [System.Text.UTF8Encoding]::new($false))
Write-Host "Updated ALL_CODE.md"
``

# MiniZotero - All Code

Generated from the current workspace source files. Build output, IDE folders, and Git internals are excluded.

## .gitattributes

````gitattributes
* text=auto

# Keep GitHub language stats focused on C#.
*.cs linguist-language=C#
*.axaml linguist-vendored
*.xaml linguist-vendored
*.csproj linguist-vendored
*.sln linguist-vendored
*.manifest linguist-vendored
*.ico linguist-vendored
````

## .gitignore

````gitignore
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
````

## MiniZotero.sln

````text

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.14.36518.9 d17.14
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "MiniZotero", "MiniZotero\MiniZotero.csproj", "{8C38B81B-B5CC-48CB-A61B-590819D69E6F}"
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
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(ExtensibilityGlobals) = postSolution
		SolutionGuid = {57A150A0-920C-443B-A780-8D6D4F0656F7}
	EndGlobalSection
EndGlobal
````

## MiniZotero/App.axaml

````xml
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
````

## MiniZotero/App.axaml.cs

````csharp
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
````

## MiniZotero/app.manifest

````xml
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
````

## MiniZotero/Assets/avalonia-logo.ico

Binary asset, 175875 bytes.

## MiniZotero/MiniZotero.csproj

````xml
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
    <PackageReference Include="Avalonia" Version="12.0.3" />
    <PackageReference Include="Avalonia.Desktop" Version="12.0.3" />
    <PackageReference Include="Avalonia.Themes.Fluent" Version="12.0.3" />
    <PackageReference Include="Avalonia.Fonts.Inter" Version="12.0.3" />
    <PackageReference Include="CommunityToolkit.Mvvm" Version="8.4.1" />
  </ItemGroup>
</Project>
````

## MiniZotero/Models/DocumentItem.cs

````csharp
using System;

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
            int lastReadPage)
        {
            Id = id;
            Title = title;
            FilePath = filePath;
            OriginalFilePath = originalFilePath;
            AddedAt = addedAt;
            LastOpenedAt = lastOpenedAt;
            LastReadPage = lastReadPage;
        }

        public string Id { get; set; } = string.Empty;

        public string Title { get; set; } = string.Empty;

        public string FilePath { get; set; } = string.Empty;

        public string OriginalFilePath { get; set; } = string.Empty;

        public DateTimeOffset AddedAt { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? LastOpenedAt { get; set; }

        public int LastReadPage { get; set; } = 1;
    }
}
````

## MiniZotero/Program.cs

````csharp
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
````

## MiniZotero/Repositories/DocumentRepository.cs

````csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using MiniZotero.Models;
using MiniZotero.Services;

namespace MiniZotero.Repositories
{
    public sealed class DocumentRepository
    {
        private static readonly JsonSerializerOptions JsonOptions = new()
        {
            WriteIndented = true
        };

        private readonly AppStorageService _storageService;

        public DocumentRepository(AppStorageService storageService)
        {
            _storageService = storageService;
        }

        public IReadOnlyList<DocumentItem> LoadDocuments()
        {
            var libraryPath = _storageService.LibraryFilePath;
            if (!File.Exists(libraryPath))
            {
                return [];
            }

            try
            {
                var json = File.ReadAllText(libraryPath);
                var documents = JsonSerializer.Deserialize<List<DocumentItem>>(json, JsonOptions) ?? [];
                var changed = NormalizeDocuments(documents);
                changed |= MigrateDocumentsToStorage(documents);

                if (changed)
                {
                    SaveDocuments(documents);
                }

                return documents;
            }
            catch (IOException)
            {
                return [];
            }
            catch (JsonException)
            {
                return [];
            }
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

            return document;
        }

        public DocumentItem AddDocument(string filePath)
        {
            var documents = LoadDocuments().ToList();
            var document = ImportDocument(filePath, documents);

            if (!documents.Any(existingDocument => existingDocument.Id == document.Id))
            {
                documents.Add(document);
                SaveDocuments(documents);
            }

            return document;
        }

        public void SaveDocuments(IEnumerable<DocumentItem> documents)
        {
            var json = JsonSerializer.Serialize(documents, JsonOptions);
            File.WriteAllText(_storageService.LibraryFilePath, json);
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
            }

            return changed;
        }
    }
}
````

## MiniZotero/Services/AppStorageService.cs

````csharp
using System;
using System.IO;

namespace MiniZotero.Services
{
    public sealed class AppStorageService
    {
        private const string AppFolderName = "MiniZotero";
        private const string LibraryFileName = "library.json";
        private const string PdfFolderName = "pdfs";

        public AppStorageService()
        {
            RootPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                AppFolderName);

            Directory.CreateDirectory(RootPath);
            Directory.CreateDirectory(PdfFolderPath);
        }

        public string RootPath { get; }

        public string AppDataPath => RootPath;

        public string PdfFolderPath => Path.Combine(RootPath, PdfFolderName);

        public string LibraryFilePath => Path.Combine(RootPath, LibraryFileName);
    }
}
````

## MiniZotero/ViewLocator.cs

````csharp
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
````

## MiniZotero/ViewModels/MainWindowViewModel.cs

````csharp
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            var storageService = new AppStorageService();
            var documentRepository = new DocumentRepository(storageService);

            Sidebar = new SidebarViewModel(documentRepository);

            Sidebar.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SidebarViewModel.SelectedDocument) &&
                    Sidebar.SelectedDocument is { } document)
                {
                    Workspace.OpenDocument(document);
                    Notes.OpenDocument(document);
                }
            };
        }

        public SidebarViewModel Sidebar { get; }

        public TabWorkspaceViewModel Workspace { get; } = new();

        public NotePreviewPanelViewModel Notes { get; } = new();
    }
}
````

## MiniZotero/ViewModels/NotePreviewPanelViewModel.cs

````csharp
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class NotePreviewPanelViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(HasDocument))]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        [ObservableProperty]
        private string _noteText = string.Empty;

        public bool HasDocument => ActiveDocument is not null;

        public bool IsEmptyViewVisible => !HasDocument;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            NoteText = string.Empty;
        }
    }
}
````

## MiniZotero/ViewModels/PdfViewerViewModel.cs

````csharp
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class PdfViewerViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private bool _hasDocumentLoaded;

        [ObservableProperty]
        private string _documentPath = string.Empty;

        [ObservableProperty]
        private string _statusText = "Ready";

        [ObservableProperty]
        private string _emptyTitle = "Select a document to view";

        [ObservableProperty]
        private string _emptyMessage = "Import a PDF file from the sidebar.";

        public bool IsEmptyViewVisible => !HasDocumentLoaded;

        public void LoadDocument(DocumentItem document)
        {
            DocumentPath = document.FilePath;
            StatusText = "Document loaded";
            EmptyTitle = document.Title;
            EmptyMessage = string.Empty;
            HasDocumentLoaded = true;
        }
    }
}
````

## MiniZotero/ViewModels/SidebarViewModel.cs

````csharp
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;
using MiniZotero.Repositories;
using MiniZotero.Services;

namespace MiniZotero.ViewModels
{
    public partial class SidebarViewModel : ViewModelBase
    {
        private readonly DocumentRepository _documentRepository;

        public SidebarViewModel()
            : this(new DocumentRepository(new AppStorageService()))
        {
        }

        public SidebarViewModel(DocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;

            foreach (var document in _documentRepository.LoadDocuments())
            {
                Documents.Add(document);
            }

            NotifyDocumentStateChanged();
        }

        [ObservableProperty]
        private DocumentItem? _selectedDocument;

        public ObservableCollection<DocumentItem> Documents { get; } = new();

        public int DocumentCount => Documents.Count;

        public bool HasDocuments => Documents.Count > 0;

        public bool IsEmptyViewVisible => !HasDocuments;

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

            _documentRepository.SaveDocuments(Documents);
            NotifyDocumentStateChanged();

            SelectedDocument = document;
        }

        private void NotifyDocumentStateChanged()
        {
            OnPropertyChanged(nameof(DocumentCount));
            OnPropertyChanged(nameof(HasDocuments));
            OnPropertyChanged(nameof(IsEmptyViewVisible));
        }
    }
}
````

## MiniZotero/ViewModels/TabWorkspaceViewModel.cs

````csharp
using CommunityToolkit.Mvvm.ComponentModel;
using MiniZotero.Models;

namespace MiniZotero.ViewModels
{
    public partial class TabWorkspaceViewModel : ViewModelBase
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsEmptyViewVisible))]
        private DocumentItem? _activeDocument;

        public PdfViewerViewModel PdfViewer { get; } = new();

        public bool IsEmptyViewVisible => ActiveDocument is null;

        public void OpenDocument(DocumentItem document)
        {
            ActiveDocument = document;
            PdfViewer.LoadDocument(document);
        }
    }
}
````

## MiniZotero/ViewModels/ViewModelBase.cs

````csharp
using CommunityToolkit.Mvvm.ComponentModel;

namespace MiniZotero.ViewModels
{
    public abstract class ViewModelBase : ObservableObject
    {
    }
}
````

## MiniZotero/Views/MainWindow.axaml

````xml
<Window xmlns="https://github.com/avaloniaui"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:models="using:MiniZotero.Models"
        xmlns:vm="using:MiniZotero.ViewModels"
        mc:Ignorable="d"
        d:DesignWidth="1280"
        d:DesignHeight="820"
        Width="1280"
        Height="820"
        MinWidth="1100"
        MinHeight="720"
        x:Class="MiniZotero.Views.MainWindow"
        x:DataType="vm:MainWindowViewModel"
        Title="MiniZotero"
        Background="#0C1017"
        Foreground="#E8EDF4"
        FontFamily="Segoe UI">

    <Window.Styles>
        <Style Selector="Button">
            <Setter Property="CornerRadius" Value="6"/>
            <Setter Property="Padding" Value="8,4"/>
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="BorderThickness" Value="0"/>
        </Style>
        <Style Selector="Button:pointerover">
            <Setter Property="Background" Value="#253141"/>
        </Style>
        <Style Selector="Button.SidebarItem">
            <Setter Property="HorizontalAlignment" Value="Stretch"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="Padding" Value="10,7"/>
            <Setter Property="Foreground" Value="#D7DEE8"/>
        </Style>
        <Style Selector="Button.SidebarItem.Active">
            <Setter Property="Background" Value="#273241"/>
            <Setter Property="Foreground" Value="White"/>
        </Style>
        <Style Selector="TextBlock.Muted">
            <Setter Property="Foreground" Value="#8A96A8"/>
        </Style>
        <Style Selector="TextBlock.Section">
            <Setter Property="Foreground" Value="#91A0B5"/>
            <Setter Property="FontSize" Value="11"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
        </Style>
        <Style Selector="Border.Card">
            <Setter Property="Background" Value="#FFFFFF"/>
            <Setter Property="BorderBrush" Value="#DDE3EA"/>
            <Setter Property="BorderThickness" Value="1"/>
            <Setter Property="CornerRadius" Value="7"/>
        </Style>
    </Window.Styles>

    <Grid RowDefinitions="42,*,34" ColumnDefinitions="224,*,492">
        <Border Grid.Row="0" Grid.Column="0" Background="#121923" BorderBrush="#202A37" BorderThickness="0,0,1,1">
            <Grid ColumnDefinitions="Auto,*,Auto" Margin="14,0">
                <Border Width="20" Height="20" CornerRadius="4" Background="#7857FF" VerticalAlignment="Center">
                    <TextBlock Text="M" FontSize="12" FontWeight="Bold" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                </Border>
                <TextBlock Grid.Column="1" Text="MiniZotero" Margin="8,0,0,0" VerticalAlignment="Center" FontWeight="SemiBold"/>
                <Button Grid.Column="2" Content="+" Foreground="#9AA7B8" VerticalAlignment="Center" Padding="6,2"/>
            </Grid>
        </Border>

        <Border Grid.Row="0" Grid.Column="1" Grid.ColumnSpan="2" Background="#0E141D" BorderBrush="#202A37" BorderThickness="0,0,0,1">
            <Grid Margin="8,0">
                <StackPanel Orientation="Horizontal" Spacing="8" VerticalAlignment="Center">
                    <TextBlock Text="{Binding Sidebar.DocumentCount, StringFormat='{}{0} documents in library'}" Classes="Muted" FontSize="12"/>
                    <Button Content="Import PDF" Click="OnImportPdfClicked" Foreground="#D7DEE8" Background="#17202C" Padding="10,5"/>
                </StackPanel>
            </Grid>
        </Border>

        <Border Grid.Row="1" Grid.Column="0" Background="#111923" BorderBrush="#202A37" BorderThickness="0,0,1,0" Padding="12">
            <Grid RowDefinitions="Auto,Auto,*,Auto,Auto">
                <StackPanel Grid.Row="0" Spacing="4">
                    <Button Classes="SidebarItem Active" Content="Library"/>
                    <Button Classes="SidebarItem" Content="Recent"/>
                    <Button Classes="SidebarItem" Content="Starred"/>
                    <Button Classes="SidebarItem" Content="Trash"/>
                </StackPanel>

                <Grid Grid.Row="1" ColumnDefinitions="*,Auto" Margin="0,22,0,8">
                    <TextBlock Classes="Section" Text="DOCUMENTS"/>
                    <TextBlock Grid.Column="1" Text="{Binding Sidebar.DocumentCount}" Classes="Muted" FontSize="11"/>
                </Grid>

                <Grid Grid.Row="2" Margin="0,0,0,16">
                    <Border Background="#1C2633"
                            CornerRadius="7"
                            Padding="12"
                            IsVisible="{Binding Sidebar.IsEmptyViewVisible}">
                        <StackPanel Spacing="6">
                            <TextBlock Text="No PDFs yet" FontSize="13"/>
                            <TextBlock Text="Import a PDF to save it in library.json." Classes="Muted" FontSize="11" TextWrapping="Wrap"/>
                        </StackPanel>
                    </Border>

                    <ListBox ItemsSource="{Binding Sidebar.Documents}"
                             SelectedItem="{Binding Sidebar.SelectedDocument, Mode=TwoWay}"
                             Background="Transparent"
                             BorderThickness="0"
                             IsVisible="{Binding Sidebar.HasDocuments}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="models:DocumentItem">
                                <StackPanel Spacing="3" Margin="2,4">
                                    <TextBlock Text="{Binding Title}"
                                               FontSize="13"
                                               TextTrimming="CharacterEllipsis"/>
                                    <TextBlock Text="{Binding FilePath}"
                                               Classes="Muted"
                                               FontSize="11"
                                               TextTrimming="CharacterEllipsis"/>
                                </StackPanel>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </Grid>

                <StackPanel Grid.Row="3" Spacing="8">
                    <Grid ColumnDefinitions="*,Auto">
                        <TextBlock Classes="Section" Text="TAGS"/>
                        <Button Grid.Column="1" Content="+" Padding="4,0"/>
                    </Grid>
                    <Border Background="#1C2633" CornerRadius="7" Padding="12">
                        <StackPanel Spacing="6">
                        <TextBlock Text="No tags yet" FontSize="13"/>
                            <TextBlock Text="Tags will appear here in a later step." Classes="Muted" FontSize="11" TextWrapping="Wrap"/>
                        </StackPanel>
                    </Border>
                </StackPanel>

                <StackPanel Grid.Row="4" Spacing="12" Margin="0,18,0,0">
                    <Border Background="#1C2633" CornerRadius="7" Padding="10">
                        <Grid ColumnDefinitions="*,Auto">
                            <StackPanel>
                                <TextBlock Text="Watch Folder" FontSize="12" FontWeight="SemiBold"/>
                                <TextBlock Text="Not configured" Classes="Muted" FontSize="11"/>
                            </StackPanel>
                            <Button Grid.Column="1" Content="Set up" Foreground="#D7DEE8" VerticalAlignment="Center"/>
                        </Grid>
                    </Border>
                    <ProgressBar Value="0" Height="5" Background="#344153" Foreground="#7C5CFF"/>
                    <TextBlock Text="Storage not initialized" Classes="Muted" FontSize="11"/>
                </StackPanel>
            </Grid>
        </Border>

        <Grid Grid.Row="1" Grid.Column="1" Background="#E8ECF2" RowDefinitions="42,*">
            <Border Grid.Row="0" Background="#F8FAFC" BorderBrush="#D6DEE8" BorderThickness="0,0,1,1">
                <Grid ColumnDefinitions="Auto,*,Auto" Margin="10,0">
                    <StackPanel Orientation="Horizontal" Spacing="10" VerticalAlignment="Center">
                        <Button Content="&lt;" Foreground="#94A3B8" IsEnabled="False"/>
                        <TextBlock Text="0 / 0" Foreground="#94A3B8" FontWeight="SemiBold" FontSize="12" VerticalAlignment="Center"/>
                        <Button Content="&gt;" Foreground="#94A3B8" IsEnabled="False"/>
                        <Button Content="-" Foreground="#94A3B8" IsEnabled="False"/>
                        <Button Content="+" Foreground="#94A3B8" IsEnabled="False"/>
                        <ComboBox SelectedIndex="0" Width="78" Height="28" IsEnabled="False">
                            <ComboBoxItem Content="100%"/>
                        </ComboBox>
                    </StackPanel>
                    <StackPanel Grid.Column="2" Orientation="Horizontal" Spacing="6" VerticalAlignment="Center">
                        <Button Content="Fit" Foreground="#94A3B8" IsEnabled="False"/>
                        <Button Content="Open" Foreground="#475569"/>
                    </StackPanel>
                </Grid>
            </Border>

            <Grid Grid.Row="1" Background="#EDF1F6">
                <Border Background="White"
                        CornerRadius="8"
                        Padding="28"
                        Width="420"
                        HorizontalAlignment="Center"
                        VerticalAlignment="Center"
                        BoxShadow="0 4 18 #22000000">
                    <StackPanel Spacing="12">
                        <TextBlock Text="No document selected"
                                   Foreground="#111827"
                                   FontSize="22"
                                   FontWeight="SemiBold"
                                   HorizontalAlignment="Center"/>
                        <TextBlock Text="Import a PDF to preview it here."
                                   Foreground="#64748B"
                                   FontSize="14"
                                   TextWrapping="Wrap"
                                   TextAlignment="Center"/>
                        <Button Content="Import PDF"
                                Click="OnImportPdfClicked"
                                HorizontalAlignment="Center"
                                Foreground="#FFFFFF"
                                Background="#5B43D6"
                                Padding="16,7"
                                Margin="0,8,0,0"/>
                    </StackPanel>
                </Border>
            </Grid>
        </Grid>

        <Grid Grid.Row="1" Grid.Column="2" Background="#E8ECF2" RowDefinitions="280,*">
            <Border Grid.Row="0" Classes="Card" Margin="8,8,8,4">
                <Grid RowDefinitions="42,*">
                    <Grid Grid.Row="0" ColumnDefinitions="*,Auto" Margin="14,0">
                        <TextBlock Text="Note taking" Foreground="#111827" FontWeight="SemiBold" VerticalAlignment="Center"/>
                        <StackPanel Grid.Column="1" Orientation="Horizontal" Spacing="4" VerticalAlignment="Center">
                            <Button Content="New" Foreground="#475569" IsEnabled="False"/>
                            <Button Content="..." Foreground="#475569" IsEnabled="False"/>
                        </StackPanel>
                    </Grid>

                    <Border Grid.Row="1" BorderBrush="#E5EAF0" BorderThickness="0,1,0,0" Padding="18">
                        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="8">
                            <TextBlock Text="No note selected" Foreground="#111827" FontSize="16" FontWeight="SemiBold" HorizontalAlignment="Center"/>
                            <TextBlock Text="Select a document to create notes." Foreground="#8A96A8" FontSize="13" TextAlignment="Center"/>
                        </StackPanel>
                    </Border>
                </Grid>
            </Border>

            <Border Grid.Row="1" Classes="Card" Margin="8,4,8,8">
                <Grid RowDefinitions="44,*">
                    <Grid Grid.Row="0" ColumnDefinitions="*,Auto" Margin="14,0">
                        <TextBlock Text="Preview" Foreground="#111827" FontWeight="SemiBold" FontSize="12" VerticalAlignment="Center"/>
                        <Button Grid.Column="1" Content="..." Foreground="#475569" IsEnabled="False" VerticalAlignment="Center"/>
                    </Grid>

                    <Border Grid.Row="1" BorderBrush="#E5EAF0" BorderThickness="0,1,0,0" Padding="18">
                        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="8">
                            <TextBlock Text="No highlights" Foreground="#111827" FontSize="16" FontWeight="SemiBold" HorizontalAlignment="Center"/>
                            <TextBlock Text="Highlights will appear here after reading a document." Foreground="#8A96A8" FontSize="13" TextWrapping="Wrap" TextAlignment="Center"/>
                        </StackPanel>
                    </Border>
                </Grid>
            </Border>
        </Grid>

        <Border Grid.Row="2" Grid.Column="0" Grid.ColumnSpan="3" Background="#0D131C" BorderBrush="#202A37" BorderThickness="0,1,0,0">
            <Grid ColumnDefinitions="*,Auto,Auto" Margin="16,0">
                <StackPanel Orientation="Horizontal" Spacing="14" VerticalAlignment="Center">
                    <TextBlock Text="Ready" Classes="Muted" FontSize="12"/>
                </StackPanel>
                <TextBlock Grid.Column="1" Text="0 documents open" Classes="Muted" FontSize="12" VerticalAlignment="Center" Margin="0,0,24,0"/>
                <TextBlock Grid.Column="2" Text="Sync not configured" Classes="Muted" FontSize="12" VerticalAlignment="Center"/>
            </Grid>
        </Border>
    </Grid>
</Window>
````

## MiniZotero/Views/MainWindow.axaml.cs

````csharp
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
````

## MiniZotero/Views/NotePreviewPanelView.axaml

````xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.NotePreviewPanelView"
             x:DataType="vm:NotePreviewPanelViewModel">

    <Grid RowDefinitions="Auto, *" Background="#16151D">
        <Border Grid.Row="0" BorderBrush="#2E2C36" BorderThickness="0,0,0,1" Padding="12">
            <Grid ColumnDefinitions="*, Auto">
                <StackPanel>
                    <TextBlock Text="Notes" FontWeight="SemiBold"/>
                    <TextBlock Text="{Binding ActiveDocument.Title, FallbackValue=No document selected}"
                               Foreground="#93909A"
                               FontSize="11"
                               TextTrimming="CharacterEllipsis"/>
                </StackPanel>
                <Button Grid.Column="1" Content="New" Padding="10,4" VerticalAlignment="Center"/>
            </Grid>
        </Border>

        <Grid Grid.Row="1" Margin="12">
            <Border Background="#1D1B22" CornerRadius="6" Padding="14" IsVisible="{Binding IsEmptyViewVisible}">
                <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="10" Width="260">
                    <TextBlock Text="No note selected"
                               FontSize="16"
                               FontWeight="SemiBold"
                               HorizontalAlignment="Center"/>
                    <TextBlock Text="Select a PDF to start taking notes."
                               Foreground="#93909A"
                               TextWrapping="Wrap"
                               TextAlignment="Center"/>
                </StackPanel>
            </Border>

            <TextBox Text="{Binding NoteText, Mode=TwoWay}"
                     IsVisible="{Binding HasDocument}"
                     AcceptsReturn="True"
                     TextWrapping="Wrap"
                     Background="#1D1B22"
                     BorderThickness="0"
                     PlaceholderText="Write notes for this document..."/>
        </Grid>
    </Grid>
</UserControl>
````

## MiniZotero/Views/NotePreviewPanelView.axaml.cs

````csharp
using Avalonia.Controls;

namespace MiniZotero.Views
{
    public partial class NotePreviewPanelView : UserControl
    {
        public NotePreviewPanelView()
        {
            InitializeComponent();
        }
    }
}
````

## MiniZotero/Views/PdfViewerView.axaml

````xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.PdfViewerView"
             x:DataType="vm:PdfViewerViewModel">

    <Grid Background="#26242C">
        <Border Background="#1D1B22"
                CornerRadius="6"
                Padding="18"
                Margin="20"
                IsVisible="{Binding IsEmptyViewVisible}">
            <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="10" Width="360">
                <TextBlock Text="{Binding EmptyTitle}"
                           FontSize="21"
                           FontWeight="SemiBold"
                           HorizontalAlignment="Center"/>
                <TextBlock Text="{Binding EmptyMessage}"
                           Foreground="#93909A"
                           TextWrapping="Wrap"
                           TextAlignment="Center"/>
            </StackPanel>
        </Border>

        <Border Background="#F8F8F5"
                CornerRadius="6"
                Margin="20"
                Padding="28"
                IsVisible="{Binding HasDocumentLoaded}">
            <Grid RowDefinitions="Auto, *, Auto">
                <Grid Grid.Row="0" ColumnDefinitions="*, Auto" Margin="0,0,0,18">
                    <TextBlock Text="{Binding StatusText}"
                               Foreground="#475569"
                               FontSize="12"/>
                    <TextBlock Grid.Column="1"
                               Text="PDF preview"
                               Foreground="#111827"
                               FontWeight="SemiBold"
                               FontSize="13"/>
                </Grid>

                <Border Grid.Row="1"
                        BorderBrush="#D1D5DB"
                        BorderThickness="1"
                        Background="White"
                        Padding="24">
                    <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Spacing="10" Width="420">
                        <TextBlock Text="PDF renderer is ready to be connected"
                                   Foreground="#111827"
                                   FontSize="18"
                                   FontWeight="SemiBold"
                                   HorizontalAlignment="Center"/>
                        <TextBlock Text="{Binding DocumentPath}"
                                   Foreground="#64748B"
                                   FontSize="12"
                                   TextWrapping="Wrap"
                                   TextAlignment="Center"/>
                    </StackPanel>
                </Border>

                <TextBlock Grid.Row="2"
                           Text="{Binding DocumentPath}"
                           Foreground="#64748B"
                           FontSize="11"
                           Margin="0,14,0,0"
                           TextTrimming="CharacterEllipsis"/>
            </Grid>
        </Border>
    </Grid>
</UserControl>
````

## MiniZotero/Views/PdfViewerView.axaml.cs

````csharp
using Avalonia.Controls;

namespace MiniZotero.Views
{
    public partial class PdfViewerView : UserControl
    {
        public PdfViewerView()
        {
            InitializeComponent();
        }
    }
}
````

## MiniZotero/Views/SidebarView.axaml

````xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:models="using:MiniZotero.Models"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.SidebarView"
             x:DataType="vm:SidebarViewModel">

    <UserControl.Styles>
        <Style Selector="Button.SidebarItem">
            <Setter Property="Background" Value="Transparent"/>
            <Setter Property="HorizontalAlignment" Value="Stretch"/>
            <Setter Property="HorizontalContentAlignment" Value="Left"/>
            <Setter Property="Padding" Value="12,8"/>
            <Setter Property="CornerRadius" Value="6"/>
        </Style>
        <Style Selector="Button.SidebarItem:pointerover">
            <Setter Property="Background" Value="#23222A"/>
        </Style>
        <Style Selector="TextBlock.Muted">
            <Setter Property="Foreground" Value="#93909A"/>
        </Style>
        <Style Selector="TextBlock.SectionTitle">
            <Setter Property="Foreground" Value="#79747E"/>
            <Setter Property="FontSize" Value="11"/>
            <Setter Property="FontWeight" Value="SemiBold"/>
        </Style>
    </UserControl.Styles>

    <Border Background="#16151D" Padding="12">
        <Grid RowDefinitions="Auto, Auto, *, Auto">
            <StackPanel Grid.Row="0" Spacing="12">
                <Grid ColumnDefinitions="Auto, *, Auto">
                    <Border Grid.Column="0" Background="#6750A4" CornerRadius="4" Width="28" Height="28">
                        <TextBlock Text="M"
                                   HorizontalAlignment="Center"
                                   VerticalAlignment="Center"
                                   FontWeight="SemiBold"
                                   Foreground="White"/>
                    </Border>
                    <TextBlock Grid.Column="1"
                               Text="MiniZotero"
                               VerticalAlignment="Center"
                               Margin="10,0,0,0"
                               FontSize="15"
                               FontWeight="SemiBold"/>
                    <Button Grid.Column="2"
                            Content="+"
                            Click="OnImportPdfClicked"
                            Background="Transparent"
                            Padding="8,2"/>
                </Grid>

                <TextBox PlaceholderText="Search documents..."
                         Height="32"
                         FontSize="12"
                         VerticalContentAlignment="Center"/>
            </StackPanel>

            <StackPanel Grid.Row="1" Margin="0,18,0,0" Spacing="2">
                <Button Classes="SidebarItem" Content="Library"/>
                <Button Classes="SidebarItem" Content="Recent"/>
                <Button Classes="SidebarItem" Content="Starred"/>
                <Button Classes="SidebarItem" Content="Trash"/>
            </StackPanel>

            <Grid Grid.Row="2" Margin="0,18,0,0" RowDefinitions="Auto, *">
                <Grid Grid.Row="0" ColumnDefinitions="*, Auto" Margin="5,0,5,8">
                    <TextBlock Classes="SectionTitle" Text="DOCUMENTS"/>
                    <TextBlock Grid.Column="1"
                               Classes="Muted"
                               Text="{Binding DocumentCount}"
                               FontSize="11"/>
                </Grid>

                <Grid Grid.Row="1">
                    <Border Background="#1E1D24"
                            CornerRadius="6"
                            Padding="12"
                            IsVisible="{Binding IsEmptyViewVisible}">
                        <TextBlock Classes="Muted"
                                   Text="No PDFs imported yet."
                                   FontSize="12"
                                   TextWrapping="Wrap"/>
                    </Border>

                    <ListBox ItemsSource="{Binding Documents}"
                             SelectedItem="{Binding SelectedDocument, Mode=TwoWay}"
                             Background="Transparent"
                             BorderThickness="0"
                             IsVisible="{Binding HasDocuments}">
                        <ListBox.ItemTemplate>
                            <DataTemplate x:DataType="models:DocumentItem">
                                <StackPanel Spacing="3" Margin="2,4">
                                    <TextBlock Text="{Binding Title}"
                                               FontSize="13"
                                               TextTrimming="CharacterEllipsis"/>
                                    <TextBlock Text="{Binding FilePath}"
                                               Foreground="#93909A"
                                               FontSize="11"
                                               TextTrimming="CharacterEllipsis"/>
                                </StackPanel>
                            </DataTemplate>
                        </ListBox.ItemTemplate>
                    </ListBox>
                </Grid>
            </Grid>

            <Border Grid.Row="3" Background="#1E1D24" Padding="10" CornerRadius="6" Margin="0,15,0,0">
                <Grid ColumnDefinitions="*, Auto">
                    <StackPanel>
                        <TextBlock Text="Watch Folder" FontSize="12"/>
                        <TextBlock Classes="Muted" Text="Not configured" FontSize="11"/>
                    </StackPanel>
                    <Button Grid.Column="1" Content="Configure" Padding="8,4" VerticalAlignment="Center"/>
                </Grid>
            </Border>
        </Grid>
    </Border>
</UserControl>
````

## MiniZotero/Views/SidebarView.axaml.cs

````csharp
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
    }
}
````

## MiniZotero/Views/TabWorkspaceView.axaml

````xml
<UserControl xmlns="https://github.com/avaloniaui"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:views="using:MiniZotero.Views"
             xmlns:vm="using:MiniZotero.ViewModels"
             x:Class="MiniZotero.Views.TabWorkspaceView"
             x:DataType="vm:TabWorkspaceViewModel">

    <Grid RowDefinitions="Auto, Auto, *" Background="#1D1B22">
        <Border Grid.Row="0" Background="#16151D" Padding="10">
            <Grid ColumnDefinitions="*, Auto">
                <TextBlock Text="{Binding ActiveDocument.Title, FallbackValue=No document selected}"
                           VerticalAlignment="Center"
                           FontWeight="SemiBold"
                           TextTrimming="CharacterEllipsis"/>
                <TextBlock Grid.Column="1"
                           Text="{Binding ActiveDocument.FilePath}"
                           Foreground="#93909A"
                           FontSize="11"
                           VerticalAlignment="Center"
                           TextTrimming="CharacterEllipsis"
                           MaxWidth="320"/>
            </Grid>
        </Border>

        <Border Grid.Row="1"
                Background="#1D1B22"
                Height="42"
                BorderBrush="#2E2C36"
                BorderThickness="0,0,0,1"
                Padding="12,0">
            <Grid ColumnDefinitions="Auto, *, Auto">
                <StackPanel Orientation="Horizontal" Spacing="8" VerticalAlignment="Center">
                    <Button Content="Open" Padding="10,4"/>
                    <Button Content="Fit" Padding="10,4"/>
                    <Button Content="100%" Padding="10,4"/>
                </StackPanel>
                <TextBlock Grid.Column="2"
                           Text="Workspace"
                           Foreground="#93909A"
                           FontSize="12"
                           VerticalAlignment="Center"/>
            </Grid>
        </Border>

        <views:PdfViewerView Grid.Row="2" DataContext="{Binding PdfViewer}"/>
    </Grid>
</UserControl>
````

## MiniZotero/Views/TabWorkspaceView.axaml.cs

````csharp
using Avalonia.Controls;

namespace MiniZotero.Views
{
    public partial class TabWorkspaceView : UserControl
    {
        public TabWorkspaceView()
        {
            InitializeComponent();
        }
    }
}
````

## Planning/OOP Diagram_5_21_2026, 3_29_00 PM.png

Binary asset, 1331217 bytes.

## Planning/OOP Diagram_5_21_2026, 3_30_17 PM.png

Binary asset, 668079 bytes.

## Planning/user flow_5_21_2026, 3_29_32 PM.png

Binary asset, 262863 bytes.


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

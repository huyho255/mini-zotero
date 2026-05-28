using System;
using System.Collections.Generic;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public sealed class NoteService : INoteService
    {
        private readonly INoteRepository _noteRepository;
        private readonly MarkdownExportService _markdownExportService;

        public NoteService(
            INoteRepository noteRepository,
            MarkdownExportService markdownExportService)
        {
            _noteRepository = noteRepository;
            _markdownExportService = markdownExportService;
        }

        public string LoadNote(string documentId)
        {
            return _noteRepository.LoadNote(documentId);
        }

        public OperationResult SaveNote(string documentId, string text)
        {
            try
            {
                _noteRepository.SaveNote(documentId, text);
                return OperationResult.Success("Note saved.");
            }
            catch (Exception)
            {
                return OperationResult.Failure("Could not save the note.");
            }
        }

        public OperationResult ExportDocumentNotes(
            DocumentItem document,
            string noteText,
            IEnumerable<HighlightItem> highlights,
            string outputPath)
        {
            if (string.IsNullOrWhiteSpace(outputPath))
            {
                return OperationResult.Failure("Choose a file path before exporting.");
            }

            try
            {
                _markdownExportService.ExportDocumentNotes(
                    document,
                    noteText,
                    highlights,
                    outputPath);

                return OperationResult.Success("Notes exported.");
            }
            catch (Exception)
            {
                return OperationResult.Failure("Could not export notes.");
            }
        }
    }
}

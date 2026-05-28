using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MiniZotero.Models;
using MiniZotero.Repositories;

namespace MiniZotero.Services
{
    public sealed class DocumentImportService : IDocumentImportService
    {
        private readonly IDocumentRepository _documentRepository;

        public DocumentImportService(IDocumentRepository documentRepository)
        {
            _documentRepository = documentRepository;
        }

        public OperationResult<ImportDocumentResult> ImportDocument(
            string filePath,
            IList<DocumentItem> documents)
        {
            if (string.IsNullOrWhiteSpace(filePath))
            {
                return OperationResult<ImportDocumentResult>.Failure("Choose a PDF file to import.");
            }

            try
            {
                var document = _documentRepository.ImportDocument(filePath, documents);
                var existingDocument = documents.FirstOrDefault(existingDocument =>
                    existingDocument.Id == document.Id);
                var status = ImportDocumentStatus.Imported;

                if (existingDocument is null)
                {
                    documents.Add(document);
                }
                else if (existingDocument.IsDeleted)
                {
                    existingDocument.IsDeleted = false;
                    existingDocument.DeletedAt = null;
                    status = ImportDocumentStatus.RestoredFromTrash;
                }
                else
                {
                    status = ImportDocumentStatus.SkippedDuplicate;
                }

                _documentRepository.SaveDocuments(documents);

                return OperationResult<ImportDocumentResult>.Success(
                    new ImportDocumentResult(document, status),
                    GetImportMessage(status, document.Title));
            }
            catch (FileNotFoundException)
            {
                return OperationResult<ImportDocumentResult>.Failure("The selected PDF file no longer exists.");
            }
            catch (IOException)
            {
                return OperationResult<ImportDocumentResult>.Failure("Could not import the PDF file.");
            }
            catch (UnauthorizedAccessException)
            {
                return OperationResult<ImportDocumentResult>.Failure("MiniZotero does not have permission to import this PDF.");
            }
        }

        private static string GetImportMessage(
            ImportDocumentStatus status,
            string title)
        {
            return status switch
            {
                ImportDocumentStatus.Imported => $"Imported {title}.",
                ImportDocumentStatus.RestoredFromTrash => $"Restored {title}.",
                ImportDocumentStatus.SkippedDuplicate => $"{title} is already in the library.",
                _ => "Import finished."
            };
        }
    }
}
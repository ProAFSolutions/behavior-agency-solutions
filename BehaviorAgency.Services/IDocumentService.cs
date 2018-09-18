using BehaviorAgency.Data.Entities;
using BehaviorAgency.Services.Dto;
using BehaviorAgency.Services.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Services
{
    public interface IDocumentService
    {
        DocumentDto GetDocumentById(int documentId);
        List<DocumentDto> GetDocuments(int ownerId);
        DocumentDto AddDocument(DocumentDto document, int userId);
        bool UpdateDocument(DocumentDto document, int userId);
        bool SetDocumentStatus(int docId, DocumentStatusEnum newStatus, int userId);
        void RemoveDocument(int docId);
    }
}

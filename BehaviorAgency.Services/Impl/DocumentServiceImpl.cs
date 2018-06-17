using System;
using System.Collections.Generic;
using System.Text;
using BehaviorAgency.Data.Entities;
using System.Linq;
using BehaviorAgency.Data.Repository;
using BehaviorAgency.Services.Dto;
using BehaviorAgency.Services.Enum;

namespace BehaviorAgency.Services.Impl
{
    public class DocumentServiceImpl : IDocumentService
    {
        private IGlobalRepository<Document> _documentRepository;

        public DocumentServiceImpl(IGlobalRepository<Document> docRepo) {
            _documentRepository = docRepo;
        }

        public DocumentDto GetDocumentById(int documentId)
        {
            if (documentId <= 0) throw new ArgumentOutOfRangeException("Invalid DocumentId");

            var doc = _documentRepository.FindById(documentId);
            return doc != null ? new DocumentDto(doc) : null;
        }

        public List<DocumentDto> GetDocuments(int ownerId)
        {
            if (ownerId <= 0) throw new ArgumentOutOfRangeException("Invalid User Id");

            return _documentRepository.Find(x => x.UserId == ownerId)
                                      .Select(x => new DocumentDto(x))
                                      .ToList();
        }

        public DocumentDto AddDocument(DocumentDto document, int userId)
        {
            throw new NotImplementedException();
        }

        public void RemoveDocument(int docId, int userId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDocument(DocumentDto document, int userId)
        {
            throw new NotImplementedException();
        }

        public void SetDocumentStatus(int docId, DocumentStatusEnum newStatus, int userId)
        {
            throw new NotImplementedException();
        }
    }
}

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
            if (ownerId <= 0) throw new ArgumentOutOfRangeException("Invalid OwnerId");

            return _documentRepository.Find(x => x.UserId == ownerId)
                                      .Select(x => new DocumentDto(x))
                                      .ToList();
        }

        public DocumentDto AddDocument(DocumentDto document, int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException("Invalid User Id");
            if (document == null) throw new ArgumentNullException("Document cannot be null");

            Document created = _documentRepository.Insert(document.MapToEntity(), userId);
            document.DocId = created.DocId;

            return document;
        }

        public bool UpdateDocument(DocumentDto dto, int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException("Invalid User Id");
            if (dto == null) throw new ArgumentNullException("Document cannot be null");

            Document loaded = _documentRepository.FindById(dto.DocId);
            if (loaded == null) throw new ArgumentOutOfRangeException("Invalid Document Id");

            DocumentDto existingDto = new DocumentDto(loaded);
            bool updated = existingDto.Set(dto);
            if (updated) 
                _documentRepository.Update(existingDto.MapToEntity(), userId);
            
            return updated;
        }

        public bool SetDocumentStatus(int docId, DocumentStatusEnum newStatus, int userId)
        {
            if (userId <= 0) throw new ArgumentOutOfRangeException("Invalid User Id");

            Document loaded = _documentRepository.FindById(docId);
            if (loaded == null) throw new ArgumentOutOfRangeException("Invalid Document Id");

            DocumentDto existingDto = new DocumentDto(loaded);
            bool updated = existingDto.SetStatus(newStatus);
            if (updated)
                _documentRepository.Update(existingDto.MapToEntity(), userId);

            return updated;

        }

        public void RemoveDocument(int docId)
        {
            if (docId <= 0) throw new ArgumentOutOfRangeException("Invalid Doc Id");

            //TODO Remove doc physically 

            _documentRepository.Delete(docId);
        }
    }
}

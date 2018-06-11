using System;
using System.Collections.Generic;
using System.Text;
using BehaviorAgency.Data.Entities;
using System.Linq;
using BehaviorAgency.Data.Repository;

namespace BehaviorAgency.Services.Impl
{
    public class DocumentServiceImpl : IDocumentService
    {
        private IGlobalRepository<Document> _documentRepository;

        public DocumentServiceImpl(IGlobalRepository<Document> docRepo) {
            _documentRepository = docRepo;
        }

        public Document GetDocumentById(int documentId)
        {
            return _documentRepository.FindById(documentId);
        }

        public List<Document> GetDocuments(int agencyId, int owner)
        {
            return _documentRepository.Find(x => x.AgencyId == agencyId && x.UserId == owner)
                                      .ToList();
        }
    }
}

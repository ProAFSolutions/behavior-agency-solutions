using BehaviorAgency.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BehaviorAgency.Services
{
    public interface IDocumentService
    {
        Document GetDocumentById(int documentId);

      
    }
}

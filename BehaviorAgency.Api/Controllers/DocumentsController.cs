using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BehaviorAgency.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BehaviorAgency.Services.Dto;

namespace BehaviorAgency.Api.Controllers
{

    [Route("api/documents")]
    public class DocumentsController : ApiController
    {
        private readonly IDocumentService _documentService;

        public DocumentsController(IDocumentService documentService) {
            _documentService = documentService;
        }

        // GET: api/Documents
        [HttpGet]
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Documents/5
        [HttpGet("{id}")]
        public DocumentDto Get(int id)
        {
            return _documentService.GetDocumentById(id);
        }
        
        // POST: api/Documents
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Documents/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

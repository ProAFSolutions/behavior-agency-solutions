using BehaviorAgency.Data.Entities;
using BehaviorAgency.Services.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BehaviorAgency.Services.Dto
{
    public class DocumentDto : IDtoEntityMapper<Document>
    {
        public int DocId { get; set; }
        public string DocName { get; set; }
        public int DocTypeId { get; set; }
        public DocumentCategoryEnum Category{ get; set; }
        public DocumentStatusEnum Status { get; set; }

        private readonly Document _entity;

        public DocumentDto() { }

        public DocumentDto(Document doc) {
            _entity = doc;
        }

        #region Mappers
        public Document MapToEntity()
        {
            return _entity ?? new Document
            {
                DocId = DocId,
                DocName = DocName,
                DocTypeId = DocTypeId,
                DocStatusId = (int)Status,
                DocCategoryId = (int)Category
            };
        }

        public void MapFromEntity()
        {
            DocId = _entity.DocId;
            DocName = _entity.DocName;
            DocTypeId = _entity.DocTypeId;
            Status = (DocumentStatusEnum)_entity.DocStatusId;
            Category = (DocumentCategoryEnum)_entity.DocCategoryId;
        }
        #endregion

        #region Updates

        public bool Set(DocumentDto newDto) {

            bool wasUpdated = SetDocName(newDto.DocName) ||
                              SetDocType(newDto.DocTypeId) || 
                              SetStatus(newDto.Status) ||
                              SetCategory(newDto.Category);

            return wasUpdated;
        }

        public bool SetDocName(string docName) {
            if (DocName != docName)
            {
                _entity.DocName = docName;
                DocName = docName;
                return true;
            }
            return false;
        }

        public bool SetDocType(int docType)
        {
            if (DocTypeId != docType)
            {
                _entity.DocTypeId = docType;
                DocTypeId = docType;
                return true;
            }
            return false;
        }

        public bool SetStatus(DocumentStatusEnum status)
        {
            if (!Status.Equals(status))
            {
                _entity.DocStatusId = (int) status;
                Status = status;
                return true;
            }
            return false;
        }

        public bool SetCategory(DocumentCategoryEnum category)
        {
            if (!Category.Equals(category))
            {
                _entity.DocCategoryId = (int) category;
                Category = category;
                return true;
            }
            return false;
        }

        #endregion
    }
}

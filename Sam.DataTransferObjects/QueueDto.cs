
using Sam.Common.Global.Enums;

namespace Sam.DataTransferObjects
{

    public partial class QueueDto
    {

        public QueueDto(Queue queue)
        {
            Id = queue.Id;
            QueueTypeId = queue.QueueTypeId;
            ListId = queue.ListId;
            UserId = queue.UserId;
            DateSubmitted = queue.DateSubmitted;
            LastUpdate = queue.LastUpdate;
            DateStart = queue.DateStart;
            DateEnd = queue.DateEnd;
            CurrentRow = queue.CurrentRow;
            TotalRows = queue.TotalRows;
            IsDelete = queue.IsDelete;
            IsJson = queue.IsJson;
            RecordString = queue.RecordString;
            ProtectionId = (queue.QueueTypeId == (int)QueueTypes.Protection) ? queue.ProtectionId : null;
            CustomAttributeId = (queue.QueueTypeId == (int)QueueTypes.Attribute) ? queue.CustomAttributeId : null;
            ActionTitle = queue.ActionTitle;
            Message = queue.Message;
            IsError = queue.IsError;
        }
        
        public void Clear()
        {
            Id = 0;
            QueueTypeId = 0;
            ListId = 0;
            UserId = 0;
            TotalRows = 0;
            CurrentRow = 0;
            IsDelete = false;
            IsJson = false;
            IsError = false;
            RecordString = String.Empty;
            Message = String.Empty;
            ProtectionId = 0;
            CustomAttributeId = 0;
            LastUpdate = null;
            DateStart = null;
            DateEnd = null;
            DateSubmitted = DateTime.Now;
            ActionTitle = string.Empty;
        }

        public Queue ToQueue()
        {
            return this.ToEntity();
        }
        
    }
}

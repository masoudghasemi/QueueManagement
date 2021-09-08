using System;
using System.Collections.Generic;

#nullable disable

namespace QueueManagement.DAL.QueueManagementDb.Entity
{
    public partial class Message
    {
        public Message()
        {
            InverseRelatedMessage = new HashSet<Message>();
        }

        public long Id { get; set; }
        public string Identity { get; set; }
        public int QueueId { get; set; }
        public int ProducerId { get; set; }
        public string BodyJson { get; set; }
        public byte[] BodyBinary { get; set; }
        public DateTime InsertedAt { get; set; }
        public string InsertedBy { get; set; }
        public long? RelatedMessageId { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual Queue Queue { get; set; }
        public virtual Message RelatedMessage { get; set; }
        public virtual ICollection<Message> InverseRelatedMessage { get; set; }
    }
}

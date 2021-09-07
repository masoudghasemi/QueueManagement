using System;
using System.Collections.Generic;

#nullable disable

namespace QueueManagement.DAL.QueueManagementDb.Entity
{
    public partial class Message
    {
        public long Id { get; set; }
        public string Identity { get; set; }
        public int QueueId { get; set; }
        public int ProducerId { get; set; }
        public string BodyJson { get; set; }
        public byte[] BodyBinary { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? DeletedAt { get; set; }

        public virtual Client Producer { get; set; }
        public virtual Queue Queue { get; set; }
    }
}

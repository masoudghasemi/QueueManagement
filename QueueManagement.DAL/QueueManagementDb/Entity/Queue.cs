using System;
using System.Collections.Generic;

#nullable disable

namespace QueueManagement.DAL.QueueManagementDb.Entity
{
    public partial class Queue
    {
        public Queue()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string NameFa { get; set; }
        public string NameEn { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace QueueManagement.DAL.QueueManagementDb.Entity
{
    public partial class Producer
    {
        public Producer()
        {
            Messages = new HashSet<Message>();
        }

        public int Id { get; set; }
        public string NameFa { get; set; }
        public string NameEn { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}

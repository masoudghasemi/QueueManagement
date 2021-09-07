using QueueManagement.DAL.QueueManagementDb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.DAL.QueueManagementDb.UnitOfWork
{
    public interface IQueueManagementUnitOfWork: Framework.Contract.IUnitOfWork<QueueManagementDb.Entity.QueueManagementContext>
    {
        public IMessageRepository MessageRepository { get; }

    }
}

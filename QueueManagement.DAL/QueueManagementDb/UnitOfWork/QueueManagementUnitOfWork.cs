using QueueManagement.DAL.QueueManagementDb.Entity;
using QueueManagement.DAL.QueueManagementDb.Repository.Concrete;
using QueueManagement.DAL.QueueManagementDb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.DAL.QueueManagementDb.UnitOfWork
{
    public class QueueManagementUnitOfWork : IQueueManagementUnitOfWork
    {


        private bool disposed = false;

        protected readonly QueueManagementContext context;

        protected  IMessageRepository _messageRepository;




        public QueueManagementUnitOfWork(QueueManagementContext context)
        {
            this.context = context;
        }


        public IMessageRepository MessageRepository
        {
            get
            {
                if (_messageRepository == null)
                {
                    _messageRepository = new MessageRepository(context);
                }
                return _messageRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        private void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (context != null)
                    {
                        context.Dispose();
                    }
                }
            }
            disposed = true;
        }

        public async Task SaveAsync()
        {
            await Task.Run(() =>
            {
                this.Save();
            });
        }
    }
}

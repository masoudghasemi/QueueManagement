using QueueManagement.DAL.QueueManagementDb.Entity;
using QueueManagement.DAL.QueueManagementDb.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueManagement.DAL.QueueManagementDb.Repository.Concrete
{
    public class MessageRepository : IMessageRepository
    {

        protected readonly QueueManagementContext context;


        public MessageRepository(QueueManagementContext context)
        {
            this.context = context;
        }


        public void Add(Message obj)
        {
            context.Messages.Add(obj);

        }

        public async Task AddAsync(Message obj)
        {
            await Task.Run(() =>
            {
                Add(obj);
            });
        }

        public void Delete(Message obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Message obj)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Message> Get()
        {
            throw new NotImplementedException();
        }

        public Message Get(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Message>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Message> GetAsync(long id)
        {
            throw new NotImplementedException();
        }

        public void Update(Message obj)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Message obj)
        {
            throw new NotImplementedException();
        }
    }
}

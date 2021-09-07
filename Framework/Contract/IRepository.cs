using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contract
{
    public interface IRepository<TEntity>
    {

        IQueryable<TEntity> Get();
        Task<IQueryable<TEntity>> GetAsync();
        TEntity Get(long id);
        Task<TEntity> GetAsync(long id);
        void Add(TEntity obj);
        Task AddAsync(TEntity obj);
        void Delete(TEntity obj);
        Task DeleteAsync(TEntity obj);
        void Delete(long id);
        Task DeleteAsync(long id);
        void Update(TEntity obj);
        Task UpdateAsync(TEntity obj);
    }
}

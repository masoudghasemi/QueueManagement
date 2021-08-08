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

        TEntity Get(long id);

        void Add(TEntity obj);
        void Delete(TEntity obj);

        void Delete(long id);

        void Update(TEntity obj);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Contract
{
    public interface IUnitOfWork<TContext> : IDisposable
    {
        void Save();
        Task SaveAsync();
    }
}

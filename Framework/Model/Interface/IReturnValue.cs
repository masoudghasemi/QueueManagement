using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model.Interface
{
    public interface IReturnValue<TReturnEntity>
    {
        public TReturnEntity Value { get; set; }

        public bool HasError { get; set; }

        public ICollection<IErrorValue> Errors { get; set; }

        public string Message { get; set; }

    }
}

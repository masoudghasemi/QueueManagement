using Framework.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model.Concrete
{
    class ReturnValue<TReturnEntity> : IReturnValue<TReturnEntity>
    {
        public TReturnEntity Value { get; set; }

        public bool HasError { get; set; }

        public ICollection<IErrorValue> Errors { get; set; }

        public string Message { get; set; }

    }
}

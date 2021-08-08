using Framework.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model.Concrete
{
    public  class ErrorValue: IErrorValue
    {

        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

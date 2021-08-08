using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Model.Interface
{
    public interface IErrorValue
    {
        public string Code { get; set; }
        public  string Title { get; set; }
        public  string Description { get; set; }
    }
}

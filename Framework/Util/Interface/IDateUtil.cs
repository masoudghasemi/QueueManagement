using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Util.Interface
{
    public interface IDateUtil
    {

        string DateTimeToPersianDate(DateTime? dateTime, char divider);
        DateTime? PersianDateToDateTime(string persianDate, char dateDivider);


    }
}

using Framework.Util.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Util.Concrete
{
    class DateUtil : IDateUtil
    {
        public string DateTimeToPersianDate(DateTime? dateTime, char dateDivider)
        {
            if (dateTime == null) return string.Empty;

            var dt = (DateTime)dateTime;
            PersianCalendar pc = new PersianCalendar();
            var persianDate =
                pc.GetDayOfMonth(dt).ToString()
                + dateDivider
                + pc.GetMonth(dt)
                + dateDivider
                + pc.GetYear(dt)
                + "  "
                + dt.Hour.ToString()
                + ':'
                + dt.Minute.ToString()
                + ':'
                + dt.Second.ToString();
            return persianDate;
        }



        public DateTime? PersianDateToDateTime(string persianDate, char dateDivider)
        {
            try
            {

                var part = persianDate.Split(dateDivider);

                PersianCalendar pc = new PersianCalendar();
                return pc.ToDateTime(
                    int.Parse(part[0]),
                    int.Parse(part[1]),
                    int.Parse(part[2]),
                    0,
                    0,
                    0,
                    0
                    );

            }
            catch (Exception ex)
            {
                return null;
            }


        }
    }
}

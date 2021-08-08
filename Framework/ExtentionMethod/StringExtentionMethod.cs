using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.ExtentionMethod
{
    public static class StringExtentionMethod
    {
        public static string ConvertFaToEn(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            return input.Replace('۰', '0')
                .Replace('۱', '1')
                .Replace('۲', '2')
                .Replace('۳', '3')
                .Replace('۴', '4')
                .Replace('۵', '5')
                .Replace('۶', '6')
                .Replace('۷', '7')
                .Replace('۸', '8')
                .Replace('۹', '9');
            
        }
    }
}

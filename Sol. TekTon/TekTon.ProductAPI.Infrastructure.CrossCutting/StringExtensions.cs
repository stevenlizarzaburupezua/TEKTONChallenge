using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.Infrastructure.CrossCutting
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string str) => string.IsNullOrEmpty(str) ? false : new Regex("^[0-9]([.,][0-9]{1,3})?$").IsMatch(str);
    }
}

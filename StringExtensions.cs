using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppКУРСОВАЯ
{
    static class StringExtensions
    {
        public static string PadCenter(this string str, int totalLength)
        {
            int padding = totalLength - str.Length;
            if (padding <= 0) return str;
            int leftPadding = padding / 2;
            int rightPadding = padding - leftPadding;
            return new string(' ', leftPadding) + str + new string(' ', rightPadding);
        }
    }
}

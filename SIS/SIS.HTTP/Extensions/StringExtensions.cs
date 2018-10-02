using System;

namespace SIS.HTTP.Extensions
{
    public static class StringExtensions
    {
        public static string Capitalize(string inputString)
        {
            return Char.ToUpper(inputString[0]) + inputString.Substring(1).ToLower();
        }
    }
}
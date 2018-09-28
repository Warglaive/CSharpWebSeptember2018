using System;
using System.Net;

namespace _01.URL_Decode
{
    public class Program
    {
        public static void Main()
        {
            var encodedUrl = Console.ReadLine();
            Console.WriteLine(WebUtility.UrlDecode(encodedUrl));
        }
    }
}
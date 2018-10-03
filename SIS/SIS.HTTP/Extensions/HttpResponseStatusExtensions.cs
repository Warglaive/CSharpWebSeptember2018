using System.Net;
using SIS.HTTP.Enums;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpResponseStatusCode httpResponseStatus)
        {
            return $"{(int)httpResponseStatus} {httpResponseStatus}";
        }
    }
}
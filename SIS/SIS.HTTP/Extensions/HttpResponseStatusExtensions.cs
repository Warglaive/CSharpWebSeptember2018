using System.Net;

namespace SIS.HTTP.Extensions
{
    public static class HttpResponseStatusExtensions
    {
        public static string GetResponseLine(this HttpStatusCode httpResponseStatus)
        {
            return $"{(int)httpResponseStatus} {httpResponseStatus}";
        }
    }
}
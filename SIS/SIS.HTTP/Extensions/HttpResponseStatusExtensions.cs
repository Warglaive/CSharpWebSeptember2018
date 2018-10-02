using SIS.HTTP.Enums;

namespace SIS.HTTP.Extensions
{
    public class HttpResponseStatusExtensions
    {
        public HttpResponseStatusCode GetResponseLine()
        {
            return new HttpResponseStatusCode();
        }
    }
}
using System;
using System.Linq;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public IHttpCookieCollection Cookies { get; }
        public HttpResponse()
        {
        }
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
            this.Cookies = new HttpCookieCollection();
        }

        public HttpResponseStatusCode StatusCode { get; set; }
        public IHttpHeaderCollection Headers { get; }
        public byte[] Content { get; set; }

        public void AddCookie(HttpCookie cookie)
        {
            this.Cookies.Add(cookie);
        }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            var arr = Encoding.UTF8.GetBytes(this.ToString()).Concat(this.Content)
                .ToArray();
            return arr;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode.GetResponseLine()}")
                .Append(Environment.NewLine)
                .Append(this.Headers).Append(Environment.NewLine);


            if (this.Cookies.HasCookies())
            {
                result.Append($"Set-Cookie: {this.Cookies}").Append(Environment.NewLine);
            }
            result.Append(Environment.NewLine);
            return result.ToString();
        }
    }
}
using System;
using System.Text;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Responses
{
    public class HttpResponse : IHttpResponse
    {
        public HttpResponse()
        {

        }
        public HttpResponse(HttpResponseStatusCode statusCode)
        {
            this.Headers = new HttpHeaderCollection();
            this.Content = new byte[0];
            this.StatusCode = statusCode;
        }
        public HttpResponseStatusCode StatusCode { get; set; }

        public IHttpHeaderCollection Headers { get; }
        public byte[] Content { get; set; }

        public void AddHeader(HttpHeader header)
        {
            this.Headers.Add(header);
        }

        public byte[] GetBytes()
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            //status code bug.
            var result = new StringBuilder();
            result.Append($"{GlobalConstants.HttpOneProtocolFragment} {this.StatusCode}")
                .Append(Environment.NewLine)
                .Append(this.Headers).Append(Environment.NewLine)
                .Append(Environment.NewLine);
            return result.ToString();
        }
    }
}
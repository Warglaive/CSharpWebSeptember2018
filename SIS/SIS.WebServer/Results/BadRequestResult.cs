using System;
using System.Text;
using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Results
{
    public class BadRequestResult : HttpResponse
    {
        private const string DefaultErrorHeading = "<h1>Error, see details for more info.</h1>";

        public BadRequestResult(string content, HttpResponseStatusCode response)
        {
            content = DefaultErrorHeading + Environment.NewLine + content;
            this.Headers.Add(new HttpHeader(HttpHeader.ContentType, "text/html"));
            this.Content = Encoding.UTF8.GetBytes(content);
        }
    }
}
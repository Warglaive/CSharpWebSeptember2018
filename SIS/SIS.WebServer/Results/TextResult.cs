﻿using SIS.HTTP.Enums;
using SIS.HTTP.Headers;
using SIS.HTTP.Responses;

namespace SIS.WebServer.Results
{
    public class TextResult : HttpResponse
    {
        public TextResult(string content, HttpResponseStatusCode responseStatusCode)
        : base(responseStatusCode)
        {
            this.Headers.Add(new HttpHeader("Content-Type", "text/plain"));
        }
    }
}
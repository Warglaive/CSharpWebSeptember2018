using System;
using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();
        }
        public string Path { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, object> FormData { get; }
        public Dictionary<string, object> QueryData { get; }
        public IHttpHeaderCollection Headers { get; }
        public HttpRequestMethod RequestMethod { get; private set; }

        public void ParseRequest(string requestString)
        {
            var splitRequestContent = requestString.Split(new[] { ' ' },
                StringSplitOptions.None);

            var requestLine = splitRequestContent[0].Trim()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestLine(requestLine))
            {
                throw new BadRequestException();
            }
            this.ParseRequestMethod(requestLine);
            this.ParseRequestUrl(requestLine);
            this.ParseRequestPath();
            this.ParseHeaders(splitRequestContent);
            this.ParseRequestParameters(requestString);

        }

        public bool IsValidRequestLine(string[] requestLine)
        {
            return requestLine.Length == 3 && requestLine[2] == GlobalConstants.HttpOneProtocolFragment;
        }

        public bool IsValidRequestQueryString(string queryString, string[] queryParameters)
        {
            return string.IsNullOrEmpty(queryString) && queryParameters.Any();
        }

        public void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }

            var isParsed = Enum.TryParse<HttpRequestMethod>(requestLine[0], out var parsedMethod);

            if (!isParsed)
            {
                throw new BadRequestException();

            }
            this.RequestMethod = parsedMethod;

        }

        public void ParseRequestUrl(string[] requestLine)
        {
            var url = requestLine[1];
            var uri = new Uri(url);
            if (uri.AbsoluteUri.Length <= 0)
            {
                throw new BadRequestException();
            }
            this.Url = uri.AbsolutePath;
        }

        public void ParseRequestPath()
        {
            var requestUrl = this.Url;
            if (string.IsNullOrEmpty(requestUrl))
            {
                throw new BadRequestException();
            }
            var uri = new Uri(requestUrl);
            if (uri.AbsolutePath.Length <= 0)
            {
                throw new BadRequestException();
            }
            this.Path = uri.AbsolutePath;
        }

        public void ParseHeaders(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }
            foreach (var line in requestLine.Skip(1))
            {
                if (string.IsNullOrEmpty(line))
                {
                    throw new BadRequestException();
                }

                var kvp = line.Split(" :", StringSplitOptions.RemoveEmptyEntries);

                var header = new HttpHeader(kvp[0], kvp[1]);
                this.Headers.Add(header);
            }
        }

        public void ParseQueryParameters()
        {
            //Does nothing if the Request’s Url contains NO Query string.
            if (this.Url == "")
            {
                return;
            }

            var uri = new Uri(this.Url);
            var queryString = uri.Query;

            var queryParameters = queryString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (!IsValidRequestQueryString(queryString, queryParameters))
            {
                throw new BadRequestException();
            }

            this.QueryData.Add(queryParameters[0], queryParameters[1]);
        }

        public void ParseFormDataParameters(string requestBody)
        {
            if (requestBody == "")
            {
                return;
            }
            var bodyParams = requestBody.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            this.FormData.Add(bodyParams[0], bodyParams[1]);
        }

        public void ParseRequestParameters(string requestBody)
        {
            var uri = new Uri(requestBody);
            var url = uri.AbsoluteUri;
            ParseQueryParameters();
            ParseFormDataParameters(requestBody);
        }
    }
}
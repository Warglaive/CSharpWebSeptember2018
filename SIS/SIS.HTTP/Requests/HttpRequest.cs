using System;
using System.Collections.Generic;
using System.Linq;
using SIS.HTTP.Common;
using SIS.HTTP.Enums;
using SIS.HTTP.Exceptions;
using SIS.HTTP.Extensions;
using SIS.HTTP.Headers;

namespace SIS.HTTP.Requests
{
    public class HttpRequest : IHttpRequest
    {
        private const char HttpRequestUrlQuerySeparator = '?';

        private const char HttpRequestUrlFragmentSeparator = '#';

        private const string HttpRequestHeaderNameValueSeparator = ": ";

        private const string HttpRequestCookiesSeparator = "; ";

        private const char HttpRequestCookieNameValueSeparator = '=';

        private const char HttpRequestParameterSeparator = '&';

        private const char HttpRequestParameterNameValueSeparator = '=';

        public HttpRequest(string requestString)
        {
            this.FormData = new Dictionary<string, object>();
            this.QueryData = new Dictionary<string, object>();
            this.Headers = new HttpHeaderCollection();

            this.ParseRequest(requestString);
        }
        public string Path { get; private set; }
        public string Url { get; private set; }
        public Dictionary<string, object> FormData { get; }
        public Dictionary<string, object> QueryData { get; }
        public IHttpHeaderCollection Headers { get; }
        public HttpRequestMethod RequestMethod { get; private set; }

        public void ParseRequest(string requestString)
        {
            string[] splitRequestContent = requestString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

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
            return !string.IsNullOrEmpty(queryString) && queryParameters.Any();
        }

        public void ParseRequestMethod(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }
            
            var isParsed = Enum.TryParse<HttpRequestMethod>(requestLine[0].Capitalize(), out var parsedMethod);

            if (!isParsed)
            {
                throw new BadRequestException();

            }
            this.RequestMethod = parsedMethod;

        }

        public void ParseRequestUrl(string[] requestLine)
        {
            var url = requestLine[1];
            if (url.Length <= 0)
            {
                throw new BadRequestException();
            }
            this.Url = url;
        }

        public void ParseRequestPath()
        {
            this.Path = this.Url.Split(new[] { HttpRequestUrlQuerySeparator, HttpRequestUrlFragmentSeparator },
                StringSplitOptions.RemoveEmptyEntries)[0];
        }

        public void ParseHeaders(string[] requestLine)
        {
            if (!requestLine.Any())
            {
                throw new BadRequestException();
            }
            foreach (var line in requestLine.Skip(1))
            {
                if (line == "")
                {
                    break;
                }
                var kvp = line.Split(": ", StringSplitOptions.RemoveEmptyEntries);

                var header = new HttpHeader(kvp[0], kvp[1]);
                this.Headers.Add(header);
            }

            if (!this.Headers.ContainsHeader(GlobalConstants.HostHeaderKey))
            {
                throw new BadRequestException();
            }
        }

        public void ParseQueryParameters()
        {
            if (!this.Url.Contains('?'))
            {
                return;
            }
            var queryString = this.Url.Split('?', '#')[0];

            var queryParameters = queryString.Split('&');

            if (!IsValidRequestQueryString(queryString, queryParameters))
            {
                throw new BadRequestException();
            }

            foreach (var queryParameter in queryParameters)
            {
                var parameterArguments = queryParameter.Split('=', StringSplitOptions.RemoveEmptyEntries);

                this.QueryData.Add(parameterArguments[0], parameterArguments[1]);
            }
        }

        public void ParseFormDataParameters(string formData)
        {
            if (string.IsNullOrEmpty(formData))
            {
                return;
            }
            var formDataParams = formData.Split(HttpRequestParameterSeparator);
            foreach (var formDataParam in formDataParams)
            {
                var paramArguments = formDataParam.Split(HttpRequestHeaderNameValueSeparator,
                    StringSplitOptions.RemoveEmptyEntries);

                this.FormData.Add(paramArguments[0], paramArguments[1]);
            }
        }

        public void ParseRequestParameters(string requestBody)
        {
            ParseQueryParameters();
            ParseFormDataParameters(requestBody);
        }
    }
}
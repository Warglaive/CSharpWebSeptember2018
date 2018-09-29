using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Headers
{
    public class HttpHeaderCollection : IHttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
        {
            this.headers = new Dictionary<string, HttpHeader>();
        }

        public void Add(HttpHeader header)
        {
            var value = GetHeader(header.Key);
            this.headers.Add(header.Key, value);
        }

        public bool ContainsHeader(string key)
        {
            return this.headers.Any(x => x.Key == key);
        }

        public HttpHeader GetHeader(string key)
        {
            var header = this.headers.FirstOrDefault(x => x.Key == key).Value;
            return header;
        }
    }
}
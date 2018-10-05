using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Cookies
{
    public class HttpCookieCollection : IHttpCookieCollection
    {
        private Dictionary<string, HttpCookie> HttpCookies;

        public HttpCookieCollection()
        {
            this.HttpCookies = new Dictionary<string, HttpCookie>();
        }
        public void Add(HttpCookie cookie)
        {
            this.HttpCookies.Add(cookie.Key, cookie);
        }

        public bool ContainsCookie(string key)
        {
            return this.HttpCookies.Any(x => x.Key == key);
        }

        public HttpCookie GetCookie(string key)
        {
            return this.HttpCookies.First(x => x.Key == key).Value;
        }

        public bool HasCookies()
        {
            return this.HttpCookies.Any();
        }

        public override string ToString()
        {
            return string.Join("; ", this.HttpCookies.Values);
        }
    }
}
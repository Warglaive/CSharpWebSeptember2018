using System.Collections.Generic;
using System.Linq;

namespace SIS.HTTP.Sessions
{
    public class HttpSession : IHttpSession
    {
        private readonly Dictionary<string, object> Parameters;

        public HttpSession(string id)
        {
            this.Parameters = new Dictionary<string, object>();
            this.Id = id;
        }

        public string Id { get; }

        public object GetParameter(string name)
        {
            return this.Parameters.First(x => x.Key == name);
        }

        public bool ContainsParameter(string name)
        {
            return this.Parameters.Any(x => x.Key == name);
        }

        public void AddParameter(string name, object parameter)
        {
            this.Parameters.Add(name, parameter);
        }

        public void ClearParameters()
        {
            this.Parameters.Clear();
        }
    }
}
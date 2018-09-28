using System;
using System.Linq;
using System.Net;

namespace _02.Validate_URL
{
    public class Program
    {
        public static void Main()
        {
            var encodedUrl = Console.ReadLine();
            var decodedUrl = WebUtility.UrlDecode(encodedUrl);

            var isValid = Uri.TryCreate(decodedUrl, UriKind.Absolute, out var uri);
            if (isValid)
            {
                var protocol = uri.Scheme;
                var host = uri.Host;
                var port = uri.Port;
                var path = uri.AbsolutePath;
                var query = uri.Query;
                var fragment = uri.Fragment;
                ProtocolPortValidation(protocol, port);

                Console.WriteLine($"Protocol: {protocol}"
                                  + Environment.NewLine +
                                  $"Host: {host}"
                                  + Environment.NewLine +
                                  $"Port: {port}");
                if (!path.Any())
                {
                    Console.WriteLine("Path: /");
                }
                else
                {
                    Console.WriteLine($"Path: {path}");
                }

                if (query.Any())
                {
                    var formattedQuery = query.Substring(1, query.Length - 1);
                    Console.WriteLine($"Query: {formattedQuery}");
                }

                if (fragment.Any())
                {
                    var formattedFragment = fragment.Substring(1, fragment.Length - 1);
                    Console.WriteLine($"Fragment: {formattedFragment}");
                }
            }
            else
            {
                Console.WriteLine("Invalid URL");
            }
        }

        private static void ProtocolPortValidation(string protocol, int port)
        {
            if (protocol == "http" && port != 80)
            {
                Console.WriteLine("Invalid URL");
                Environment.Exit(0);
            }
            else if (protocol == "https" && port != 443)
            {
                Console.WriteLine("Invalid URL");
                Environment.Exit(0);
            }
        }
    }
}
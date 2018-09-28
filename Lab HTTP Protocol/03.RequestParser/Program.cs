using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.RequestParser
{
    public class Program
    {
        private const string ContentType = "text/plain";
        public static void Main()
        {
            var pathMethods = new Dictionary<string, HashSet<string>>();

            var input = Console.ReadLine();
            while (input != "END")
            {
                var inputParts = input.Split('/', StringSplitOptions.RemoveEmptyEntries);
                var path = inputParts[0];
                var method = inputParts[1];
                if (!pathMethods.ContainsKey(path))
                {
                    pathMethods[path] = new HashSet<string>();
                }

                pathMethods[path].Add(method);

                input = Console.ReadLine();
            }

            var inputWanted = Console.ReadLine();
            var inputWantedParts = inputWanted.Split(new[] { ' ', '/' }, StringSplitOptions.RemoveEmptyEntries);

            var pathNeeded = inputWantedParts[1];
            var methodNeeded = inputWantedParts[0].ToLower();
            var protocol = inputWantedParts[2];
            var protocolVersion = inputWantedParts[3];

            var statusCode = "404 Not Found";
            var contentLength = 8;
            if (pathMethods.ContainsKey(pathNeeded))
            {
                foreach (var method in pathMethods.Where(x => x.Key == pathNeeded))
                {
                    if (method.Value.Contains(methodNeeded))
                    {
                        statusCode = "200 OK";
                        contentLength = 2;
                    }
                }
            }

            PrintResult(protocol, protocolVersion, statusCode, contentLength);
        }

        private static void PrintResult(string protocol, string protocolVersion, string statusCode, int contentLength)
        {
            Console.WriteLine();
            Console.WriteLine("Result:" + new string('-', 20));
            Console.WriteLine();
            var sucessMessage = $"{protocol}/{protocolVersion} {statusCode}"
                                + Environment.NewLine + $"Content-Length: {contentLength}"
                                + Environment.NewLine + $"Content-Type: {ContentType}"
                                + Environment.NewLine
                                + Environment.NewLine + $"{statusCode.Substring(4)}";
            Console.WriteLine(sucessMessage);
        }
    }
}
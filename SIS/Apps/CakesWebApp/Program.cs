using SIS.Demo;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Routing;

namespace CakesWebApp
{
    public class Program
    {
        public static void Main()
        {
            ServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index();
            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
using RunesApp.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;

namespace RunesApp
{
    public class RunesStartUp
    {
        public static void Main()
        {
            var serverRoutingTable = new ServerRoutingTable();

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new
                RedirectResult("/Home/Index");

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Home/Index"] = request => new
                HomeController().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Login"] =
                request => new UsersController().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/Users/Register"] =
                request => new UsersController().Register(request);

            var server = new Server(8000, serverRoutingTable);
            server.Run();

        }
    }
}
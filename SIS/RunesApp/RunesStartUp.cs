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

            ConfigureRouting(serverRoutingTable);

            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }

        private static void ConfigureRouting(ServerRoutingTable serverRoutingTable)
        {
            //GET
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new
                RedirectResult("/home/index");

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/home/index"] = request => new
                HomeController().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/login"] =
                request => new UsersController().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/users/register"] =
                request => new UsersController().Register(request);

            //POST
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/login"] =
                request => new UsersController().PostLogin(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/users/register"] =
                request => new UsersController().PostRegister(request);
        }
    }
}
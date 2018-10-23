using CakesApp.Controllers;
using SIS.HTTP.Enums;
using SIS.WebServer;
using SIS.WebServer.Results;
using SIS.WebServer.Routing;

namespace CakesApp
{
    public class StartUp
    {
        public static void Main()
        {
            //GET
            var serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/index"] = request => new RedirectResult("/");

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] = request => new AccountController().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] = request => new AccountController().Register(request);

            //POST
            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] = request => new AccountController().DoRegister(request);

            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
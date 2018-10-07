﻿using CakesWebApp.Controllers;
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

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/"] = request => new HomeController().Index(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/register"] = request => new
                  AccountController().Register(request);

            serverRoutingTable.Routes[HttpRequestMethod.Get]["/login"] = request => new
                  AccountController().Login(request);

            serverRoutingTable.Routes[HttpRequestMethod.Post]["/register"] = request => new
                AccountController().DoRegister(request);

            var server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
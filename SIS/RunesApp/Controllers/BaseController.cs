using System.IO;
using System.Runtime.CompilerServices;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace RunesApp.Controllers
{
    public abstract class BaseController
    {
        private const string RootDirectoryRelativePath = "../../../";
        private const string ControllerDefaultName = "Controller";
        private const string DirectorySeparator = "/";
        private const string ViewsFolderName = "Views";
        private const string HtmlFileExtension = ".html";
        private string CurrentControllerName() => this.GetType().Name.Replace(ControllerDefaultName, string.Empty);

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            //Not working - idk why ;/
            //    var filePath = RootDirectoryRelativePath
            //                   + ViewsFolderName
            //                   + DirectorySeparator
            //                   + this.CurrentControllerName()
            //                   + DirectorySeparator
            //                   + viewName
            //                   + HtmlFileExtension;

            var filePath = ViewsFolderName + DirectorySeparator + CurrentControllerName() + DirectorySeparator +
                           viewName + HtmlFileExtension;

            if (!File.Exists(filePath))
            {
                return new BadRequestResult($"view: {viewName} not found", HttpResponseStatusCode.NotFound);
            }

            var fileContent = File.ReadAllText(filePath);
            return new HtmlResult(fileContent, HttpResponseStatusCode.Ok);
        }
    }
}
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using RunesApp.Data;
using RunesApp.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace RunesApp.Controllers
{
    public abstract class BaseController
    {
        protected IDictionary<string, string> ViewBag { get; set; }

        protected RunesDbContext Db { get; set; }
        public HashService HashService { get; set; }
        public UserCookieService userCookieService { get; set; }
        public BaseController()
        {
            this.Db = new RunesDbContext();
            this.HashService = new HashService();
            this.userCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        public void SignInUser(string username, IHttpResponse response, IHttpRequest request)
        {
            request.Session.AddParameter(username, username);
            var userCookieValue = this.userCookieService.GetUserCookie(username);
            response.AddCookie(new HttpCookie("IRunes_auth", userCookieValue));
        }

        // private const string RootDirectoryRelativePath = "../../../";
        private const string ControllerDefaultName = "Controller";
        private const string DirectorySeparator = "/";
        private const string ViewsFolderName = "Views";
        private const string HtmlFileExtension = ".html";
        private const string RenderBodyDefaultName = "@RenderBody()";

        private string CurrentControllerName() => this.GetType().Name.Replace(ControllerDefaultName, string.Empty);

        protected IHttpResponse View([CallerMemberName] string viewName = "")
        {
            var filePath = ViewsFolderName + DirectorySeparator + CurrentControllerName() + DirectorySeparator +
                           viewName + HtmlFileExtension;

            if (!File.Exists(filePath))
            {
                return new BadRequestResult($"view: {viewName} not found", HttpResponseStatusCode.NotFound);
            }

            var layoutContent = File.ReadAllText(ViewsFolderName + DirectorySeparator + "_Layout.html");

            var fileContent = File.ReadAllText(filePath);

            var allContent = layoutContent.Replace(RenderBodyDefaultName, fileContent);

            foreach (var viewBagKey in ViewBag.Keys)
            {
                var dynamicPlaceholder = $"{{{viewBagKey}}}";

                if (allContent.Contains(dynamicPlaceholder))
                {
                    allContent = allContent.Replace(dynamicPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            return new HtmlResult(allContent, HttpResponseStatusCode.Ok);
        }
        public bool IsAuthenticated(IHttpRequest request)
        {
            return request.Session.ContainsParameter("username");
        }

        protected IHttpResponse BadRequestError(string errorMessage)
        {
            return new HtmlResult(errorMessage, HttpResponseStatusCode.BadRequest);
        }
        protected IHttpResponse ServerError(string errorMessage)
        {
            return new HtmlResult(errorMessage, HttpResponseStatusCode.InternalServerError);
        }
    }
}
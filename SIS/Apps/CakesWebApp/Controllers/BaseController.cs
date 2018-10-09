using System.Collections.Generic;
using System.IO;
using CakesWebApp.Data;
using CakesWebApp.Services;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace CakesWebApp.Controllers
{
    public abstract class BaseController
    {
        protected IDictionary<string, string> ViewBag { get; set; }

        protected BaseController()
        {
            this.Db = new CakesDbContext();
            this.UserCookieService = new UserCookieService();
            this.ViewBag = new Dictionary<string, string>();
        }

        protected CakesDbContext Db { get; }
        protected IUserCookieService UserCookieService { get; }

        protected string GetUsername(IHttpRequest request)
        {
            if (!request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return null;
            }

            var cookie = request.Cookies.GetCookie(".auth-cakes");
            var cookieContent = cookie.Value;
            var username = this.UserCookieService.GetUserData(cookieContent);
            return username;
        }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText("Views/" + viewName + ".html");
            foreach (var viewBagKey in this.ViewBag.Keys)
            {
                //
                var dynamicDataPlaceholder = $"{{{viewBagKey}}}";

                if (content.Contains(dynamicDataPlaceholder))
                {
                    content = content.Replace(dynamicDataPlaceholder, this.ViewBag[viewBagKey]);
                }
            }

            return new HtmlResult(content, HttpResponseStatusCode.Ok);
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
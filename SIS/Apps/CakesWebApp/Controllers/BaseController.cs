using System.IO;
using CakesWebApp.Data;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace CakesWebApp.Controllers
{
    public abstract class BaseController
    {
        protected BaseController()
        {
            this.Db = new CakesDbContext();
        }
        protected CakesDbContext Db { get; }

        protected IHttpResponse View(string viewName)
        {
            var content = File.ReadAllText("Views/" + viewName + ".html");
            return new HtmlResult(content, HttpResponseStatusCode.Ok);
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
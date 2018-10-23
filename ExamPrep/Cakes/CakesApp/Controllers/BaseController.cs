using System.IO;
using CakesApp.Data;
using CakesApp.Services;
using SIS.HTTP.Enums;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace CakesApp.Controllers
{
    public abstract class BaseController
    {
        private const string ViewsFolderName = "Views";
        private const string FolderSeparator = "/";
        private const string FileHtmlExtension = ".html";

        protected IHashService HashService { get; }
        protected CakesDbContext Db { get; }

        public BaseController()
        {
            this.HashService = new HashService();
            this.Db = new CakesDbContext();
        }
        protected IHttpResponse View(string fileName)
        {
            var fileFullPath = ViewsFolderName + FolderSeparator + fileName + FileHtmlExtension;

            var viewContent = File.ReadAllText(fileFullPath);
            return new HtmlResult(viewContent, HttpResponseStatusCode.Ok);
        }
    }
}
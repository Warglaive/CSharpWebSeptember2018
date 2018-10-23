using System;
using System.Linq;
using CakesApp.Models;
using SIS.HTTP.Enums;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace CakesApp.Controllers
{
    public class AccountController : BaseController
    {
        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            var username = request.FormData["fullName"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();
            if (string.IsNullOrWhiteSpace(username) || username.Length < 4)
            {
                return new BadRequestResult("<h1>Invalid username!</h1>",
                    HttpResponseStatusCode.BadRequest);
            }

            if (this.Db.Users.FirstOrDefault(x => x.Username == username) != null)
            {
                return new BadRequestResult("<h1>Username already exists!</h1>",
                    HttpResponseStatusCode.BadRequest);
            }
            if (password == confirmPassword)
            {
                if (password.Length < 6 || string.IsNullOrEmpty(password))
                {
                    return new BadRequestResult("<h1>Username must be 6 or more characters</h1>",
                        HttpResponseStatusCode.BadRequest);
                }
                password = this.HashService.Hash(password);
            }
            else
            {
                return new BadRequestResult("<h1>passwords doesn't match!</h1>",
                    HttpResponseStatusCode.BadRequest);
            }

            //add validation
            this.Db.Users.Add(new User()
            {
                Username = username,
                Password = password
            });
            try
            {
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this.View("Index");
        }
    }
}
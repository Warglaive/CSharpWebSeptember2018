using System;
using System.Linq;
using CakesWebApp.Models;
using CakesWebApp.Services;
using SIS.HTTP.Cookies;
using SIS.HTTP.Requests;
using SIS.HTTP.Responses;
using SIS.WebServer.Results;

namespace CakesWebApp.Controllers
{
    public class AccountController : BaseController
    {
        private const string InvalidUsernameMessage = "<h1>Please provide valid username with length of 4 or more characters!</h1>";
        private const string UsernameAlreadyExists = "<h1>That username is already in use, please pick different one!</h1>";
        private const string PasswordLengthRequirement = "<h1>Please provide password longer than 6 digits!</h1>";
        private const string PassowordsDoesntMatch = "<h1>Passwords do not match!</h1>";
        private const string InvalidUsernameOrPassword = "Invalid Username or password.";


        private IHashService hashService;

        public AccountController()
        {
            this.hashService = new HashService();
        }

        public IHttpResponse Register(IHttpRequest request)
        {
            return this.View("Register");
        }

        public IHttpResponse DoRegister(IHttpRequest request)
        {
            //// return new HtmlResult("REGISTERED", HttpResponseStatusCode.Ok);

            var userName = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var confirmPassword = request.FormData["confirmPassword"].ToString();

            if (string.IsNullOrWhiteSpace(userName) || userName.Length < 4)
            {
                return this.BadRequestError(InvalidUsernameMessage);
            }

            if (this.Db.Users.Any(x => x.Username == userName))
            {
                return BadRequestError(UsernameAlreadyExists);
            }

            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return this.BadRequestError(PasswordLengthRequirement);
            }

            if (password != confirmPassword)
            {
                return this.BadRequestError(PassowordsDoesntMatch);
            }
            ////Hash password
            var hashedPassword = this.hashService.Hash(password);
            var user = new User
            {
                Name = userName,
                Username = userName,
                Password = hashedPassword,
            };
            try
            {
                this.Db.Users.Add(user);
                this.Db.SaveChanges();
            }
            catch (Exception e)
            {
                ////TODO: Log error
                return this.ServerError(e.Message);
            }

            return new RedirectResult("/");
        }


        public IHttpResponse Login(IHttpRequest request)
        {
            return this.View("Login");
        }

        public IHttpResponse DoLogin(IHttpRequest request)
        {
            var username = request.FormData["username"].ToString().Trim();
            var password = request.FormData["password"].ToString();
            var hashedPassword = hashService.Hash(password);

            var user = this.Db.Users.FirstOrDefault(x => x.Username == username
                                                         && x.Password == hashedPassword);

            if (user == null)
            {
                return this.BadRequestError(InvalidUsernameOrPassword);
            }

            var cookie = this.UserCookieService.GetUserCookie(user.Username);

            var response = new RedirectResult("/");
            response.Cookies.Add(new HttpCookie(".auth-cakes", cookie, 7));
            return response;
        }
    }
}
using SIS.HTTP.Responses;
using SIS.MvcFramework;
using TorshiaWebApp.Models;
using TorshiaWebApp.Models.Enums;
using TorshiaWebApp.ViewModels;
using System.Linq;
using SIS.HTTP.Cookies;

namespace TorshiaWebApp.Controllers.Users
{
    public class UsersController : BaseController
    {
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Register(UserViewModel model)
        {
            if (this.TorshiaDbContext.Users.Any(x => x.Username == model.Username))
            {
                return this.BadRequestError($"Username: {model.Username} already exist!");
            }
            if (string.IsNullOrEmpty(model.Username) || string.IsNullOrWhiteSpace(model.Username))
            {
                return this.BadRequestErrorWithView("Username can't be null!");
            }

            if (string.IsNullOrEmpty(model.Password) || string.IsNullOrWhiteSpace(model.Password))
            {
                return this.BadRequestErrorWithView("Password can't be null!");
            }

            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrWhiteSpace(model.Email))
            {
                return this.BadRequestErrorWithView("Email can't be null!");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.BadRequestError("Passwords should match!");
            }

            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Role = Role.User
            };

            if (!this.TorshiaDbContext.Users.Any())
            {
                user.Role = Role.Admin;
            }

            this.TorshiaDbContext.Users.Add(user);
            this.TorshiaDbContext.SaveChanges();
            return this.Redirect("/Users/Login");
        }

        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public IHttpResponse Login(UserViewModel model)
        {
            var user = this.TorshiaDbContext.Users.FirstOrDefault(x =>
                x.Username == model.Username.Trim() &&
                x.Password == model.Password);

            if (user == null)
            {
                return this.BadRequestErrorWithView("Invalid username or password.");
            }

            var mvcUser = new MvcUserInfo
            {
                Username = user.Username,
                Role = user.Role.ToString(),
            };
            var cookieContent = this.UserCookieService.GetUserCookie(mvcUser);

            var cookie = new HttpCookie(".auth-torshia", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-torshia"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-torshia");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }
    }
}
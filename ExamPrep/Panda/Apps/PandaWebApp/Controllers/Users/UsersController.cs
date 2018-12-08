using System.Linq;
using PandaWebApp.Models;
using PandaWebApp.Models.Enums;
using PandaWebApp.ViewModels;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers.Users
{
    public class UsersController : BaseController
    {
        [HttpGet("Users/Register")]
        public IHttpResponse Register()
        {
            return this.View("Users/Register");
        }

        [HttpPost]
        public IHttpResponse Register(UserViewModel model)
        {
            if (this.ApplicationDbContext.Users.Any(x => x.Username == model.Username))
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
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };
            if (!this.ApplicationDbContext.Users.Any())
            {
                user.Role = Role.Admin;
            }
            this.ApplicationDbContext.Users.Add(user);
            this.ApplicationDbContext.SaveChanges();

            return Redirect("/users/login");
        }

        [HttpGet("Users/Login")]
        public IHttpResponse Login()
        {
            return this.View("Users/Login");
        }

        [HttpPost]
        public IHttpResponse Login(UserViewModel model)
        {
            var user = this.ApplicationDbContext.Users.FirstOrDefault(x =>
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

            var cookie = new HttpCookie(".auth-cakes", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-cakes"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-cakes");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }
    }
}
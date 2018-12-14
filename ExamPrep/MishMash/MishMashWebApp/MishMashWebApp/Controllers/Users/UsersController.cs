using System.Linq;
using MishMashWebApp.Models;
using MishMashWebApp.Models.Enums;
using MishMashWebApp.ViewModels;
using SIS.HTTP.Cookies;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace MishMashWebApp.Controllers.Users
{
    public class UsersController : BaseController
    {
        public IHttpResponse Login()
        {
            return this.View();
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

            var cookie = new HttpCookie(".auth-mish", cookieContent, 7) { HttpOnly = true };
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }

        public IHttpResponse Register()
        {
            return this.View();
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

            if (this.ApplicationDbContext.Users.Any(x => x.Email == model.Email))
            {
                return this.BadRequestErrorWithView("Email already exists!");
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

        [Authorize]
        public IHttpResponse Logout()
        {
            if (!this.Request.Cookies.ContainsCookie(".auth-mish"))
            {
                return this.Redirect("/");
            }

            var cookie = this.Request.Cookies.GetCookie(".auth-mish");
            cookie.Delete();
            this.Response.Cookies.Add(cookie);
            return this.Redirect("/");
        }
    }
}

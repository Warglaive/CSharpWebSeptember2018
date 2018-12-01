using PandaWebApp.Models;
using PandaWebApp.ViewModels;
using SIS.HTTP.Responses;
using SIS.MvcFramework;

namespace PandaWebApp.Controllers.Users
{
    public class UsersController : BaseController
    {
        [HttpGet("/users/register")]
        public IHttpResponse Register()
        {
            return this.View();
        }

        [HttpPost("/users/register")]
        public IHttpResponse Register(UserViewModel model)
        {
            if (model.Password != model.ConfirmPassword)
            {
                return BadRequestError("Passwords must match!");
            }
            var user = new User
            {
                Username = model.Username,
                Password = model.Password,
                Email = model.Email
            };
            this.ApplicationDbContext.Users.Add(user);
            this.ApplicationDbContext.SaveChanges();
            return this.Redirect("home/index");
        }

        [HttpGet("/users/login")]
        public IHttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("/users/login")]
        public IHttpResponse Login(UserViewModel model)
        {
            return this.View(model);
        }
    }
}
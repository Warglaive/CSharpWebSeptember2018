using System;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using SIS.Framework.Security;
using Torshia.Models;
using Torshia.Web.Controllers.Base;
using Torshia.Web.Services.Contracts;
using Torshia.Web.ViewModels;

namespace Torshia.Web.Controllers
{
    public class UsersController : BaseController
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }


        public IActionResult Login() => this.View();

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult Register() => this.View();

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            usersService.RegisterUser(model.Username, model.Password, model.Email);

            this.SignIn(new IdentityUser
            {
                Email = model.Email,
                Username = model.Username
            });

            return RedirectToAction("/");
        }
    }
}
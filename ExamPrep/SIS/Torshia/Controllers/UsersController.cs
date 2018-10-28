using System;
using SIS.Framework.ActionResults;
using SIS.Framework.Attributes.Method;
using Torshia.Web.Controllers.Base;
using Torshia.Web.ViewModels;

namespace Torshia.Web.Controllers
{
    public class UsersController : BaseController
    {
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
            throw new NotImplementedException();
        }
    }
}
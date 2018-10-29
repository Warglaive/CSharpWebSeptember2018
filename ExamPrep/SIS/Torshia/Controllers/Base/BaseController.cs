using System.Runtime.CompilerServices;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;

namespace Torshia.Web.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected override IViewable View([CallerMemberName]string actionName = "")
        {
            this.Model.Data["LoggedIn"] = "none";
            this.Model.Data["NotLoggedIn"] = "block";

            return base.View(actionName);
        }
    }
}
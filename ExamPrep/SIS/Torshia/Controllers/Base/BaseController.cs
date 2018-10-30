using System.Runtime.CompilerServices;
using SIS.Framework.ActionResults;
using SIS.Framework.Controllers;

namespace Torshia.Web.Controllers.Base
{
    public abstract class BaseController : Controller
    {
        protected override IViewable View([CallerMemberName]string actionName = "")
        {
            if (this.Identity != null) //if logged in
            {
                this.Model.Data["LoggedIn"] = "block"; //block = show 
                this.Model.Data["Username"] = this.Identity.Username;
                this.Model.Data["NotLoggedIn"] = "none"; //none = dont show
            }
            else
            {
                this.Model.Data["LoggedIn"] = "none";
                this.Model.Data["NotLoggedIn"] = "block";
            }

            return base.View(actionName);
        }
    }
}
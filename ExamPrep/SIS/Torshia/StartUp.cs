using SIS.Framework.Api;
using SIS.Framework.Services;
using Torshia.Web.Controllers;

namespace Torshia.Web
{
    public class StartUp : MvcApplication
    {
        public override void ConfigureServices(IDependencyContainer dependencyContainer)
        {
            dependencyContainer.RegisterDependency<HomeController, HomeController>();
        }
    }
}
using SIS.MvcFramework;
using SIS.MvcFramework.Logger;
using SIS.MvcFramework.Services;

namespace MUSACAWEbApp
{
    public class Startup : IMvcApplication
    {
        public MvcFrameworkSettings Configure()
        {
            return new MvcFrameworkSettings { PortNumber = 8000 };
        }

        public void ConfigureServices(IServiceCollection collection)
        {
            collection.AddService<ILogger, ConsoleLogger>();
        }
    }
}

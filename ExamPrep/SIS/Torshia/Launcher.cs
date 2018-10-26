using SIS.Framework;
using Torshia.Web;

namespace Torshia.Web
{
    public class Launcher
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
using SIS.MvcFramework;

namespace MishMashWebApp
{
    public static class Program
    {
        public static void Main()
        {
            WebHost.Start(new Startup());
        }
    }
}
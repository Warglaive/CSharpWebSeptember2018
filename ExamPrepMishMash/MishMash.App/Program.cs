using SIS.MvcFramework;

namespace MishMash.App
{
    public class Program
    {
        public static void Main()
        {
            WebHost.Start(new StartUp());
        }
    }
}
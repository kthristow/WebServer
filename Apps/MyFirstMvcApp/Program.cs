using MyFirstMvcApp.Controllers;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp
{
    public class Program
    {
        public static object BootstrapJs { get; private set; }

        static async Task Main(string[] args)
        {
            List<Route> routeTable=new List<Route>();
            routeTable.Add(new Route("/",new HomeController().Index));
     
            routeTable.Add(new Route("/users/login", new UsersController().Login));
            routeTable.Add(new Route("/users/register", new UsersController().Register));
            routeTable.Add(new Route("/cards/all", new CardsControllers().All));
            routeTable.Add(new Route("/cards/add", new CardsControllers().Add));
            routeTable.Add(new Route("/cards/colleciton", new CardsControllers().Collection));

            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BootstrapCss));
            routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().BootstrapJs));
            routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));


            await Host.CreateHostAsync(routeTable);
        }

      

      
    }
}
using MyFirstMvcApp.Controllers;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp
{
    public class StartUp : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {

          
            routeTable.Add(new Route("/", new HomeController().Index));

            routeTable.Add(new Route("/users/login", new UsersController().Login));
            routeTable.Add(new Route("/users/register", new UsersController().Register));
            routeTable.Add(new Route("/cards/all", new CardsController().All));
            routeTable.Add(new Route("/cards/add", new CardsController().Add));
            routeTable.Add(new Route("/cards/colleciton", new CardsController().Collection));

            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BootstrapCss));
            routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().BootstrapJs));
            routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));

        }

        public void ConfigureServices()
        {
            
        }
    }
}

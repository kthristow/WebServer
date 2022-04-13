using MyFirstMvcApp.Controllers;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp
{
    public class StartUp : IMvcApplication
    {
        public void ConfigureServices()
        {
        }

        public void Configure(List<Route> routeTable)
        {
            routeTable.Add(new Route("/", WebServer.HTTP.HttpMethod.Get, new HomeController().Index));
            routeTable.Add(new Route("/users/login", WebServer.HTTP.HttpMethod.Get, new UsersController().Login));
            routeTable.Add(new Route("/users/login", WebServer.HTTP.HttpMethod.Post, new UsersController().DoLogin));
            routeTable.Add(new Route("/users/register", WebServer.HTTP.HttpMethod.Get, new UsersController().Register));
            routeTable.Add(new Route("/cards/all", WebServer.HTTP.HttpMethod.Get, new CardsController().All));
            routeTable.Add(new Route("/cards/add", WebServer.HTTP.HttpMethod.Get, new CardsController().Add));
            routeTable.Add(new Route("/cards/collection", WebServer.HTTP.HttpMethod.Get, new CardsController().Collection));

            routeTable.Add(new Route("/favicon.ico", WebServer.HTTP.HttpMethod.Get, new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/bootstrap.min.css", WebServer.HTTP.HttpMethod.Get, new StaticFilesController().BootstrapCss));
            routeTable.Add(new Route("/css/custom.css", WebServer.HTTP.HttpMethod.Get, new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/js/custom.js", WebServer.HTTP.HttpMethod.Get, new StaticFilesController().CustomJs));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", WebServer.HTTP.HttpMethod.Get, new StaticFilesController().BootstrapJs));
        }
    }
}

using WebServer.HTTP;

namespace WebServer.MvcFramework
{
    public interface IMvcApplication
    {
        void ConfigureServices(IServiceCollection serviceCollection);

        void Configure(List<Route> routeTable);
    }
}

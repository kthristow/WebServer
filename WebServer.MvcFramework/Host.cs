using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServer.HTTP;

namespace WebServer.MvcFramework
{
    public static class Host
    {
       public static async Task CreateHostAsync(IMvcApplication mvcApplication,int port=80)
        {
            List<Route> routes = new List<Route>();
            mvcApplication.ConfigureServices();
            mvcApplication.Configure(routes);
            IHttpServer server = new HttpServer(routes);
       
            await server.StartAsync(port);
        }
    }
}

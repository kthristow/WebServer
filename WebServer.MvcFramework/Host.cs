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

            AutoRegisteredFile(routes);
            AutoRegisteredRoutes(routes, mvcApplication);
            mvcApplication.ConfigureServices();
            mvcApplication.Configure(routes);
            IHttpServer server = new HttpServer(routes);
       
            await server.StartAsync(port);
        }

        private static void AutoRegisteredRoutes(List<Route> routes, IMvcApplication mvcApplication)
        {
           var controllerTypes= mvcApplication.GetType().Assembly.GetTypes()
                .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Controller)));

            foreach (var controllerType in controllerTypes)
            {
                var methods = controllerType.GetMethods()
                    .Where(x=>x.IsPublic && !x.IsStatic 
                    && x.DeclaringType==controllerType&& !x.IsAbstract 
                    && !x.IsConstructor && !x.IsSpecialName);

                foreach (var method in methods)
                {
                    var url = "/" + controllerType.Name.Replace("Controller", string.Empty)
                        + "/" + method.Name;
                   var attribute= method.GetCustomAttributes(false)
                        .Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute)))
                        .FirstOrDefault() as BaseHttpAttribute;
                    var httpMethod = HTTP.HttpMethod.Get;
                    if(attribute != null)
                    {
                        httpMethod=attribute.Method;
                    }

                    if (!string.IsNullOrEmpty(attribute?.Url))
                    {
                        url = attribute.Url;
                    }
                    
                    routes.Add(new Route(url,httpMethod, (request) =>
                    {
                        var instance = Activator.CreateInstance(controllerType) as Controller;
                        var response=method.Invoke(instance)as
                        HttpResponse;
                        instance.Request = request;
                        return response;

                    }));
                }
            }
        }

        private static void AutoRegisteredFile(List<Route> routes)
        {
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);
            foreach (var staticFile in staticFiles)
            {
                var url = staticFile.Replace("wwwroot", string.Empty)
                    .Replace("\\", "/");

                routes.Add(new Route(url, HTTP.HttpMethod.Get, (request) =>
                {
                    var fileContent = File.ReadAllBytes(staticFile);
                    var fileExt = new FileInfo(staticFile).Extension;
                    var contentType = fileExt switch
                    {
                        ".txt" => "text/plain",
                        ".js" => "text/javascript",
                        ".css" => "text/css",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        ".ico" => "image/vnd.microsoft.icon",
                        ".html" => "text/html",
                        _ => "text/plain",
                    };

                    return new HttpResponse(contentType, fileContent, HttpStatusCode.Ok);

                }));
            }
        }
    }
}

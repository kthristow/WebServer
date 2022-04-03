using System;
using System.Text;
using WebServer.HTTP;

namespace MyFirstMvcApp 
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IHttpServer server = new HttpServer();
            server.AddRoute("/", HomePage);
            server.AddRoute("/favicon.ico", Favicon);
            server.AddRoute("/about", About);
            server.AddRoute("/users/login", Login);
            await server.StartAsync(80);
        }

        private static HttpResponse Favicon(HttpRequest arg)
        {
            var fileBtyes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBtyes);
            return response;
        }

        private static HttpResponse Login(HttpRequest arg)
        {
            var responseHtml = "<h1>Login...</h1>";
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });

            return response;
        }

        private static HttpResponse About(HttpRequest arg)
        {
            var responseHtml = "<h1>About....</h1>";
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });

            return response;
        }

        private static HttpResponse HomePage(HttpRequest arg)
        {
            var responseHtml = "<h1>Welcome!</h1>";
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });

            return response;
        }
    }
}
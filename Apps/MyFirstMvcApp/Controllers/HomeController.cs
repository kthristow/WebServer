using System.Text;
using WebServer.HTTP;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController
    {

        public HttpResponse About(HttpRequest arg)
        {
            var responseHtml = "<h1>About....</h1>";
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            response.Cookies.Add(new ResponseCookie("sid", Guid.NewGuid().ToString())
            { HttpOnly = true, MaxAge = 60 * 24 * 60 * 60 });

            return response;
        }

        public HttpResponse Index(HttpRequest arg)
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

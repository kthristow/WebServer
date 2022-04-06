using System.Text;
using WebServer.HTTP;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController
    {
        public HttpResponse Login(HttpRequest arg)
        {
            var responseHtml = "<h1>Login...</h1>";
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            return response;
        }
        public HttpResponse Register(HttpRequest arg)
        {
            var responseHtml = "<h1>Register...</h1>";
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            return response;
        }
    }
}

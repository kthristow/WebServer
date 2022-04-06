using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController:Controller
    {
        public HttpResponse Login(HttpRequest arg)
        {
            return this.View();
        }
        public HttpResponse Register(HttpRequest arg)
        {
            return this.View();
        }
    }
}

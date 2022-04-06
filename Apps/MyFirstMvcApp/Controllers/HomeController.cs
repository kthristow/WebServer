using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class HomeController:Controller
    { 
        public HttpResponse Index(HttpRequest arg)
        {
            return this.View();
        }
    }
}

using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class CardsControllers:Controller
    {
        public HttpResponse Add(HttpRequest request)
        {
            return this.View();
        }
        public HttpResponse All(HttpRequest request)
        {
            return this.View();
        }
        public HttpResponse Collection(HttpRequest request)
        {
            return this.View();
        }

    }
}

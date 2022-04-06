using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class StaticFilesController:Controller
    {
       public HttpResponse Favicon(HttpRequest arg)
        {
            var fileBtyes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBtyes);
            return response;
        }
    }
}

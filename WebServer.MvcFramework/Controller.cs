using System.Runtime.CompilerServices;
using System.Text;
using WebServer.HTTP;

namespace WebServer.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName]string viewPath=null)
        {
            var layout = System.IO.File
                .ReadAllText("Views/Shared/_Layout.html");

            var viewContent =
                System.IO.File
                .ReadAllText("Views/"+this.GetType().Name.Replace("Controller",string.Empty)+"/"+viewPath+".html");
            var responseHtml = layout.Replace("@RenderBody()", viewContent);
            var responseBody = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBody);
            return response;
        }

        public HttpResponse File(string filePath,string contentType)
        {

            var fileBtyes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBtyes);
            return response;
        }

        public HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location", url));
            return response;
        }
    }
}

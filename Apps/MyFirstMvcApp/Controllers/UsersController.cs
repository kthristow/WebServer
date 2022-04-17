using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace MyFirstMvcApp.Controllers
{
    public class UsersController:Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse DoLogin()
        {
            //read data
            //check user
            //log user
            //redirect

            return this.Redirect("/");
        }
    }
}

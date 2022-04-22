using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        // GET /users/login
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            return this.Redirect("/");
        }

        // GET /users/register
        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            return this.Redirect("/");
        }

      

        public HttpResponse Logout()
        {
            if (this.isUserSignedIn())
            {
                this.SignOut();
                return this.Redirect("/");
            }
            else
            {
                return this.Error("Only logged-in users can logged-out!");
            }
            
            
        }
    }
}

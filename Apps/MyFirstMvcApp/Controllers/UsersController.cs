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

        // GET /users/register
        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse DoLogin()
        {
            // TODO: read data
            // TODO: check user
            // TODO: log user
            return this.Redirect("/");
        }
    }
}

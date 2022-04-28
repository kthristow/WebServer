
using BattleCards.ViewModels;
using System.Text;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.isUserSignedIn())
            {
                return Redirect("/Cards/All");
            }
            
            return this.View();
        }

        // GET /home/about
    }
}

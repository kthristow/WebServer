
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
            
            return this.View();
        }

        // GET /home/about
    }
}

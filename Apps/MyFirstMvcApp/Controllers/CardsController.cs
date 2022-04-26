using BattleCards.Data;
using BattleCards.ViewModels;

using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CardsController(ApplicationDbContext db)
        {
               this.db = db;
        }
        // GET /cards/add
        public HttpResponse Add()
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }

        [HttpPost("/Cards/Add")]
        public HttpResponse DoAdd()
        {
          
            if (this.Request.FormData["name"].Length < 5)
            {
                return this.Error("Name should be at least 5 chars");
            }


            db.Add(new Card
            {
                Attack = int.Parse(this.Request.FormData["attack"]),
                Health = int.Parse(this.Request.FormData["health"]),
                Description=this.Request.FormData["description"],
                Name = this.Request.FormData["name"],
                ImageUrl=this.Request.FormData["image"],
                Keyword=this.Request.FormData["keyword"]
            });
            db.SaveChanges();

            return this.Redirect("/Cards/All");
        }
        // /cards/all
        public HttpResponse All()
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var cardsViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword
            }).ToList();
            return this.View(cardsViewModel);
        }
       

        // /cards/collection
        public HttpResponse Collection()
        {

            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            return this.View();
        }
    }
}

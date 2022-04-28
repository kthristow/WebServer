using BattleCards.Data;
using BattleCards.Services;
using BattleCards.ViewModels.Cards;
using WebServer.HTTP;
using WebServer.MvcFramework;

namespace BattleCards.Controllers
{
    public class CardsController : Controller
    {
       
        private readonly ICardsService cardsService;

        public CardsController( ICardsService cardsService)
        {
              
            this.cardsService = cardsService;
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

        [HttpPost]
        public HttpResponse Add(AddCardInputModel model)
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrEmpty(model.Name)||model.Name.Length < 5||
                model.Name.Length>15)
            {
                return this.Error("Name should be at between 5 and 15 chars");
            }

            if (string.IsNullOrWhiteSpace(model.Image))
            {
                return this.Error("The image is required!");
            }
            if(!Uri.TryCreate(model.Image, UriKind.Absolute, out _))
            {
                return this.Error("Image url should be valid!");
            }
            if (string.IsNullOrWhiteSpace(model.Keyword))
            {
                return this.Error("Keyword is requeid!");
            }
            if (model.Attack < 0)
            {
                return this.Error("Attack should be non-negative integer.");
            }

            if (model.Health < 0)
            {
                return this.Error("Health should be non-negative integer.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) || model.Description.Length > 200)
            {
                return this.Error("Description is required and its length at most 200 characters.");
            }


           var cardId= this.cardsService.AddCard(model);
            var userId=this.GetUserId();
            this.cardsService.AddCardToUserCollection(userId, cardId);

            return this.Redirect("/Cards/All");
        }
        // /cards/all
        public HttpResponse All()
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            
            var cardsViewModel=this.cardsService.GetAll();
            return this.View(cardsViewModel);
        }
       

        // /cards/collection
        public HttpResponse Collection()
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();

            var cards=this.cardsService.GetByUserId(userId);
            return this.View(cards);
        }
        public HttpResponse AddToCollection(int cardId)
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId=this.GetUserId();
            this.cardsService.AddCardToUserCollection(userId, cardId);
            return this.Redirect("/Cards/All");
        }
        public HttpResponse RemoveFromCollection(int cardId)
        {
            if (!this.isUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }
            var userId = this.GetUserId();
            this.cardsService.RemoveCardFromUserCollection(userId, cardId);
            return this.Redirect("/Cards/Collection");
        }


    }
}

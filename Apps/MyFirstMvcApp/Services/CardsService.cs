using BattleCards.Data;
using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public class CardsService : ICardsService
    {
        private readonly ApplicationDbContext db;
        public CardsService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public int AddCard(AddCardInputModel model)
        {
            var card = new Card
            {
                Attack = model.Attack,
                Health = model.Health,
                Description = model.Description,
                Name = model.Name,
                ImageUrl = model.Image,
                Keyword = model.Keyword
            };
            this.db.Cards.Add(card);
            this.db.SaveChanges();
            return card.Id;
        }

        public void AddCardToUserCollection(string userId, int cardId)
        {
            if (this.db.UserCards.Any(x => x.UserId == userId && x.CardId == cardId))
            {
                return;
            }

            this.db.UserCards.Add(new UserCard
            {
                UserId = userId,
                CardId = cardId
            });
            this.db.SaveChanges();
        }

        public IEnumerable<CardViewModel> GetAll()
        {
            var cardsViewModel = db.Cards.Select(x => new CardViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Attack = x.Attack,
                Health = x.Health,
                ImageUrl = x.ImageUrl,
                Type = x.Keyword,
                Id= x.Id
            }).ToList();
            return cardsViewModel;
        }

        public IEnumerable<CardViewModel> GetByUserId(string userId)
        {
           
            var cards = this.db.UserCards
                .Where(x => x.UserId == userId)
                .Select(x => new CardViewModel
                {
                    Attack = x.Card.Attack,
                    Description = x.Card.Description,
                    Health = x.Card.Health,
                    Name = x.Card.Name,
                    ImageUrl = x.Card.ImageUrl,
                    Type = x.Card.Keyword,
                    Id = x.CardId

                })
                .ToList();
            return cards;
        }

        public void RemoveCardFromUserCollection(string userId, int cardId)
        {
            var userCard = this.db.UserCards.FirstOrDefault(x => x.UserId == userId && x.CardId == cardId);
            if (userCard == null)
            {
                return;
            }
            this.db.UserCards.Remove(userCard);
            this.db.SaveChanges();
        }
    }
}

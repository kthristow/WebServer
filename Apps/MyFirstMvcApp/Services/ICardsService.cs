﻿using BattleCards.ViewModels.Cards;

namespace BattleCards.Services
{
    public interface ICardsService
    {
        int AddCard(AddCardInputModel model);
        IEnumerable<CardViewModel> GetAll();
        IEnumerable<CardViewModel> GetByUserId(string userId);
        void AddCardToUserCollection(string userId, int cardId);

        void RemoveCardFromUserCollection(string userId, int cardId);   
    }
}

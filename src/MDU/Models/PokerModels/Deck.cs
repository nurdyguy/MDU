using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Diagnostics;

namespace MDU.Models.PokerModels
{
    public class Deck
    {
        public Random randGen { get; set; }
        public int id { get; set; }
        public SortedList<int, Card> Cards { get; set; }

        public Deck()
        {
            ResetDeck();
            randGen = new Random();
        }

        //public Deck(int firstCard)
        //{
        //    ResetDeck();
        //    DealNextCards(firstCard + 1);
        //}

        public void ResetDeck()
        {
            Cards = new SortedList<int, Card>(Card.AllCards);
        }

        //public List<Card> DealRandomCards(int numCards)
        //{
        //    var randomCards = new List<Card>();
        //    for(var i = 0; i < numCards; i++)
        //    {
        //        int randomNumber = randGen.Next(0, Cards.Count); 
        //        randomCards.Add(Cards[randomNumber]);
        //        Cards.RemoveAt(randomNumber);
        //    }
        //    Debug.WriteLine("--------------------");
        //    return randomCards;
        //}

        //public List<Card> DealNextCards(int numCards)
        //{
        //    List<Card> nextCards = new List<Card>();
        //    for (var i = 0; i < numCards; i++)
        //    {
        //        nextCards.Add(GetCardByIndex(0));
        //        Cards.RemoveAt(0);
        //    }
        //    return new List<Card>(nextCards);
        //}

        //public List<Card> DealCards(List<Card> cards)
        //{
        //    //var cardIds = cards.Select(c => c.Id).ToList();
        //    cards.ForEach(c => Cards.Remove(c.Id));
        //    return new List<Card>(cards);
        //}

        //public List<Card> DealCardsByCardId(List<int> cardIds)
        //{
        //    //var cards = Cards.Where(c => cardIds.Contains(c.Id)).ToList();
        //    //Cards = Cards.Where(c => !cardIds.Contains(c.Id)).ToList();
        //    var cards = new List<Card>();
        //    cardIds.ForEach(c =>
        //    {
        //        cards.Add(Cards[c]);
        //        Cards.Remove(c);
        //    });
        //    return cards;
        //}

        //public Card GetCardByIndex(int index)
        //{
        //    //var keys = Cards.Keys[index];
        //    return Cards[Cards.Keys[index]];
        //}

        //public Card GetCardByCardId(int cardId)
        //{
        //    return Cards[cardId];
        //}
        
        //public void AddCardBackToDeckInOrder(Card card)
        //{
        //    Cards.Add(card.Id, card);
        //}

        //public void AddCardBackToDeckInOrder(int cardId)
        //{
        //    Cards.Add(cardId, Card.AllCards[cardId]);
        //}

        //public void AddCardsBackToDeckInOrder(List<Card> cards)
        //{
        //    cards.ForEach(c => AddCardBackToDeckInOrder(c));
        //}

        //public void AddCardsBackToDeckInOrder(List<int> cardIds)
        //{
        //    cardIds.ForEach(c => AddCardBackToDeckInOrder(c));
        //}

        //public void RemoveCards(List<Card> alreadyUsed)
        //{
        //    alreadyUsed.ForEach(c => Cards.Remove(c.Id));            
        //}

        
         
    }
}
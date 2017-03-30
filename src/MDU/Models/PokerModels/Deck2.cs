using System;
using System.Collections.Generic;
using System.Linq;


namespace MDU.Models.PokerModels
{
    public class Deck2
    {
        public List<DeckCard> Cards { get; set; }
        public int ActiveCards { get; set; }

        public Deck2()
        {
            ResetDeck();
        }

        public Deck2(int firstCard)
        {
            ResetDeck();
            //DealNextCards(firstCard + 1);
        }

        public void ResetDeck()
        {
            Cards = new List<DeckCard>(52);
            ActiveCards = 52;
            for(var i = 0; i < 52; i++)
            {
                Cards.Add(new DeckCard(Card.GetCardById(i), false));
            }
            //CardsInUse = new List<bool>() 
            //{ 
            //    false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false,
            //    false, false, false, false, false, false, false, false, false, false, false, false, false
            //};
        }

        public List<Card> DealCards(List<Card> cards)
        {
            cards.ForEach(c => Cards[c.Id].IsInUse = true);
            ActiveCards -= cards.Count;
            return new List<Card>(cards);
        }

        public List<Card> DealNextCards(int numCards)
        {
            List<Card> nextCards = new List<Card>();
            ActiveCards-= numCards;
            int startPos = 0;
            bool found;
            for (var i = 0; i < numCards; i++)
            {
                found = false;
                for (var j = startPos; !found && j < 52; j++)
                {
                    if (!Cards[j].IsInUse)
                    {
                        nextCards.Add(Cards[j].Card);
                        Cards[j].IsInUse = true;
                        startPos = j;
                        found = true; 
                    }
                }                
            }
            return new List<Card>(nextCards);
        }

        public Card GetCardByIndex(int index)
        {
            return Cards[index].Card;
        }

        public void RemoveCards(List<Card> alreadyUsed)
        {
            alreadyUsed.ForEach(c => Cards[c.Id].IsInUse = true);
            ActiveCards -= alreadyUsed.Count;
        }

        public void AddCardsBackToDeckInOrder(List<Card> cards)
        {
            cards.ForEach(c => Cards[c.Id].IsInUse = false);
            ActiveCards += cards.Count;
        }
    }

    public class DeckCard
    {
        public bool IsInUse { get; set; }
        public Card Card { get; set; }
        public DeckCard() { }
        public DeckCard(Card c, bool inUse = false)
        {
            Card = c;
            IsInUse = inUse;
        }
    }
}
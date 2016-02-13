using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDU.Models.Poker
{
    public class Hand
    {
        public List<Card> Cards { get; set; }

        public Hand()
        {
            Cards = new List<Card>();
        }

        public Hand(Hand h)
        {
            Cards = new List<Card>(h.Cards);
        }

        public Hand(int handId)
        {
            Cards = new List<Card>();
            Cards.Add(Card.GetCardById(handId % 100));
            Cards.Add(Card.GetCardById(handId / 100));
        }

        public Hand(List<Card> cards)
        {
            Cards = new List<Card>(cards);
        }
    }

    public class StartingHand
    {
        public Hand Hand1 { get; set; }
        public Hand Hand2 { get; set; }
        public int handKey
        {
            get
            {
                int h1, h2;
                h1 = Hand1.Cards[1].Id + 100 * Hand1.Cards[0].Id;
                h2 = Hand2.Cards[1].Id + 100 * Hand2.Cards[0].Id;
                if (Hand1.Cards[0].Id < Hand2.Cards[0].Id)
                {
                    return h2 + 10000 * h1;
                }
                else
                {
                    return h1 + 10000 * h2;
                }
            }
        }
        public StartingHand() { }
        public StartingHand(Hand h1, Hand h2)
        {
            if (h1.Cards[0].Id < Hand2.Cards[0].Id)
            {
                Hand1 = new Hand(h1);
                Hand2 = new Hand(h2);
            }
            else
            {
                Hand1 = new Hand(h2);
                Hand2 = new Hand(h1);
            }
        }
    }
}
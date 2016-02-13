using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Web;
using System.Data;
using System.Diagnostics;
using MDU.Context;

namespace MDU.Models.Poker
{
    public class HeadToHeadStat //: DbContext
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Id { get; set; }

        public int Hand0Id { get; set; }
        public int Hand1Id { get; set; }
        public long Hand0Wins { get; set; }
        public long Hand1Wins { get; set; }
        public long Chops { get; set; }


        public HeadToHeadStat()
        {

        }

        public HeadToHeadStat(Hand h0, Hand h1, long w0, long w1, long chops)
        {
            if (h0.Cards.Count != 2 || h1.Cards.Count != 2)
                return;

            if (h0.Cards[0].Id < h1.Cards[0].Id)
            {
                Hand0Id = h0.Cards[1].Id + 100 * h0.Cards[0].Id;
                Hand1Id = h1.Cards[1].Id + 100 * h1.Cards[0].Id;
            }
            else
            {
                Hand0Id = h1.Cards[1].Id + 100 * h1.Cards[0].Id;
                Hand1Id = h0.Cards[1].Id + 100 * h0.Cards[0].Id;
            }
            Id = Hand1Id + 10000 * Hand0Id;

            Hand0Wins = w0;
            Hand1Wins = w1;
            Chops = chops;
        }

        private List<List<Card>> GetPossibleHands()
        {
            var deck = new Deck();
            List<List<Card>> hands = new List<List<Card>>();
            List<Card> currHand = new List<Card>();
            List<Card> nextHand = new List<Card>(deck.DealNextCards(2));
            var iCalc = new IterationCalculator();

            while (nextHand != null)
            {
                deck.AddCardsBackToDeckInOrder(currHand);
                currHand = deck.DealCards(nextHand);
                hands.Add(currHand);
                nextHand = iCalc.GetNextHand(nextHand, deck.Cards);
            }
            return hands;
        }

        public List<StartingHand> SetupStartingHands()
        {
            var iCalc = new IterationCalculator();
            var h1 = GetPossibleHands();
            //remove last 3 because there is no hand after them
            h1.RemoveAt(h1.Count - 1);
            h1.RemoveAt(h1.Count - 1);
            h1.RemoveAt(h1.Count - 1);
            Parallel.ForEach(h1, h =>
            {
                MDUContext _db = new MDUContext();
                Deck d = new Deck(h[0].Id);
                d.RemoveCards(h);

                List<List<Card>> hands = new List<List<Card>>();
                List<Card> currHand = new List<Card>();
                List<Card> nextHand = new List<Card>(d.DealNextCards(2));
                try
                {
                    while (nextHand != null)
                    {

                        d.AddCardsBackToDeckInOrder(currHand);
                        currHand = d.DealCards(nextHand);
                        hands.Add(currHand);
                        _db.HeadToHeadStats.Add(new HeadToHeadStat(new Hand(h), new Hand(currHand), 0, 0, 0));
                        nextHand = iCalc.GetNextHand(nextHand, d.Cards);
                    }
                    _db.SaveChanges();
                }
                catch
                {

                }

            });

            return null;
        }
    }
}
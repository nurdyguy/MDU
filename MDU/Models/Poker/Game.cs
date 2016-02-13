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
    public class Game
    {
        private MDUContext db = new MDUContext();

        public int Id { get; set; }
        
        public List<Player> Players { get; set; }

        public Deck Deck { get; set; }

        public HandCalculator hCalc { get; set; }

        public IterationCalculator iCalc { get; set; }

        public List<Card> Board { get; set; }

        public long WinningScore { get; set; }

        public RoundResult RoundResult { get; set; }

        public List<long> PlayerWins { get; set; }

        public long Chops { get; set; }

        public List<double> Timers = new List<double>();

        public Game(int numPlayers = 2) 
        {
            Deck = new Deck();
            Players = new List<Player>();
            PlayerWins = new List<long>();
            hCalc = new HandCalculator();
            iCalc = new IterationCalculator();
            Board = new List<Card>();
            for (var i = 0; i < numPlayers; i++)
            {
                Players.Add(new Player());
                PlayerWins.Add(0);
            }
        }

        // plays a basic game
        public Game PlayRounds(int num = 1)
        {
            var watch = new Stopwatch();
            string updateQuery = "UPDATE dbo.HeadToHeadStats SET Hand0Wins = @p0, Hand1Wins = @p1, Chops = @p2 WHERE Id = @p3";

            watch.Start();

            //var startingHands = PokerRepository.GetNextCalcBatch(50);

            var startingHands = db.HeadToHeadStats
                                    .Where(h => h.Chops == 0)
                                    .Take(50)
                                    .ToList();

            startingHands.ForEach(sh =>
            {
                sh.Chops = 1;
                db.Entry(sh).State = EntityState.Modified;
            });
            db.SaveChanges();

            Timers.Add(watch.Elapsed.TotalSeconds);
            watch.Restart();
            
            //startingHands = startingHands.Where(sh => sh.Chops == 0).Take(50).ToList();
            //startingHands = startingHands.Where(sh => sh.Hand0Id == 4551).ToList();        && sh.Hand0Id >= 4651
            //startingHands = startingHands.Where(sh => sh.Id == 45514650).ToList();

            //var startingHands = new List<HeadToHeadStat>()
            //{
            //    new HeadToHeadStat()
            //    {
            //        Id = 71225,
            //        Hand0Id = 7,
            //        Hand1Id = 1225
            //    }
            //};

            Parallel.ForEach(startingHands, new ParallelOptions() { MaxDegreeOfParallelism = 6 }, sh =>
            //startingHands.ForEach(sh =>
            {
                MDUContext _db = new MDUContext();
                Hand h0 = new Hand(sh.Hand0Id);
                Hand h1 = new Hand(sh.Hand1Id);
                List<Hand> hands = null;
                bool reverse = false;
                if (h0.Cards[0].Number + h0.Cards[1].Number < h1.Cards[0].Number + h1.Cards[1].Number)
                {
                    reverse = true;
                    hands = new List<Hand>() { h1, h0 };
                }
                else
                {
                    reverse = false;
                    hands = new List<Hand>() { h0, h1 };
                }
                Deck d = new Deck();
                //HandCalculator hc = new HandCalculator();
                long h0w = 0;
                long h1w = 0;
                long chops = 0;

                d.RemoveCards(h0.Cards);
                d.RemoveCards(h1.Cards);
                List<Card> currBoard = new List<Card>();
                List<Card> nextBoard = new List<Card>(d.DealNextCards(5));
                while (nextBoard != null)
                {
                    HandCalculator hc = new HandCalculator();
                     d.AddCardsBackToDeckInOrder(currBoard);
                    currBoard = d.DealCards(nextBoard);

                    var result = hc.CalculateWinner(hands , currBoard);
                    if (result.WinningPlayerNumbers.Count > 1)
                        chops++;
                    else if (result.WinningPlayerNumbers[0] == 0)
                        h0w++;
                    else if (result.WinningPlayerNumbers[0] == 1)
                        h1w++;
                    nextBoard = iCalc.GetNextHand(nextBoard, d.Cards);
                }
                if (reverse)
                    _db.Database.ExecuteSqlCommand(updateQuery, h1w, h0w, chops, sh.Id);
                else
                    _db.Database.ExecuteSqlCommand(updateQuery, h0w, h1w, chops, sh.Id);
                Debug.WriteLine("h0: " + h0w);
                Debug.WriteLine("h1: " + h1w);
                Debug.WriteLine("chops: " + chops);
            });

            Timers.Add(watch.Elapsed.TotalSeconds);
            
            watch.Stop();
            return this;
        }

        private RoundResult CalculateWinner()
        {
            var winners = new List<Player>();
            var winnerNumbers = new List<int>();
            //var commCards = Board;

            long highScore = 0;
            long handScore = 0;

            Hand hand;

            for(int i = 0; i < Players.Count; i++)
            //foreach(var player in Players)
            {
                hand = new Hand(Players[i].Hand);
                hand.Cards.AddRange(Board);

                handScore = hCalc.CalculateHandScore(hand, highScore);
                if (handScore == highScore)
                {
                    winners.Add(Players[i]);
                    winnerNumbers.Add(i);
                }
                else if (handScore > highScore)
                {
                    highScore = handScore;
                    winners = new List<Player>() { Players[i] };
                    winnerNumbers = new List<int>() { i };
                }
            }

            //return { 'players': arrWinners, 'score': highScore }
            return new RoundResult() { WinningScore = highScore, WinningPlayerNumbers = winnerNumbers };
        }

        private void PrintCards(List<Card> cards, bool addNewLine = true)
        {
            string str = "";
            cards.ForEach(c => 
            {
                str+= c.ShortName + " ";
            });
            if(addNewLine)
                Debug.WriteLine(str);
            else
                Debug.Write(str);
        }

        private List<List<Card>> GetPossibleHands()
        {
            var deck = new Deck();
            List<List<Card>> hands = new List<List<Card>>();
            List<Card> currHand = new List<Card>();
            List<Card> nextHand = new List<Card>(deck.DealNextCards(2));

            while (nextHand != null)
            {
                deck.AddCardsBackToDeckInOrder(currHand);
                currHand = deck.DealCards(nextHand);
                hands.Add(currHand);
                nextHand = iCalc.GetNextHand(nextHand, deck.Cards);
            }
            return hands;
        }

        private List<StartingHand> GetPossibleStartingHands()
        {
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

                while (nextHand != null)
                {
                    
                    d.AddCardsBackToDeckInOrder(currHand);
                    currHand = d.DealCards(nextHand);
                    hands.Add(currHand);
                    _db.HeadToHeadStats.Add(new HeadToHeadStat(new Hand(h), new Hand(currHand), 0, 0, 0));                    
                    nextHand = iCalc.GetNextHand(nextHand, d.Cards);
                }
                _db.SaveChanges();
                
            });

            
   
            return null;
        }



    }
    public class RoundResult
    {
        //public Player WinningPlayer { get; set; }
        public List<int> WinningPlayerNumbers { get; set; }
        public long WinningScore { get; set; }
    }

    
}
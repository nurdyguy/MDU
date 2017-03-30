using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using MDU.Models.PokerModels;
using MDU.Services.Contracts;
using MDU.Repositories.Contracts;


namespace MDU.Services.Implementtions
{
    public class PokerService : IPokerService
    {

        private readonly ICalculatorService _calculator;
        private readonly IPokerRepository _pokerRepo;

        public PokerService(ICalculatorService calculator, IPokerRepository pokerRepo)
        {
            _calculator = calculator;
            _pokerRepo = pokerRepo;
        }

        #region HandStatProcessing
        //------- objects used in original---convert
        //public HandStatRequest Request { get; set; }
        //public HandStatResponse Response { get; set; }
        //public int NumPlayers { get; set; }
        //public List<Hand> StartHands { get; set; }
        //public List<int> NewOrder { get; set; }
        //public List<Hand> OrderedStartHands { get; set; }
        //public List<Card> DeadCards { get; set; }
        //public List<Card> BoardCards { get; set; }
        //public HandCalculator hCalc { get; set; }

        //------  move this to methods
        //public HandStatProcessor(HandStatRequest request)
        //{
        //    hCalc = new HandCalculator();
        //    StartHands = new List<Hand>();
        //    OrderedStartHands = new List<Hand>();
        //    BoardCards = new List<Card>();
        //    DeadCards = new List<Card>();
        //    SetUpStartHands(request);
        //    if (request.BoardCardIds != null && request.BoardCardIds.Count > 0)
        //        SetUpBoardCards(request);
        //    if (request.DeadCardIds != null && request.DeadCardIds.Count > 0)
        //        SetUpDeadCards(request);
        //}


        public List<HandStatResult> GetHandStats(int NumPlayers, List<Hand> hands, List<Card> boardCards, List<Card> deadCards)
        {
            var orderedStartHands = hands.OrderBy(h => h.HandId).ToList();
            switch (orderedStartHands.Count)
            {
                case 0:
                case 1:
                    throw new Exception("Invalid request.");
                    break;
                case 2:
                    //goto default;
                    if (boardCards.Count + deadCards.Count == 0)
                    {
                        int requestId = 0;
                        for (int i = 0; i < orderedStartHands.Count; i++)
                            requestId += (int)Math.Pow(10000, (orderedStartHands.Count - i - 1)) * orderedStartHands[i].HandId;
                        var resultStat = _pokerRepo.Get2PlayerStatById(requestId);
                        return BuildHandStatResults(resultStat, hands);
                    }
                    // else use default
                    goto default;
                    break;
                case 3:
                    if (boardCards.Count + deadCards.Count == 0)
                    {
                    }
                    // else use default
                    goto default;
                    break;
                case 4:
                    if (boardCards.Count + deadCards.Count == 0)
                    {
                    }
                    // else use default
                    goto default;
                    break;
                case 5:
                    if (boardCards.Count + deadCards.Count == 0)
                    {
                    }
                    // else use default
                    goto default;
                    break;
                default:
                    var result = _calculator.CalculateRound(hands, boardCards, deadCards);
                    return result;
                    break;
            }
            return null;
        }

        private List<HandStatResult> BuildHandStatResults()
        {

            return null;
        }

        private List<HandStatResult> BuildHandStatResults(HeadToHeadStat stat, List<Hand> origHands)
        {
            var result = new List<HandStatResult>(2);
            if (origHands[0].HandId < origHands[1].HandId)
            { 
                result.Add(new HandStatResult()
                {
                    HandId = stat.Hand0Id,
                    Wins = stat.Hand0Wins,
                    Loses = stat.Hand1Wins,
                    Chops = stat.Chops
                });
                result.Add(new HandStatResult()
                {
                    HandId = stat.Hand1Id,
                    Wins = stat.Hand1Wins,
                    Loses = stat.Hand0Wins,
                    Chops = stat.Chops
                });
            }
            else
            {
                result.Add(new HandStatResult()
                {
                    HandId = stat.Hand1Id,
                    Wins = stat.Hand1Wins,
                    Loses = stat.Hand0Wins,
                    Chops = stat.Chops
                });
                result.Add(new HandStatResult()
                {
                    HandId = stat.Hand0Id,
                    Wins = stat.Hand0Wins,
                    Loses = stat.Hand1Wins,
                    Chops = stat.Chops
                });
            }
            return result;
        }


        private List<HandStatResult> OrderHandStatResponse(List<HandStatResult> handStats, List<Hand> origHands)
        {
            var handStatResponse = new List<HandStatResult>(handStats.Count);
            origHands.ForEach(h =>
            {
                handStatResponse.Add(handStats.Where(hs => hs.HandId == h.HandId).Single());
            });
            return handStatResponse;
        }

        private List<HandStatResult> BuildHandStatResults(List<long> result)
        {

            return null;
        }

        


        #endregion

        #region Game

        //----------- old objects
        //public int Id { get; set; }
        //public List<Player> Players { get; set; }
        //public Deck Deck { get; set; }
        //public HandCalculator hCalc { get; set; }
        //public IterationCalculator iCalc { get; set; }
        //public List<Card> Board { get; set; }
        //public long WinningScore { get; set; }
        //public RoundResult RoundResult { get; set; }
        //public List<long> PlayerWins { get; set; }
        //public long Chops { get; set; }


        //------------ old constructor
        //public Game(int numPlayers = 2)
        //{
        //    Deck = new Deck();
        //    Players = new List<Player>();
        //    PlayerWins = new List<long>();
        //    hCalc = new HandCalculator();
        //    iCalc = new IterationCalculator();
        //    Board = new List<Card>();
        //    for (var i = 0; i < numPlayers; i++)
        //    {
        //        Players.Add(new Player());
        //        PlayerWins.Add(0);
        //    }
        //}

        // plays a basic game
        public void PlayRounds(int num = 1)
        {
            //var timers = new List<double>();
            //var watch = new Stopwatch();


            //watch.Start();

            //var startingHands = _pokerRepo.GetNextCalcBatch(50);

            //timers.Add(watch.Elapsed.TotalSeconds);
            //watch.Restart();

            ////var startingHands = new List<HeadToHeadStat>()
            ////{
            ////    new HeadToHeadStat()
            ////    {
            ////        Id = 13463039,
            ////        Hand0Id = 1346,
            ////        Hand1Id = 3039
            ////    },
            ////    new HeadToHeadStat()
            ////    {
            ////        Id = 13463040,
            ////        Hand0Id = 1346,
            ////        Hand1Id = 3040
            ////    },
            ////    new HeadToHeadStat()
            ////    {
            ////        Id = 13463041,
            ////        Hand0Id = 1346,
            ////        Hand1Id = 3041
            ////    },
            ////    new HeadToHeadStat()
            ////    {
            ////        Id = 13463042,
            ////        Hand0Id = 1346,
            ////        Hand1Id = 3042
            ////    }

            ////};
            ////13463039 13463040  13463041  13463042
            //var chopCount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            //Parallel.ForEach(startingHands, new ParallelOptions() { MaxDegreeOfParallelism = 3 }, sh =>
            ////startingHands.ForEach(sh =>
            //{
            //    Hand h0 = new Hand(sh.Hand0Id);
            //    Hand h1 = new Hand(sh.Hand1Id);
            //    //h0.Cards = new List<Card>() { Card.Diamond2, Card.Spade9 };
            //    //h1.Cards = new List<Card>() { Card.Heart6, Card.Spade2 };
            //    List<Hand> hands = new List<Hand>() { h0, h1 };

            //    Deck d = new Deck();
            //    long h0w = 0;
            //    long h1w = 0;
            //    long chops = 0;

            //    d.RemoveCards(h0.Cards);
            //    d.RemoveCards(h1.Cards);
            //    List<Card> currBoard = new List<Card>(5);
            //    List<Card> nextBoard = new List<Card>(d.DealNextCards(5));
            //    //nextBoard = new List<Card>()
            //    //{
            //    //    Card.Diamond3, Card.Spade3, Card.Heart2, Card.Club2, Card.Diamond7
            //    //};
            //    long score = 0;
            //    while (nextBoard != null)
            //    {
            //        d.AddCardsBackToDeckInOrder(currBoard);
            //        currBoard = d.DealCards(nextBoard);

            //        //var result = hc.CalculateWinner(hands , currBoard);
            //        var result = _calculator.CalculateWinnerDll(hands, currBoard);
            //        score = result.WinningScore;
            //        if (result.WinningPlayerNumbers.Count > 1)
            //        {
            //            chopCount[(int)(score / 10000000000)]++;
            //            chops++;
            //        }
            //        else if (result.WinningPlayerNumbers[0] == 0)
            //            h0w++;
            //        else if (result.WinningPlayerNumbers[0] == 1)
            //            h1w++;
            //        nextBoard = _calculator.GetNextHand(nextBoard, d.Cards);

            //        //nextBoard = null;
            //    }

            //    _pokerRepo.UpdateHeadToHeadStatValues(sh.Id, h0w, h1w, chops);
            //    Debug.WriteLine("------------");
            //    Debug.WriteLine("Id: " + sh.Id);
            //    Debug.WriteLine("h0: " + h0w);
            //    Debug.WriteLine("h1: " + h1w);
            //    Debug.WriteLine("chops: " + chops);
            //    //Debug.WriteLine("score: " + score);
            //    Debug.WriteLine("------------");
            //});

            //timers.Add(watch.Elapsed.TotalSeconds);

            //watch.Stop();
            ////return null;
        }

        private RoundResult CalculateWinner()   //-------- unused???
        {
            //var winners = new List<Player>();
            //var winnerNumbers = new List<int>();
            ////var commCards = Board;

            //long highScore = 0;
            //long handScore = 0;

            //Hand hand;

            //for (int i = 0; i < Players.Count; i++)
            ////foreach(var player in Players)
            //{
            //    hand = new Hand(Players[i].Hand);
            //    hand.Cards.AddRange(Board);

            //    //handScore = hCalc.CalculateHandScore(hand, highScore);
            //    if (handScore == highScore)
            //    {
            //        winners.Add(Players[i]);
            //        winnerNumbers.Add(i);
            //    }
            //    else if (handScore > highScore)
            //    {
            //        highScore = handScore;
            //        winners = new List<Player>() { Players[i] };
            //        winnerNumbers = new List<int>() { i };
            //    }
            //}

            ////return { 'players': arrWinners, 'score': highScore }
            //return new RoundResult() { WinningScore = highScore, WinningPlayerNumbers = winnerNumbers };
            return null;
        }

        private void PrintCards(List<Card> cards, bool addNewLine = true)
        {
            string str = "";
            cards.ForEach(c =>
            {
                str += c.ShortName + " ";
            });
            if (addNewLine)
                Debug.WriteLine(str);
            else
                Debug.Write(str);
        }

        private List<List<Card>> GetPossibleHands()
        {
            var deck = new Deck();
            List<List<Card>> hands = new List<List<Card>>();
            //List<Card> currHand = new List<Card>();
            //List<Card> nextHand = new List<Card>(deck.DealNextCards(2));

            //while (nextHand != null)
            //{
            //    deck.AddCardsBackToDeckInOrder(currHand);
            //    currHand = deck.DealCards(nextHand);
            //    hands.Add(currHand);
            //    nextHand = _calculator.GetNextHand(nextHand, deck.Cards);
            //}
            return hands;
        }

        private List<StartingHand> GetPossibleStartingHands()
        {
            //var h1 = GetPossibleHands();
            ////remove last 3 because there is no hand after them
            //h1.RemoveAt(h1.Count - 1);
            //h1.RemoveAt(h1.Count - 1);
            //h1.RemoveAt(h1.Count - 1);
            //Parallel.ForEach(h1, h =>
            //{
            //    MDUContext _db = new MDUContext();
            //    Deck d = new Deck(h[0].Id);
            //    d.RemoveCards(h);

            //    List<List<Card>> hands = new List<List<Card>>();
            //    List<Card> currHand = new List<Card>();
            //    List<Card> nextHand = new List<Card>(d.DealNextCards(2));

            //    while (nextHand != null)
            //    {

            //        d.AddCardsBackToDeckInOrder(currHand);
            //        currHand = d.DealCards(nextHand);
            //        hands.Add(currHand);
            //        _db.HeadToHeadStats.Add(new HeadToHeadStat(new Hand(h), new Hand(currHand), 0, 0, 0));
            //        nextHand = iCalc.GetNextHand(nextHand, d.Cards);
            //    }
            //    _db.SaveChanges();

            //});



            return null;
        }

        private void PrintRound(Hand h0, Hand h1, List<Card> board, RoundResult result)
        {
            Debug.WriteLine("----------------------------");
            PrintCards(h0.Cards);
            PrintCards(h1.Cards);
            PrintCards(board);
            Debug.WriteLine("Score: " + result.WinningScore);
            string str = "";
            for (var i = 0; i < result.WinningPlayerNumbers.Count; i++)
                str += " Player " + result.WinningPlayerNumbers[i].ToString();
            Debug.WriteLine(str);
            Debug.WriteLine("----------------------------");
        }
        
        #endregion

        #region HeadToHeadStats
        //-------- old properties
        //public long Id { get; set; }
        //public int Hand0Id { get; set; }
        //public int Hand1Id { get; set; }
        //public long Hand0Wins { get; set; }
        //public long Hand1Wins { get; set; }
        //public long Chops { get; set; }

        // old constructors
        //public HeadToHeadStat()
        //{

        //}
        //---------------------  move this logic
        //public HeadToHeadStat(Hand h0, Hand h1, long w0, long w1, long chops)
        //{
        //    if (h0.Cards.Count != 2 || h1.Cards.Count != 2)
        //        return;

        //    if (h0.Cards[0].Id < h1.Cards[0].Id)
        //    {
        //        Hand0Id = h0.Cards[1].Id + 100 * h0.Cards[0].Id;
        //        Hand1Id = h1.Cards[1].Id + 100 * h1.Cards[0].Id;
        //    }
        //    else
        //    {
        //        Hand0Id = h1.Cards[1].Id + 100 * h1.Cards[0].Id;
        //        Hand1Id = h0.Cards[1].Id + 100 * h0.Cards[0].Id;
        //    }
        //    Id = Hand1Id + 10000 * Hand0Id;

        //    Hand0Wins = w0;
        //    Hand1Wins = w1;
        //    Chops = chops;
        //}

        

        public List<StartingHand> SetupStartingHands()
        {
            //var iCalc = new IterationCalculator();
            //var h1 = GetPossibleHands();
            ////remove last 3 because there is no hand after them
            //h1.RemoveAt(h1.Count - 1);
            //h1.RemoveAt(h1.Count - 1);
            //h1.RemoveAt(h1.Count - 1);
            //Parallel.ForEach(h1, h =>
            //{
            //    MDUContext _db = new MDUContext();
            //    Deck d = new Deck(h[0].Id);
            //    d.RemoveCards(h);

            //    List<List<Card>> hands = new List<List<Card>>();
            //    List<Card> currHand = new List<Card>();
            //    List<Card> nextHand = new List<Card>(d.DealNextCards(2));
            //    try
            //    {
            //        while (nextHand != null)
            //        {

            //            d.AddCardsBackToDeckInOrder(currHand);
            //            currHand = d.DealCards(nextHand);
            //            hands.Add(currHand);
            //            _db.HeadToHeadStats.Add(new HeadToHeadStat(new Hand(h), new Hand(currHand), 0, 0, 0));
            //            nextHand = iCalc.GetNextHand(nextHand, d.Cards);
            //        }
            //        _db.SaveChanges();
            //    }
            //    catch
            //    {

            //    }

            //});

            return null;
        }

        // dup???
        //private List<List<Card>> GetPossibleHands()
        //{
        //    //var deck = new Deck();
        //    //List<List<Card>> hands = new List<List<Card>>();
        //    //List<Card> currHand = new List<Card>();
        //    //List<Card> nextHand = new List<Card>(deck.DealNextCards(2));
        //    //var iCalc = new IterationCalculator();

        //    //while (nextHand != null)
        //    //{
        //    //    deck.AddCardsBackToDeckInOrder(currHand);
        //    //    currHand = deck.DealCards(nextHand);
        //    //    hands.Add(currHand);
        //    //    nextHand = iCalc.GetNextHand(nextHand, deck.Cards);
        //    //}
        //    //return hands;
        //    return null;
        //}
        #endregion







        #region Private Functions
        private List<Card> GetCardsFromHandId(long handId)
        {
            var cards = new List<Card>(2);
            cards.Add(Card.GetCardById((int)(handId % 100)));
            cards.Add(Card.GetCardById((int)(handId / 100)));
            return cards;
        }
        #endregion
    }
}
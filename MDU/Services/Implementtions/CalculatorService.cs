using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MDU.Models.PokerModels;
using MDU.Services.Contracts;

//using HandCalculatorDll;

namespace MDU.Services.Implementtions
{
    public class CalculatorService : ICalculatorService
    {
        
        #region HandIterationCalculations
        
        // returns null if is already the last hand
        // ASSUMPTIONS:
        // hand and deck are in order
        // hand has 2 cards
        // hand cards are not currently in deck
        public List<Card> GetNextHand(List<Card> hand, SortedList<int, Card> deck)
        {
            // test values
            //hand = new List<Card>{ Card.Club2, Card.Club3 };
            //deck = new SortedList<int, Card>{
            //    {Card.Club4.Id, Card.Club4}, {Card.Club5.Id, Card.Club5 },
            //    {Card.Club10.Id, Card.Club10}, {Card.Diamond6.Id, Card.Diamond6 },
            //    {Card.Diamond12.Id, Card.Diamond12}, {Card.Heart4.Id, Card.Heart4 },
            //    {Card.Heart14.Id, Card.Heart14}, {Card.Spade5.Id, Card.Spade5 },
            //    {Card.Spade8.Id, Card.Spade8}, {Card.Spade12.Id, Card.Spade12 }
            //};

            // a lot of time spend right here...
            SortedList<int, Card> allCards = new SortedList<int, Card>(deck);
            hand.ForEach(c => allCards.Add(c.Id, c));
            //return null;

            List<int> cIndexes = new List<int>();
            hand.ForEach(c => cIndexes.Add(0));
            var length = hand.Count;

            for (int i = length - 1; i >= 0; i--)
            {
                //cIndexes[i] = FindCardInsertPlace(hand[i], deck);
                cIndexes[i] = allCards.IndexOfKey(hand[i].Id);
                //if (cIndexes[i] == deck.Count - 1)

                if (cIndexes[i] == allCards.Count - 2 - (length - i - 1))
                {
                    hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
                    return hand;
                }
                if (cIndexes[i] < allCards.Count - 2 - (length - i - 1))
                {
                    hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
                    // loop forward and assign tail
                    for (int j = i + 1; j < length; j++)
                    {
                        hand[j] = allCards[allCards.Keys[cIndexes[i] + 1 + (j - i)]];
                    }
                    return hand;
                }

            }

            return null;
        }

        public List<Card> GetNextHand2(List<Card> hand, List<Card> deck)
        {
            // test values
            //hand = new List<Card>{ Card.Club2, Card.Club3 };
            //deck = new SortedList<int, Card>{
            //    {Card.Club4.Id, Card.Club4}, {Card.Club5.Id, Card.Club5 },
            //    {Card.Club10.Id, Card.Club10}, {Card.Diamond6.Id, Card.Diamond6 },
            //    {Card.Diamond12.Id, Card.Diamond12}, {Card.Heart4.Id, Card.Heart4 },
            //    {Card.Heart14.Id, Card.Heart14}, {Card.Spade5.Id, Card.Spade5 },
            //    {Card.Spade8.Id, Card.Spade8}, {Card.Spade12.Id, Card.Spade12 }
            //};

            //List<Card> allCards = new List<Card>(hand.Count + deck.Count);
            //for (var i = 0; i < hand.Count; i++)
            //{
            //    for(var j = 0; j < 

            //}
            // adds cards in hand and addCards in order into result--- assumes hand1 and hand2 are already ordered
            //void PokerCalculator::AddInOrderDescending(Card result[], Card hand1[], int hand1Size, Card hand2[], int hand2Size)
            //{
            //    int h1pos = 0;
            //    int h2pos = 0;
            //    int i = 0;
            //    while(h1pos < hand1Size && h2pos < hand2Size )
            //    {
            //        if(hand1[h1pos].num > hand2[h2pos].num)
            //        {
            //            result[i] = hand1[h1pos];
            //            h1pos++;
            //        }
            //        else
            //        {
            //            result[i] = hand2[h2pos];
            //            h2pos++;
            //        }
            //        i++;
            //    }
            //    if(h1pos < hand1Size)
            //    {
            //        for(int j = h1pos; j < hand1Size; j++)
            //        {
            //            result[i] = hand1[j];
            //            i++;
            //        }
            //        return;
            //    }
            //    if(h2pos < hand2Size)
            //    {
            //        for(int j = h2pos; j < hand2Size; j++)
            //        {
            //            result[i] = hand2[j];
            //            i++;
            //        }
            //        return;
            //    }
            //    return;
            //}
            //SortedList<Card> allCards = new List<Card>(deck);
            //allCards.AddRange(hand);
            //allCards = allCards.OrderBy(c => c.Id).ToList();


            ////Debug.WriteLine(c1Index);
            //List<int> cIndexes = new List<int>();
            //hand.ForEach(c => cIndexes.Add(0));
            //var length = hand.Count;

            //for (int i = length - 1; i >= 0; i--)
            //{
            //    //cIndexes[i] = FindCardInsertPlace(hand[i], deck);
            //    cIndexes[i] = allCards.IndexOfKey(hand[i].Id);
            //    //if (cIndexes[i] == deck.Count - 1)

            //    if (cIndexes[i] == allCards.Count - 2 - (length - i - 1))
            //    {
            //        hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
            //        return hand;
            //    }
            //    if (cIndexes[i] < allCards.Count - 2 - (length - i - 1))
            //    {
            //        hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
            //        // loop forward and assign tail
            //        for (int j = i + 1; j < length; j++)
            //        {
            //            hand[j] = allCards[allCards.Keys[cIndexes[i] + 1 + (j - i)]];
            //        }
            //        return hand;
            //    }

            //}

            return null;
        }

        public List<Card> GetNextHand3(List<Card> hand, Deck2 deck)
        {
            // test values
            //hand = new List<Card>{ Card.Club2, Card.Club3 };
            //deck = new SortedList<int, Card>{
            //    {Card.Club4.Id, Card.Club4}, {Card.Club5.Id, Card.Club5 },
            //    {Card.Club10.Id, Card.Club10}, {Card.Diamond6.Id, Card.Diamond6 },
            //    {Card.Diamond12.Id, Card.Diamond12}, {Card.Heart4.Id, Card.Heart4 },
            //    {Card.Heart14.Id, Card.Heart14}, {Card.Spade5.Id, Card.Spade5 },
            //    {Card.Spade8.Id, Card.Spade8}, {Card.Spade12.Id, Card.Spade12 }
            //};


            //SortedList<int, Card> allCards = new SortedList<int, Card>(hand.Count + deck.ActiveCards);
            var allCards = new List<Card>(hand.Count + deck.ActiveCards);
            for (var i = 0; i < allCards.Capacity; i++)
                allCards.Add(null);
            int apos = 0;
            int hpos = 0;
            int dpos = 0;

            while (hpos < hand.Count && dpos < deck.ActiveCards)
            {
                if (!deck.Cards[dpos].IsInUse)
                {
                    if (hand[hpos].Id < deck.Cards[dpos].Card.Id)
                    {
                        allCards[apos] = hand[hpos];
                        hpos++;
                    }
                    else
                    {
                        allCards[apos] = deck.Cards[dpos].Card;
                        dpos++;
                    }
                    apos++;
                }
                else
                    dpos++;
            }
            for (int j = hpos; j < hand.Count; j++)
            {
                allCards[apos] = hand[hpos];
                apos++;
            }
            for (int j = dpos; j < deck.ActiveCards; j++)
            {
                allCards[apos] = deck.Cards[dpos].Card;
                apos++;
            }


            List<int> cIndexes = new List<int>(hand.Count);
            hand.ForEach(c => cIndexes.Add(0));
            var length = hand.Count;

            for (int i = length - 1; i >= 0; i--)
            {
                //cIndexes[i] = FindCardInsertPlace(hand[i], deck);
                cIndexes[i] = FindIndexById(hand[i].Id, allCards);
                //if (cIndexes[i] == deck.Count - 1)

                if (cIndexes[i] == allCards.Count - 2 - (length - i - 1))
                {
                    hand[i] = allCards[cIndexes[i] + 1];
                    return hand;
                }
                if (cIndexes[i] < allCards.Count - 2 - (length - i - 1))
                {
                    hand[i] = allCards[cIndexes[i] + 1];
                    // loop forward and assign tail
                    for (int j = i + 1; j < length; j++)
                    {
                        hand[j] = allCards[cIndexes[i] + 1 + (j - i)];
                    }
                    return hand;
                }

            }

            return null;
        }

        public int FindIndexById(int id, List<Card> cards)
        {
            int min = 0;
            int N = cards.Count;
            int max = N - 1;
            do
            {
                int mid = (min + max) / 2;
                if (id > cards[mid].Id)
                    min = mid + 1;
                else
                    max = mid - 1;
                if (cards[mid].Id == id)
                    return mid;
            } while (min <= max);
            return -1;

        }

        #endregion

        #region BoardIterationCalculations
        public List<List<Card>> GetAllPossibleBoards(List<Card> deadCards)
        {
            var deck = new SortedList<int, Card>(Card.AllCards);
            List<Card> nextBoard = new List<Card>(5);

            for (var i = 0; i < 5; i++)
            {
                nextBoard.Add(deck[deck.Keys[0]]);
                deck.RemoveAt(0);
            }
            List<Card> currBoard = new List<Card>(nextBoard);
            var allBoards = new List<List<Card>>();

            while (nextBoard != null)
            {

                for (var i = 0; i < 5; i++)
                {
                    currBoard[i] = nextBoard[i];
                    deck.Remove(nextBoard[i].Id);
                };

                
                nextBoard = GetNextHand(nextBoard, deck);
                // put last board cards back in deck
                currBoard.ForEach(c => deck.Add(c.Id, c));
            }
            return allBoards;
        }


        // unused???
        // returns null if is already the last possible board
        //public List<int> GetNextBoard(List<int> board, List<int> deck)
        //{
        //    if (board.Count == 0)
        //        return deck.GetRange(0, 5);
        //    int c0Index, c1Index, c2Index, c3Index, c4Index;
        //    c4Index = FindCardInsertPlace(board[4], deck);
        //    if (c4Index == deck.Count)
        //    {
        //        c3Index = FindCardInsertPlace(board[3], deck);
        //        if (c3Index == deck.Count)
        //        {
        //            c2Index = FindCardInsertPlace(board[2], deck);
        //            if (c2Index == deck.Count)
        //            {
        //                c1Index = FindCardInsertPlace(board[1], deck);
        //                if (c1Index == deck.Count)
        //                {
        //                    c0Index = FindCardInsertPlace(board[0], deck);
        //                    if (c0Index == deck.Count)
        //                        return null;
        //                    else if (c0Index == deck.Count - 1)
        //                    {
        //                        board[0] = deck[c0Index];
        //                        return board;
        //                    }
        //                    else
        //                    {
        //                        board[0] = deck[c0Index];
        //                        board[1] = deck[c0Index + 1];
        //                        return board;
        //                    }
        //                }
        //                board[1] = deck[c1Index];
        //                board[2] = deck[c1Index + 1];
        //                board[3] = deck[c1Index + 2];
        //                board[4] = deck[c1Index + 3];
        //            }
        //            board[2] = deck[c2Index];
        //            board[3] = deck[c2Index + 1];
        //            board[4] = deck[c2Index + 2];
        //        }
        //        board[3] = deck[c3Index];
        //        board[4] = deck[c3Index + 1];
        //    }
        //    board[4] = deck[c4Index];

        //    return null;
        //}

        //public List<int> GetNextBoard(List<Card> board, SortedList<int, Card> deck)
        //{
        //    return GetNextBoard(board.Select(c => c.Id).ToList(), deck.Select(c => c.Value.Id).ToList());
        //}

        // returns head2head hand possibilities
        public List<StartingHand> GetAllStartingHandPairs()
        {
            List<StartingHand> startHands = new List<StartingHand>();
            


            return startHands;
        }

        #endregion

        #region HandWinnerCalculator
        
        public List<HandStatResult> CalculateRound_testing(List<Hand> hands, List<Card> initBoard, List<Card> deadCards)
        {
            var timers = new List<double>();
            var watch = new Stopwatch();
            watch.Start();
            timers.Add(watch.Elapsed.TotalSeconds);
            var handStats = new List<HandStatResult>(hands.Count);
            hands.ForEach(h => handStats.Add(new HandStatResult()
            {
                HandId = h.HandId,
                Wins = 0,
                Loses = 0,
                Chops = 0
            }));

            long totalHands = 0;

            var deck = new SortedList<int, Card>(Card.AllCards);

            hands.ForEach(h => h.Cards.ForEach(c => deck.Remove(c.Id)));
            initBoard.ForEach(c => deck.Remove(c.Id));
            deadCards.ForEach(c => deck.Remove(c.Id));

            List<Card> nextBoard = new List<Card>(5);

            for (var i = 0; i < 5; i++)
            {
                nextBoard.Add(deck[deck.Keys[0]]);
                deck.RemoveAt(0);
            }
            List<Card> currBoard = new List<Card>(nextBoard);

            long score = 0;
            while (nextBoard != null)
            {
                for (var i = 0; i < 5; i++)
                {
                    currBoard[i] = nextBoard[i];
                    deck.Remove(nextBoard[i].Id);
                };

                var result = CalculateWinner(hands, currBoard);
                score = result.WinningScore;
                totalHands++;
                if (result.WinningPlayerNumbers.Count > 1)
                    result.WinningPlayerNumbers.ForEach(n => handStats[n].Chops++);
                else
                    handStats[result.WinningPlayerNumbers[0]].Wins++;

                nextBoard = GetNextHand(nextBoard, deck);
                // put last board cards back in deck
                currBoard.ForEach(c => deck.Add(c.Id, c));
            }
            timers.Add(watch.Elapsed.TotalSeconds);
            handStats.ForEach(hs => hs.Loses = totalHands - hs.Wins - hs.Chops);
            watch.Stop();
            return handStats;
        }

        public List<HandStatResult> CalculateRound(List<Hand> hands, List<Card> initBoard, List<Card> deadCards)
        {
            var timers = new List<double>();
            var watch = new Stopwatch();
            watch.Start();
            timers.Add(watch.Elapsed.TotalSeconds);
            var handStats = new List<HandStatResult>(hands.Count);
            hands.ForEach(h => handStats.Add(new HandStatResult()
            {
                HandId = h.HandId,
                Wins = 0,
                Loses = 0,
                Chops = 0
            }));
            
            long totalHands = 0;

            var deck = new SortedList<int, Card>(Card.AllCards);

            hands.ForEach(h => h.Cards.ForEach(c => deck.Remove(c.Id)) );
            initBoard.ForEach(c => deck.Remove(c.Id));
            deadCards.ForEach(c => deck.Remove(c.Id));
                        
            List<Card> nextBoard = new List<Card>(5);
            
            for(var i = 0; i < 5; i++)
            {
                nextBoard.Add(deck[deck.Keys[0]]);
                deck.RemoveAt(0);
            }
            List<Card> currBoard = new List<Card>(nextBoard);

            long score = 0;
            while (nextBoard != null)
            {
                for (var i = 0; i < 5; i++)
                {
                    currBoard[i] = nextBoard[i];
                    deck.Remove(nextBoard[i].Id);
                };

                var result = CalculateWinnerDll(hands, currBoard);
                score = result.WinningScore;
                totalHands++;
                if (result.WinningPlayerNumbers.Count > 1)               
                    result.WinningPlayerNumbers.ForEach(n => handStats[n].Chops++);                
                else
                    handStats[result.WinningPlayerNumbers[0]].Wins++;

                nextBoard = GetNextHand(nextBoard, deck);
                // put last board cards back in deck
                currBoard.ForEach(c => deck.Add(c.Id, c));
            }
            timers.Add(watch.Elapsed.TotalSeconds);
            handStats.ForEach(hs => hs.Loses = totalHands - hs.Wins - hs.Chops);
            watch.Stop();
            return handStats;
        }
        

        //------------ can't use this until I figure out the nuget issue
        public RoundResult CalculateWinnerDll(List<Hand> hands, List<Card> board)
        {
            //PInvoke.SetDllDirectory(
            var result = new RoundResult();

            var reqArr = new int[25];
            for (int i = 0; i < hands.Count; i++)
                for (int j = 0; j < hands[i].Cards.Count; j++)
                    reqArr[2 * i + j] = hands[i].Cards[j].Id;
            for (int i = hands.Count * 2; i < 20; i++)
                reqArr[i] = -1;
            for (int i = 0; i < board.Count; i++)
                reqArr[20 + i] = board[i].Id;

            var success = CalculateWinnerDll(reqArr);


            long highScore = (long)reqArr[23] * 10000 + reqArr[24];
            var winnerNumbers = new List<int>(10);
            for (int i = 0; reqArr[i] != -1 && i < 10; i++)
                winnerNumbers.Add(reqArr[i]);

            return new RoundResult() { WinningScore = highScore, WinningPlayerNumbers = winnerNumbers };
        }

        [DllImport("HandCalculatorDll.dll", EntryPoint = "CalculateWinner", CallingConvention = CallingConvention.StdCall)]
        public static extern bool CalculateWinnerDll(int[] req);
        #endregion

        #region CalculateWinner-c#

        public RoundResult CalculateWinner(List<Hand> hands, List<Card> board)
        {

            var winners = new List<int>(10);
            var winnerNumbers = new List<int>(10);

            long highScore = 0;
            long handScore = 0;

            Hand hand;

            for (int i = 0; i < hands.Count; i++)
            {
                hand = new Hand(hands[i]);
                hand.Cards.AddRange(board);

                handScore = CalculateHandScore(hand, highScore);
                if (handScore == highScore)
                {
                    winners.Add(i);
                    winnerNumbers.Add(i);
                }
                else if (handScore > highScore)
                {
                    highScore = handScore;
                    winners = new List<int>() { i };
                    winnerNumbers = new List<int>() { i };
                }
            }

            return new RoundResult() { WinningScore = highScore, WinningPlayerNumbers = winnerNumbers };
        }

        public long CalculateHandScore(Hand hand, long highScore)
        {
            CalcHand cHand = new CalcHand()
            {
                cards = hand.Cards,
                firstFlush = new List<Card>(),
                firstTrip = new List<Card>(),
                score = 0
            };
            cHand.cards = cHand.cards.OrderByDescending(c => c.Number).ToList();

            int checkTo = (int)(highScore / 10000000000);
            Func<CalcHand, CalcHand>[] HandCheck = {CheckStrFlush, CheckFourKind, CheckFullHouse,
                                            CheckFlush, CheckStr, CheckThreeKind,
                                            CheckTwoPair, CheckPair, CheckHighCard  };

            for (int i = 0; cHand.score == 0 && HandCheck.Length - i > checkTo && i < HandCheck.Length; i++)
            {
                cHand = HandCheck[i](cHand);
            }

            return cHand.score;
        }

        private CalcHand CheckStrFlush(CalcHand cHand)
        {
            cHand.firstFlush = FindFlush(cHand.cards);
            if (cHand.firstFlush.Count > 0)
            {
                var str = FindFirstStr(cHand.firstFlush);
                if (str.Count > 0)
                {
                    cHand.score = 80000000000;
                    cHand.score += str[0].Number * 100000000;
                }
            }
            return cHand;
        }

        private CalcHand CheckFourKind(CalcHand cHand)
        {
            var cardsLeft = 1;
            var tmpHand = new List<Card>(cHand.cards);

            List<Card> quad = FindFirstQuad(tmpHand);
            if (quad.Count > 0)
            {
                cHand.score = 70000000000;
                cHand.score += quad[0].Number * 100000000;
                //tmpHand = tmpHand.Where(c => c.Number != quad[0].Number).ToList();
                tmpHand.RemoveAll(c => c.Number == quad[0].Number);
                cHand.score += ScoreHighCards(tmpHand, cardsLeft);
            }
            return cHand;
        }

        private CalcHand CheckFullHouse(CalcHand cHand)
        {
            long score = 0;
            List<Card> pair;
            var tmpHand = new List<Card>(cHand.cards);

            cHand.firstTrip = FindFirstTrip(tmpHand);
            if (cHand.firstTrip.Count > 0)
            {
                //tmpHand = tmpHand.Where(c => c.Number != cHand.firstTrip[0].Number).ToList();
                tmpHand.RemoveAll(c => c.Number == cHand.firstTrip[0].Number);
                pair = FindFirstPair(tmpHand);
                if (pair.Count > 0)
                {
                    cHand.score = 60000000000;
                    cHand.score += cHand.firstTrip[0].Number * 100000000;
                    cHand.score += pair[0].Number * 1000000;
                }
            }
            return cHand;
        }

        private CalcHand CheckFlush(CalcHand cHand)
        {
            if (cHand.firstFlush.Count == 0)
                return cHand;

            cHand.score = 50000000000;
            cHand.score += ScoreHighCards(cHand.firstFlush, 5);

            return cHand;
        }

        private CalcHand CheckStr(CalcHand cHand)
        {
            var tmpHand = new List<Card>(cHand.cards);
            tmpHand = FindFirstStr(tmpHand);
            if (tmpHand.Count > 0)
            {
                cHand.score = 40000000000;
                cHand.score += tmpHand[0].Number * 100000000;
            }

            return cHand;
        }

        private CalcHand CheckThreeKind(CalcHand cHand)
        {
            if (cHand.firstTrip.Count == 0)
                return cHand;

            var cardsLeft = 2;
            var tmpHand = new List<Card>(cHand.cards.Where(c => c.Number != cHand.firstTrip[0].Number)) { };

            cHand.score = 30000000000;
            cHand.score += cHand.firstTrip[0].Number * 100000000;
            cHand.score += ScoreHighCards(tmpHand, 2);

            return cHand;
        }

        private CalcHand CheckTwoPair(CalcHand cHand)
        {
            var tmpHand = new List<Card>(cHand.cards) { };
            List<Card> pair1 = FindFirstPair(tmpHand);
            cHand.firstPair = new List<Card>(pair1);
            if (pair1.Count > 0)
            {
                //tmpHand = tmpHand.Where(c => c.Number != pair1[0].Number).ToList();
                tmpHand.RemoveAll(c => c.Number == pair1[0].Number);
                List<Card> pair2 = FindFirstPair(tmpHand);
                if (pair2.Count > 0)
                {
                    cHand.score = 20000000000;
                    cHand.score += pair1[0].Number * 100000000;
                    cHand.score += pair2[0].Number * 1000000;
                    //tmpHand = tmpHand.Where(c => c.Number != pair2[0].Number).ToList();
                    tmpHand.RemoveAll(c => c.Number == pair2[0].Number);
                    cHand.score += tmpHand[0].Number;
                }
            }
            return cHand;
        }

        private CalcHand CheckPair(CalcHand cHand)
        {
            if (cHand.firstPair.Count == 0)
                return cHand;
            int cardsLeft = 3;
            var tmpHand = new List<Card>(cHand.cards);

            List<Card> pair = FindFirstPair(tmpHand);
            if (pair.Count > 0)
            {
                cHand.score = 10000000000;
                cHand.score += pair[0].Number * 100000000;
                //tmpHand = tmpHand.Where(c => c.Number != pair[0].Number).ToList();
                tmpHand.RemoveAll(c => c.Number == pair[0].Number);
                cHand.score += ScoreHighCards(tmpHand, cardsLeft);
            }
            return cHand;
        }

        private CalcHand CheckHighCard(CalcHand cHand)
        {
            cHand.score = ScoreHighCards(cHand.cards, 5);
            return cHand;
        }

        //// assumes no more pair/trips left --- hand may be only partial
        private long ScoreHighCards(List<Card> cards, int numCards = 5)
        {
            long score = 0;
            int cardsLeft = numCards;
            for (var i = 0; i < cards.Count && cardsLeft > 0; i++)
            {
                score += cards[i].Number * (long)Math.Pow(100, cardsLeft - 1);
                cardsLeft--;
            }
            return score;
        }

        private List<Card> FindFirstPair(List<Card> cards)
        {
            for (var i = 0; i < cards.Count - 1; i++)
                if (cards[i].Number == cards[i + 1].Number)
                {
                    return new List<Card>() { cards[i], cards[i + 1] };
                }
            return new List<Card>(0);
        }

        private List<Card> FindFirstTrip(List<Card> cards)
        {
            for (var i = 0; i < cards.Count - 2; i++)
                if (cards[i].Number == cards[i + 1].Number && cards[i].Number == cards[i + 2].Number)
                {
                    return new List<Card>() { cards[i], cards[i + 1], cards[i + 2] };
                }
            return new List<Card>(0);
        }

        private List<Card> FindFirstStr(List<Card> cards)
        {
            var failed = false;
            var passed = false;
            var start = 0;
            var i = start;
            var firstStr = new List<Card>(10);
            while (start + 4 < cards.Count && !passed)
            {
                i = start;
                failed = false;
                firstStr.Add(cards[start]);
                while (i + 1 < cards.Count && !failed && firstStr.Count < 5)
                {
                    switch (cards[i].Number - cards[i + 1].Number)
                    {
                        case 0:
                            i++;
                            break;
                        case 1:
                            firstStr.Add(cards[i + 1]);
                            i++;
                            break;
                        default:
                            failed = true;
                            start = i + 1;
                            firstStr.Clear();
                            break;
                    }
                }
                if (firstStr.Count == 5)
                    passed = true;
                else
                    start = i + 1;

            }
            if (passed)
                return firstStr;

            // if not a normal straight, check for wheel
            return this.FindWheel(cards);
        }

        private List<Card> FindWheel(List<Card> cards)
        {
            bool found = false;
            var firstStr = new List<Card>(10);
            // first card has to be Ace and last card a 2
            if (cards[0].Number == 14 && cards[cards.Count - 1].Number == 2)
            {
                // look for 5 -- cant be in first or last 3 spots
                for (var i = 1; i < cards.Count - 3 && !found; i++)
                    if (cards[i].Number == 5)
                    {
                        found = true;
                        firstStr.Add(cards[i]);
                    }
                if (!found)
                    return new List<Card>(0);
                // look for 4 -- cant be in first 2 or last 2 spots
                found = false;
                for (var i = 2; i < cards.Count - 2 && !found; i++)
                    if (cards[i].Number == 4)
                    {
                        found = true;
                        firstStr.Add(cards[i]);
                    }
                if (!found)
                    return new List<Card>(0);
                // look for 3 -- cant be in first 3 or last 1 spots
                found = false;
                for (var i = 3; i < cards.Count - 1 && !found; i++)
                    if (cards[i].Number == 3)
                    {
                        found = true;
                        firstStr.Add(cards[i]);
                    }
                if (!found)
                    return new List<Card>(0);
                // know it contains a 2 so add last card
                firstStr.Add(cards[cards.Count - 1]);

                return firstStr;
            }
            return new List<Card>(0);

        }

        private List<Card> FindFlush(List<Card> cards)
        {
            var suits = new List<List<Card>>(4);
            for (int i = 0; i < 4; i++)
                suits.Add(new List<Card>(10));
            cards.ForEach(c =>
            {
                suits[c.Suit.Id].Add(c);
            });

            var flush = suits.Where(s => s.Count > 4).SingleOrDefault();
            if (flush == null)
                return new List<Card>(0);
            else
                return flush;
        }

        private List<Card> FindFirstQuad(List<Card> cards)
        {
            var quads = new List<Card>(4);
            for (var i = 0; i < cards.Count - 3; i++)
                if (cards[i].Number == cards[i + 1].Number
                    && cards[i].Number == cards[i + 2].Number
                    && cards[i].Number == cards[i + 3].Number)
                {
                    quads = new List<Card>() { cards[i], cards[i + 1], cards[i + 2], cards[i + 3] };
                }
            return quads;
        }

        private class CalcHand
        {
            public List<Card> firstFlush { get; set; }
            public List<Card> firstTrip { get; set; }
            public List<Card> firstPair { get; set; }
            public List<Card> cards { get; set; }
            public long score { get; set; }
        }
        #endregion

        
    }
}
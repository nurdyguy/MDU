using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDU.Models.Poker
{
    public class HandCalculator
    {

        private class FoundHand { public int num {get; set;} public int pos {get; set;} }

        private List<Card> firstFlush { get; set; }
        private List<Card> firstStraight { get; set; }
        private FoundHand firstTrip { get; set; }
        private FoundHand firstPair { get; set; }

        public RoundResult CalculateWinner(List<Hand> hands, List<Card> board)
        {
            var winners = new List<int>();
            var winnerNumbers = new List<int>();
            
            long highScore = 0;
            long handScore = 0;

            Hand hand;

            for(int i = 0; i < hands.Count; i++)
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
            firstFlush = null;
            firstTrip = null;
            long score = 0;
            int checkTo = (int)(highScore / 10000000000);
            Func<Hand, long>[] HandCheck = {CheckStrFlush, CheckFourKind, CheckFullHouse, 
                                            CheckFlush, CheckStr, CheckThreeKind,
                                            CheckTwoPair, CheckPair, CheckHighCard  };
            hand.Cards = hand.Cards.OrderByDescending(c => c.Number).ToList();

            for (int i = 0; i < HandCheck.Length && HandCheck.Length - i > checkTo && score == 0; i++)
            {
                score = HandCheck[i](hand);
            }

            return score;
        }

        private long CheckStrFlush(Hand hand)
        {
            long score = 0;
            //List<Card> flush;
            FoundHand str;
            firstFlush = FindFlush(hand);
            if (firstFlush != null)
            {
                str = FindFirstStr(new Hand() { Cards = firstFlush });
                if (str.num > 0)
                {
                    score = 80000000000;
                    score += str.num * 100000000;
                }
            }
            return score;
        }

        private long CheckFourKind(Hand hand)
        {
            long score = 0;
            FoundHand quad;
            var CardsLeft = 1;
            var tmpHand = new Hand() { Cards = hand.Cards };

            quad = FindFirstQuad(tmpHand);
            if (quad.num > 0)
            {
                score = 70000000000;
                score += quad.num * 100000000;
                tmpHand.Cards = tmpHand.Cards.Where(c => c.Number != quad.num).ToList();
                score += ScoreHighCards(tmpHand, CardsLeft);
            }
            return score;
        }

        // fix for double trips
        private long CheckFullHouse(Hand hand)
        {
            long score = 0;
            FoundHand pair;
            var tmpHand = new Hand() { Cards = hand.Cards };

            firstTrip = FindFirstTrip(tmpHand);
            if (firstTrip.num > 0)
            {
                tmpHand.Cards = tmpHand.Cards.Where(c => c.Number != firstTrip.num).ToList();
                pair = FindFirstPair(tmpHand);
                if (pair.num > 0)
                {           
                    score = 60000000000;
                    score += firstTrip.num * 100000000;
                    score += pair.num * 1000000;
                }
            }
            return score;
        }

        private long CheckFlush(Hand hand)
        {
            if (firstFlush == null)
                return 0;
            long score = 0;
            //List<Card> flush;
            //flush = FindFlush(hand);
            //if (firstFlush.Count >= 5)
            {
                score = 50000000000;
                score += ScoreHighCards(new Hand() { Cards = firstFlush }, 5);
            }
            return score;
        }

        private long CheckStr(Hand hand)
        {
            long score = 0;
            FoundHand str;
            str = FindFirstStr(hand);
            if (str.num > 0)
            {
                score = 40000000000;
                score += str.num * 100000000;
            }
            
            return score;
        }

        private long CheckThreeKind(Hand hand)
        {
            if (firstTrip.num == 0)
                return 0;
            long score = 0;
            //FoundHand trip;
            var CardsLeft = 2;
            var tmpHand = new Hand() { Cards = hand.Cards };
            
            //trip = FindFirstTrip(tmpHand);
            //if (firstTrip.num > 0)
            {
                score = 30000000000;
                score += firstTrip.num * 100000000;
                tmpHand.Cards = tmpHand.Cards.Where(c => c.Number != firstTrip.num).ToList();
                score += ScoreHighCards(tmpHand, CardsLeft);
            }
            return score;
        }

        private long CheckTwoPair(Hand hand)
        {
            long score = 0;
            FoundHand pair1, pair2;
            var CardsLeft = 1;
            var tmpHand = new Hand() { Cards = hand.Cards };

            pair1 = FindFirstPair(tmpHand);
            if (pair1.num > 0)
            {
                tmpHand.Cards = tmpHand.Cards.Where(c => c.Number != pair1.num).ToList();
                pair2 = FindFirstPair(tmpHand);
                if (pair2.num > 0)
                {
                    score = 20000000000;
                    score += pair1.num * 100000000;
                    score += pair2.num * 1000000;
                    tmpHand.Cards = tmpHand.Cards.Where(c => c.Number != pair2.num).ToList();
                    score += ScoreHighCards(tmpHand, CardsLeft);
                }
            }
            return score;
        }

        private long CheckPair(Hand hand)
        {
            long score = 0;
            FoundHand pair;
            int CardsLeft = 3;
            var tmpHand = new Hand() { Cards = hand.Cards };

            pair = FindFirstPair(tmpHand);
            if (pair.num > 0)
            {
                score = 10000000000;
                score += pair.num * 100000000;
                tmpHand.Cards = tmpHand.Cards.Where(c => c.Number != pair.num).ToList();
                score += ScoreHighCards(tmpHand, CardsLeft);
            }
            return score;
        }

        private long CheckHighCard(Hand hand)
        {
            long score = 0;
            score = ScoreHighCards(hand, 5);
            return score;
        }

        //// assumes no more pair/trips left --- hand may be only partial
        private long ScoreHighCards(Hand hand, int numCards = 5)
        {
            long score = 0;
            int CardsLeft = numCards;
            for (var i = 0; i < hand.Cards.Count && CardsLeft > 0; i++)
            {
                score += hand.Cards[i].Number * (long)Math.Pow(100, CardsLeft - 1);
                CardsLeft--;
            }
            return score;
        }


        private FoundHand FindFirstPair(Hand hand)
        {
            for (var i = 0; i < hand.Cards.Count - 1; i++)
                if (hand.Cards[i].Number == hand.Cards[i+1].Number)
                {
                    return new FoundHand(){num =  hand.Cards[i].Number, pos = i };
                }
            return new FoundHand() { num = 0, pos = 0 };
        }


        private FoundHand FindFirstTrip(Hand hand)
        {
            for (var i = 0; i < hand.Cards.Count - 2; i++)
                if (hand.Cards[i].Number == hand.Cards[i + 1].Number && hand.Cards[i].Number == hand.Cards[i + 2].Number)
                {
                    firstTrip = new FoundHand() { num = hand.Cards[i].Number, pos = i };
                    return firstTrip;
                }
            return new FoundHand() { num = 0, pos = 0 };
        }


        private FoundHand FindFirstStr(Hand hand)
        {
            var inARow = 0;
            var failed = false;
            var passed = false;
            var start = 0;
            var i = start;
            while (start + 4 < hand.Cards.Count && !passed)
            {
                i = start;
                failed = false;
                inARow = 0;
                while (i + 1 < hand.Cards.Count && !failed && inARow < 4)
                {
                    switch (hand.Cards[i].Number - hand.Cards[i + 1].Number)
                    {
                        case 0:
                            i++;
                            break;
                        case 1:
                            inARow++;
                            i++;
                            break;
                        default:
                            failed = true;
                            start = i + 1;
                            break;
                    }
                }
                if (inARow == 4)
                {
                    passed = true;
                }
                else
                {
                    start = i + 1;
                }
            }
            if (passed)
            {
                return new FoundHand(){ num = hand.Cards[start].Number, pos = start };
            }
            // if not a normal straight, check for wheel
            return this.FindWheel(hand);
        }


        private FoundHand FindWheel(Hand hand)
        {
            bool found = false;
            int pos = 0;
            // first card has to be Ace and last card a 2
            if (hand.Cards[0].Number == 14 && hand.Cards[hand.Cards.Count - 1].Number == 2)
            {
                // look for 5 -- cant be in first or last 3 spots
                for (var i = 1; i < hand.Cards.Count - 3 && !found; i++)
                    if (hand.Cards[i].Number == 5)
                    {
                        found = true;
                        pos = i;
                    }
                if(!found)
                    return new FoundHand() { num = 0, pos = 0 };               
                // look for 4 -- cant be in first 2 or last 2 spots
                found = false;
                for (var i = 2; i < hand.Cards.Count - 2 && !found; i++)
                    if (hand.Cards[i].Number == 4)
                        found = true;
                if(!found)
                    return new FoundHand() { num = 0, pos = 0 };
                // look for 3 -- cant be in first 3 or last 1 spots
                found = false;
                for (var i = 3; i < hand.Cards.Count - 1 && !found; i++)
                    if (hand.Cards[i].Number == 3)
                        found = true;
                if(!found)
                    return new FoundHand() { num = 0, pos = 0 };
                //got to here so passed
                return new FoundHand() { num = 5, pos = pos };
            }
            return new FoundHand() { num = 0, pos = 0 };
            
        }


        private List<Card> FindFlush(Hand hand)
        {
            //List<Card> suited; 
            //foreach (var s in Suit.Suits)
            //{
            //    suited = hand.Cards.Where(c => c.Suit.Id == s.Id).ToList();
            //    if (suited.Count >= 5)
            //        return suited;
            //}
            var suits = new List<List<Card>>();
            for(int i = 0; i < 4; i++)
                suits.Add(new List<Card>());
            hand.Cards.ForEach(c =>
            {
                suits[c.Suit.Id].Add(c);
            });
            
            return suits.Where(s => s.Count > 4).SingleOrDefault();
        }


        private FoundHand FindFirstQuad(Hand hand)
        {
            for (var i = 0; i < hand.Cards.Count - 3; i++)
                if (hand.Cards[i].Number == hand.Cards[i + 1].Number
                    && hand.Cards[i].Number == hand.Cards[i + 2].Number
                    && hand.Cards[i].Number == hand.Cards[i + 3].Number)
                {
                    return new FoundHand() { num = hand.Cards[i].Number, pos = i };
                }
            return new FoundHand() { num = 0, pos = 0 };
        }

    }
}
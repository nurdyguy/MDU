//using System;
//using System.Collections.Generic;
//using System.Linq;
//

//namespace MDU.Models.Poker
//{
//    public class Depricated
//    {

//        //-------------  old C# version of HandCalculator
//        //private class CalcHand
//        //{
//        //    public List<Card> firstFlush { get; set; }
//        //    public List<Card> firstTrip { get; set; }
//        //    public List<Card> firstPair { get; set; }
//        //    public List<Card> cards { get; set; }
//        //    public long score { get; set; }
//        //}


//        //public RoundResult CalculateWinner(List<Hand> hands, List<Card> board)
//        //{
//        //    var winners = new List<int>(10);
//        //    var winnerNumbers = new List<int>(10);

//        //    long highScore = 0;
//        //    long handScore = 0;

//        //    Hand hand;

//        //    for (int i = 0; i < hands.Count; i++)
//        //    {
//        //        hand = new Hand(hands[i]);
//        //        hand.Cards.AddRange(board);

//        //        handScore = CalculateHandScore(hand, highScore);
//        //        if (handScore == highScore)
//        //        {
//        //            winners.Add(i);
//        //            winnerNumbers.Add(i);
//        //        }
//        //        else if (handScore > highScore)
//        //        {
//        //            highScore = handScore;
//        //            winners = new List<int>() { i };
//        //            winnerNumbers = new List<int>() { i };
//        //        }
//        //    }

//        //    return new RoundResult() { WinningScore = highScore, WinningPlayerNumbers = winnerNumbers };
//        //}
//        //public long CalculateHandScore(Hand hand, long highScore)
//        //{
//        //    CalcHand cHand = new CalcHand()
//        //    {
//        //        cards = hand.Cards,
//        //        firstFlush = new List<Card>(),
//        //        firstTrip = new List<Card>(),
//        //        score = 0
//        //    };
//        //    cHand.cards = cHand.cards.OrderByDescending(c => c.Number).ToList();

//        //    int checkTo = (int)(highScore / 10000000000);
//        //    Func<CalcHand, CalcHand>[] HandCheck = {CheckStrFlush, CheckFourKind, CheckFullHouse, 
//        //                                    CheckFlush, CheckStr, CheckThreeKind,
//        //                                    CheckTwoPair, CheckPair, CheckHighCard  };

//        //    for (int i = 0; cHand.score == 0 && HandCheck.Length - i > checkTo && i < HandCheck.Length; i++)
//        //    {
//        //        cHand = HandCheck[i](cHand);
//        //    }

//        //    return cHand.score;
//        //}

//        //private CalcHand CheckStrFlush(CalcHand cHand)
//        //{
//        //    cHand.firstFlush = FindFlush(cHand.cards);
//        //    if (cHand.firstFlush.Count > 0)
//        //    {
//        //        var str = FindFirstStr(cHand.firstFlush);
//        //        if (str.Count > 0)
//        //        {
//        //            cHand.score = 80000000000;
//        //            cHand.score += str[0].Number * 100000000;
//        //        }
//        //    }
//        //    return cHand;
//        //}

//        //private CalcHand CheckFourKind(CalcHand cHand)
//        //{
//        //    var cardsLeft = 1;
//        //    var tmpHand = new List<Card>(cHand.cards);

//        //    List<Card> quad = FindFirstQuad(tmpHand);
//        //    if (quad.Count > 0)
//        //    {
//        //        cHand.score = 70000000000;
//        //        cHand.score += quad[0].Number * 100000000;
//        //        //tmpHand = tmpHand.Where(c => c.Number != quad[0].Number).ToList();
//        //        tmpHand.RemoveAll(c => c.Number == quad[0].Number);
//        //        cHand.score += ScoreHighCards(tmpHand, cardsLeft);
//        //    }
//        //    return cHand;
//        //}

//        //private CalcHand CheckFullHouse(CalcHand cHand)
//        //{
//        //    long score = 0;
//        //    List<Card> pair;
//        //    var tmpHand = new List<Card>(cHand.cards);

//        //    cHand.firstTrip = FindFirstTrip(tmpHand);
//        //    if (cHand.firstTrip.Count > 0)
//        //    {
//        //        //tmpHand = tmpHand.Where(c => c.Number != cHand.firstTrip[0].Number).ToList();
//        //        tmpHand.RemoveAll(c => c.Number == cHand.firstTrip[0].Number);
//        //        pair = FindFirstPair(tmpHand);
//        //        if (pair.Count > 0)
//        //        {
//        //            cHand.score = 60000000000;
//        //            cHand.score += cHand.firstTrip[0].Number * 100000000;
//        //            cHand.score += pair[0].Number * 1000000;
//        //        }
//        //    }
//        //    return cHand;
//        //}

//        //private CalcHand CheckFlush(CalcHand cHand)
//        //{
//        //    if (cHand.firstFlush.Count == 0)
//        //        return cHand;

//        //    cHand.score = 50000000000;
//        //    cHand.score += ScoreHighCards(cHand.firstFlush, 5);

//        //    return cHand;
//        //}

//        //private CalcHand CheckStr(CalcHand cHand)
//        //{
//        //    var tmpHand = new List<Card>(cHand.cards);
//        //    tmpHand = FindFirstStr(tmpHand);
//        //    if (tmpHand.Count > 0)
//        //    {
//        //        cHand.score = 40000000000;
//        //        cHand.score += tmpHand[0].Number * 100000000;
//        //    }

//        //    return cHand;
//        //}

//        //private CalcHand CheckThreeKind(CalcHand cHand)
//        //{
//        //    if (cHand.firstTrip.Count == 0)
//        //        return cHand;

//        //    var cardsLeft = 2;
//        //    var tmpHand = new List<Card>(cHand.cards.Where(c => c.Number != cHand.firstTrip[0].Number)) { };

//        //    cHand.score = 30000000000;
//        //    cHand.score += cHand.firstTrip[0].Number * 100000000;
//        //    cHand.score += ScoreHighCards(tmpHand, 2);

//        //    return cHand;
//        //}

//        //private CalcHand CheckTwoPair(CalcHand cHand)
//        //{
//        //    var tmpHand = new List<Card>(cHand.cards) { };
//        //    List<Card> pair1 = FindFirstPair(tmpHand);
//        //    cHand.firstPair = new List<Card>(pair1);
//        //    if (pair1.Count > 0)
//        //    {
//        //        //tmpHand = tmpHand.Where(c => c.Number != pair1[0].Number).ToList();
//        //        tmpHand.RemoveAll(c => c.Number == pair1[0].Number);
//        //        List<Card> pair2 = FindFirstPair(tmpHand);
//        //        if (pair2.Count > 0)
//        //        {
//        //            cHand.score = 20000000000;
//        //            cHand.score += pair1[0].Number * 100000000;
//        //            cHand.score += pair2[0].Number * 1000000;
//        //            //tmpHand = tmpHand.Where(c => c.Number != pair2[0].Number).ToList();
//        //            tmpHand.RemoveAll(c => c.Number == pair2[0].Number);
//        //            cHand.score += tmpHand[0].Number;
//        //        }
//        //    }
//        //    return cHand;
//        //}

//        //private CalcHand CheckPair(CalcHand cHand)
//        //{
//        //    if (cHand.firstPair.Count == 0)
//        //        return cHand;
//        //    int cardsLeft = 3;
//        //    var tmpHand = new List<Card>(cHand.cards);

//        //    List<Card> pair = FindFirstPair(tmpHand);
//        //    if (pair.Count > 0)
//        //    {
//        //        cHand.score = 10000000000;
//        //        cHand.score += pair[0].Number * 100000000;
//        //        //tmpHand = tmpHand.Where(c => c.Number != pair[0].Number).ToList();
//        //        tmpHand.RemoveAll(c => c.Number == pair[0].Number);
//        //        cHand.score += ScoreHighCards(tmpHand, cardsLeft);
//        //    }
//        //    return cHand;
//        //}

//        //private CalcHand CheckHighCard(CalcHand cHand)
//        //{
//        //    cHand.score = ScoreHighCards(cHand.cards, 5);
//        //    return cHand;
//        //}

//        ////// assumes no more pair/trips left --- hand may be only partial
//        //private long ScoreHighCards(List<Card> cards, int numCards = 5)
//        //{
//        //    long score = 0;
//        //    int cardsLeft = numCards;
//        //    for (var i = 0; i < cards.Count && cardsLeft > 0; i++)
//        //    {
//        //        score += cards[i].Number * (long)Math.Pow(100, cardsLeft - 1);
//        //        cardsLeft--;
//        //    }
//        //    return score;
//        //}


//        //private List<Card> FindFirstPair(List<Card> cards)
//        //{
//        //    for (var i = 0; i < cards.Count - 1; i++)
//        //        if (cards[i].Number == cards[i + 1].Number)
//        //        {
//        //            return new List<Card>() { cards[i], cards[i + 1] };
//        //        }
//        //    return new List<Card>(0);
//        //}


//        //private List<Card> FindFirstTrip(List<Card> cards)
//        //{
//        //    for (var i = 0; i < cards.Count - 2; i++)
//        //        if (cards[i].Number == cards[i + 1].Number && cards[i].Number == cards[i + 2].Number)
//        //        {
//        //            return new List<Card>() { cards[i], cards[i + 1], cards[i + 2] };
//        //        }
//        //    return new List<Card>(0);
//        //}


//        //private List<Card> FindFirstStr(List<Card> cards)
//        //{
//        //    var failed = false;
//        //    var passed = false;
//        //    var start = 0;
//        //    var i = start;
//        //    var firstStr = new List<Card>(10);
//        //    while (start + 4 < cards.Count && !passed)
//        //    {
//        //        i = start;
//        //        failed = false;
//        //        firstStr.Add(cards[start]);
//        //        while (i + 1 < cards.Count && !failed && firstStr.Count < 5)
//        //        {
//        //            switch (cards[i].Number - cards[i + 1].Number)
//        //            {
//        //                case 0:
//        //                    i++;
//        //                    break;
//        //                case 1:
//        //                    firstStr.Add(cards[i + 1]);
//        //                    i++;
//        //                    break;
//        //                default:
//        //                    failed = true;
//        //                    start = i + 1;
//        //                    firstStr.Clear();
//        //                    break;
//        //            }
//        //        }
//        //        if (firstStr.Count == 5)
//        //            passed = true;
//        //        else
//        //            start = i + 1;

//        //    }
//        //    if (passed)
//        //        return firstStr;

//        //    // if not a normal straight, check for wheel
//        //    return this.FindWheel(cards);
//        //}


//        //private List<Card> FindWheel(List<Card> cards)
//        //{
//        //    bool found = false;
//        //    var firstStr = new List<Card>(10);
//        //    // first card has to be Ace and last card a 2
//        //    if (cards[0].Number == 14 && cards[cards.Count - 1].Number == 2)
//        //    {
//        //        // look for 5 -- cant be in first or last 3 spots
//        //        for (var i = 1; i < cards.Count - 3 && !found; i++)
//        //            if (cards[i].Number == 5)
//        //            {
//        //                found = true;
//        //                firstStr.Add(cards[i]);
//        //            }
//        //        if (!found)
//        //            return new List<Card>(0);
//        //        // look for 4 -- cant be in first 2 or last 2 spots
//        //        found = false;
//        //        for (var i = 2; i < cards.Count - 2 && !found; i++)
//        //            if (cards[i].Number == 4)
//        //            {
//        //                found = true;
//        //                firstStr.Add(cards[i]);
//        //            }
//        //        if (!found)
//        //            return new List<Card>(0);
//        //        // look for 3 -- cant be in first 3 or last 1 spots
//        //        found = false;
//        //        for (var i = 3; i < cards.Count - 1 && !found; i++)
//        //            if (cards[i].Number == 3)
//        //            {
//        //                found = true;
//        //                firstStr.Add(cards[i]);
//        //            }
//        //        if (!found)
//        //            return new List<Card>(0);
//        //        // know it contains a 2 so add last card
//        //        firstStr.Add(cards[cards.Count - 1]);

//        //        return firstStr;
//        //    }
//        //    return new List<Card>(0);

//        //}


//        //private List<Card> FindFlush(List<Card> cards)
//        //{
//        //    var suits = new List<List<Card>>(4);
//        //    for (int i = 0; i < 4; i++)
//        //        suits.Add(new List<Card>(10));
//        //    cards.ForEach(c =>
//        //    {
//        //        suits[c.Suit.Id].Add(c);
//        //    });

//        //    var flush = suits.Where(s => s.Count > 4).SingleOrDefault();
//        //    if (flush == null)
//        //        return new List<Card>(0);
//        //    else
//        //        return flush;
//        //}


//        //private List<Card> FindFirstQuad(List<Card> cards)
//        //{
//        //    var quads = new List<Card>(4);
//        //    for (var i = 0; i < cards.Count - 3; i++)
//        //        if (cards[i].Number == cards[i + 1].Number
//        //            && cards[i].Number == cards[i + 2].Number
//        //            && cards[i].Number == cards[i + 3].Number)
//        //        {
//        //            quads = new List<Card>() { cards[i], cards[i + 1], cards[i + 2], cards[i + 3] };
//        //        }
//        //    return quads;
//        //}
//    }
//}
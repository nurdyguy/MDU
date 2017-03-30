//using System;
//using System.Collections.Generic;
//using System.Linq;
//
//using System.Diagnostics;

//namespace MDU.Models.Poker
//{
//    public class IterationCalculator
//    {
//        //------------------- moved to service
//        //public List<Card> allCards;

//        //public IterationCalculator() { }
//        //public IterationCalculator(int size)
//        //{
//        //    //allCards = new List<Card>(size);
//        //    //for (var i = 0; i < allCards.Capacity; i++)
//        //    //    allCards.Add(Card.Club2);

//        //}
//        //// returns null if is already the last hand
//        //// ASSUMPTIONS:
//        //// hand and deck are in order
//        //// hand has 2 cards
//        //// hand cards are not currently in deck
//        //public List<Card> GetNextHand(List<Card> hand, SortedList<int, Card> deck)
//        //{
//        //    // test values
//        //    //hand = new List<Card>{ Card.Club2, Card.Club3 };
//        //    //deck = new SortedList<int, Card>{
//        //    //    {Card.Club4.Id, Card.Club4}, {Card.Club5.Id, Card.Club5 },
//        //    //    {Card.Club10.Id, Card.Club10}, {Card.Diamond6.Id, Card.Diamond6 },
//        //    //    {Card.Diamond12.Id, Card.Diamond12}, {Card.Heart4.Id, Card.Heart4 },
//        //    //    {Card.Heart14.Id, Card.Heart14}, {Card.Spade5.Id, Card.Spade5 },
//        //    //    {Card.Spade8.Id, Card.Spade8}, {Card.Spade12.Id, Card.Spade12 }
//        //    //};

//        //    // a lot of time spend right here...
//        //    SortedList<int, Card> allCards = new SortedList<int,Card>(deck);
//        //    hand.ForEach(c => allCards.Add(c.Id, c));
//        //    return null;

//        //    List<int> cIndexes = new List<int>();
//        //    hand.ForEach(c => cIndexes.Add(0));
//        //    var length = hand.Count;

//        //    for (int i = length - 1; i >= 0; i--)
//        //    {
//        //        //cIndexes[i] = FindCardInsertPlace(hand[i], deck);
//        //        cIndexes[i] = allCards.IndexOfKey(hand[i].Id);
//        //        //if (cIndexes[i] == deck.Count - 1)

//        //        if (cIndexes[i] == allCards.Count - 2 - (length - i - 1))
//        //        {
//        //            hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
//        //            return hand;
//        //        }
//        //        if (cIndexes[i] < allCards.Count - 2 - (length - i - 1))
//        //        {
//        //            hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
//        //            // loop forward and assign tail
//        //            for (int j = i + 1; j < length; j++)
//        //            {
//        //                hand[j] = allCards[allCards.Keys[cIndexes[i] + 1 + (j - i)]];
//        //            }
//        //            return hand;
//        //        }

//        //    }

//        //    return null;
//        //}

//        //public List<Card> GetNextHand2(List<Card> hand, List<Card> deck)
//        //{
//        //    // test values
//        //    //hand = new List<Card>{ Card.Club2, Card.Club3 };
//        //    //deck = new SortedList<int, Card>{
//        //    //    {Card.Club4.Id, Card.Club4}, {Card.Club5.Id, Card.Club5 },
//        //    //    {Card.Club10.Id, Card.Club10}, {Card.Diamond6.Id, Card.Diamond6 },
//        //    //    {Card.Diamond12.Id, Card.Diamond12}, {Card.Heart4.Id, Card.Heart4 },
//        //    //    {Card.Heart14.Id, Card.Heart14}, {Card.Spade5.Id, Card.Spade5 },
//        //    //    {Card.Spade8.Id, Card.Spade8}, {Card.Spade12.Id, Card.Spade12 }
//        //    //};

//        //    //List<Card> allCards = new List<Card>(hand.Count + deck.Count);
//        //    //for (var i = 0; i < hand.Count; i++)
//        //    //{
//        //    //    for(var j = 0; j < 

//        //    //}
//        //    // adds cards in hand and addCards in order into result--- assumes hand1 and hand2 are already ordered
//        //    //void PokerCalculator::AddInOrderDescending(Card result[], Card hand1[], int hand1Size, Card hand2[], int hand2Size)
//        //    //{
//        //    //    int h1pos = 0;
//        //    //    int h2pos = 0;
//        //    //    int i = 0;
//        //    //    while(h1pos < hand1Size && h2pos < hand2Size )
//        //    //    {
//        //    //        if(hand1[h1pos].num > hand2[h2pos].num)
//        //    //        {
//        //    //            result[i] = hand1[h1pos];
//        //    //            h1pos++;
//        //    //        }
//        //    //        else
//        //    //        {
//        //    //            result[i] = hand2[h2pos];
//        //    //            h2pos++;
//        //    //        }
//        //    //        i++;
//        //    //    }
//        //    //    if(h1pos < hand1Size)
//        //    //    {
//        //    //        for(int j = h1pos; j < hand1Size; j++)
//        //    //        {
//        //    //            result[i] = hand1[j];
//        //    //            i++;
//        //    //        }
//        //    //        return;
//        //    //    }
//        //    //    if(h2pos < hand2Size)
//        //    //    {
//        //    //        for(int j = h2pos; j < hand2Size; j++)
//        //    //        {
//        //    //            result[i] = hand2[j];
//        //    //            i++;
//        //    //        }
//        //    //        return;
//        //    //    }
//        //    //    return;
//        //    //}
//        //    //SortedList<Card> allCards = new List<Card>(deck);
//        //    //allCards.AddRange(hand);
//        //    //allCards = allCards.OrderBy(c => c.Id).ToList();
            

//        //    ////Debug.WriteLine(c1Index);
//        //    //List<int> cIndexes = new List<int>();
//        //    //hand.ForEach(c => cIndexes.Add(0));
//        //    //var length = hand.Count;

//        //    //for (int i = length - 1; i >= 0; i--)
//        //    //{
//        //    //    //cIndexes[i] = FindCardInsertPlace(hand[i], deck);
//        //    //    cIndexes[i] = allCards.IndexOfKey(hand[i].Id);
//        //    //    //if (cIndexes[i] == deck.Count - 1)

//        //    //    if (cIndexes[i] == allCards.Count - 2 - (length - i - 1))
//        //    //    {
//        //    //        hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
//        //    //        return hand;
//        //    //    }
//        //    //    if (cIndexes[i] < allCards.Count - 2 - (length - i - 1))
//        //    //    {
//        //    //        hand[i] = allCards[allCards.Keys[cIndexes[i] + 1]];
//        //    //        // loop forward and assign tail
//        //    //        for (int j = i + 1; j < length; j++)
//        //    //        {
//        //    //            hand[j] = allCards[allCards.Keys[cIndexes[i] + 1 + (j - i)]];
//        //    //        }
//        //    //        return hand;
//        //    //    }

//        //    //}

//        //    return null;
//        //}

//        //public List<Card> GetNextHand3(List<Card> hand, Deck2 deck)
//        //{
//        //    // test values
//        //    //hand = new List<Card>{ Card.Club2, Card.Club3 };
//        //    //deck = new SortedList<int, Card>{
//        //    //    {Card.Club4.Id, Card.Club4}, {Card.Club5.Id, Card.Club5 },
//        //    //    {Card.Club10.Id, Card.Club10}, {Card.Diamond6.Id, Card.Diamond6 },
//        //    //    {Card.Diamond12.Id, Card.Diamond12}, {Card.Heart4.Id, Card.Heart4 },
//        //    //    {Card.Heart14.Id, Card.Heart14}, {Card.Spade5.Id, Card.Spade5 },
//        //    //    {Card.Spade8.Id, Card.Spade8}, {Card.Spade12.Id, Card.Spade12 }
//        //    //};


//        //    //SortedList<int, Card> allCards = new SortedList<int, Card>(hand.Count + deck.ActiveCards);
//        //    var allCards = new List<Card>(hand.Count + deck.ActiveCards);
//        //    for (var i = 0; i < allCards.Capacity; i++)
//        //        allCards.Add(null);
//        //    int apos = 0;
//        //    int hpos = 0;
//        //    int dpos = 0;

//        //    while (hpos < hand.Count && dpos < deck.ActiveCards)
//        //    {
//        //        if (!deck.Cards[dpos].IsInUse)
//        //        {
//        //            if (hand[hpos].Id < deck.Cards[dpos].Card.Id)
//        //            {
//        //                allCards[apos] = hand[hpos];
//        //                hpos++;
//        //            }
//        //            else
//        //            {
//        //                allCards[apos] = deck.Cards[dpos].Card;
//        //                dpos++;
//        //            }
//        //            apos++;
//        //        }
//        //        else
//        //            dpos++;
//        //    }
//        //    for (int j = hpos; j < hand.Count; j++)
//        //    {
//        //        allCards[apos] = hand[hpos];
//        //        apos++;
//        //    }
//        //    for (int j = dpos; j < deck.ActiveCards; j++)
//        //    {
//        //        allCards[apos] = deck.Cards[dpos].Card;
//        //        apos++;
//        //    }


//        //    List<int> cIndexes = new List<int>(hand.Count);
//        //    hand.ForEach(c => cIndexes.Add(0));
//        //    var length = hand.Count;

//        //    for (int i = length - 1; i >= 0; i--)
//        //    {
//        //        //cIndexes[i] = FindCardInsertPlace(hand[i], deck);
//        //        cIndexes[i] = FindIndexById(hand[i].Id, allCards);
//        //        //if (cIndexes[i] == deck.Count - 1)

//        //        if (cIndexes[i] == allCards.Count - 2 - (length - i - 1))
//        //        {
//        //            hand[i] = allCards[cIndexes[i] + 1];
//        //            return hand;
//        //        }
//        //        if (cIndexes[i] < allCards.Count - 2 - (length - i - 1))
//        //        {
//        //            hand[i] = allCards[cIndexes[i] + 1];
//        //            // loop forward and assign tail
//        //            for (int j = i + 1; j < length; j++)
//        //            {
//        //                hand[j] = allCards[cIndexes[i] + 1 + (j - i)];
//        //            }
//        //            return hand;
//        //        }

//        //    }

//        //    return null;
//        //}

//        //public int FindIndexById(int id, List<Card> cards)
//        //{
//        //    int min = 0;
//        //    int N = cards.Count;
//        //    int max = N - 1;
//        //    do
//        //    {
//        //        int mid = (min + max) / 2;
//        //        if (id > cards[mid].Id)
//        //            min = mid + 1;
//        //        else
//        //            max = mid - 1;
//        //        if (cards[mid].Id == id)
//        //            return mid;
//        //    } while (min <= max);
//        //    return -1;

//        //}

//        ////-------------------------------------------------------------------










//        //// returns null if is already the last possible board
//        //public List<int> GetNextBoard(List<int> board, List<int> deck)
//        //{
//        //    if (board.Count == 0)
//        //        return deck.GetRange(0, 5);
//        //    int c0Index, c1Index, c2Index, c3Index, c4Index;
//        //    c4Index = FindCardInsertPlace(board[4], deck);
//        //    if (c4Index == deck.Count)
//        //    {
//        //        c3Index = FindCardInsertPlace(board[3], deck);
//        //        if (c3Index == deck.Count)
//        //        {
//        //            c2Index = FindCardInsertPlace(board[2], deck);
//        //            if (c2Index == deck.Count)
//        //            {
//        //                c1Index = FindCardInsertPlace(board[1], deck);
//        //                if (c1Index == deck.Count)
//        //                {
//        //                    c0Index = FindCardInsertPlace(board[0], deck);
//        //                    if (c0Index == deck.Count)
//        //                        return null;
//        //                    else if (c0Index == deck.Count - 1)
//        //                    {
//        //                        board[0] = deck[c0Index];
//        //                        return board;
//        //                    }
//        //                    else
//        //                    {
//        //                        board[0] = deck[c0Index];
//        //                        board[1] = deck[c0Index + 1];
//        //                        return board;
//        //                    }
//        //                }
//        //                board[1] = deck[c1Index];
//        //                board[2] = deck[c1Index + 1];
//        //                board[3] = deck[c1Index + 2];
//        //                board[4] = deck[c1Index + 3];
//        //            }
//        //            board[2] = deck[c2Index];
//        //            board[3] = deck[c2Index + 1];
//        //            board[4] = deck[c2Index + 2];
//        //        }
//        //        board[3] = deck[c3Index];
//        //        board[4] = deck[c3Index + 1];
//        //    }
//        //    board[4] = deck[c4Index];

//        //    return null;
//        //}

//        //public List<int> GetNextBoard(List<Card> board, SortedList<int, Card> deck)
//        //{
//        //    return GetNextBoard(board.Select(c => c.Id).ToList(), deck.Select(c => c.Value.Id).ToList());
//        //}

//        //// returns head2head hand possibilities
//        //public List<StartingHand> GetAllStartingHandPairs()
//        //{
//        //    List<StartingHand> startHands = new List<StartingHand>();

//        //    return startHands;
//        //}

//        //// unnecessary?
//        //private int FindCardInsertPlace(int card, List<int> deck)
//        //{
//        //    int index = -1;
//        //    int min = 0;
//        //    int max = deck.Count;
//        //    int mid = max / 2;
//        //    bool found = false;
//        //    if (card < deck[0])
//        //        return 0;
//        //    if (card > deck[max-1])
//        //        return max;
            
//        //    while (!found)
//        //    {
//        //        mid = (min + max) / 2;
//        //        if (mid >= deck.Count)
//        //            return deck.Count;
//        //        if (card > deck[mid])
//        //        {
//        //            if (card < deck[mid + 1])
//        //                return mid + 1;
//        //            else
//        //                min = mid + 1;
//        //        }
//        //        else
//        //            if (card < deck[mid])
//        //                max = mid;

//        //    }
//        //    return index;
//        //}


//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace MDU.Models.Poker
{
    public class IterationCalculator
    {

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

            SortedList<int, Card> allCards = new SortedList<int,Card>(deck);
            hand.ForEach(c => allCards.Add(c.Id, c));

            //Debug.WriteLine(c1Index);
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


        // returns null if is already the last possible board
        public List<int> GetNextBoard(List<int> board, List<int> deck)
        {
            if (board.Count == 0)
                return deck.GetRange(0, 5);
            int c0Index, c1Index, c2Index, c3Index, c4Index;
            c4Index = FindCardInsertPlace(board[4], deck);
            if (c4Index == deck.Count)
            {
                c3Index = FindCardInsertPlace(board[3], deck);
                if (c3Index == deck.Count)
                {
                    c2Index = FindCardInsertPlace(board[2], deck);
                    if (c2Index == deck.Count)
                    {
                        c1Index = FindCardInsertPlace(board[1], deck);
                        if (c1Index == deck.Count)
                        {
                            c0Index = FindCardInsertPlace(board[0], deck);
                            if (c0Index == deck.Count)
                                return null;
                            else if (c0Index == deck.Count - 1)
                            {
                                board[0] = deck[c0Index];
                                return board;
                            }
                            else
                            {
                                board[0] = deck[c0Index];
                                board[1] = deck[c0Index + 1];
                                return board;
                            }
                        }
                        board[1] = deck[c1Index];
                        board[2] = deck[c1Index + 1];
                        board[3] = deck[c1Index + 2];
                        board[4] = deck[c1Index + 3];
                    }
                    board[2] = deck[c2Index];
                    board[3] = deck[c2Index + 1];
                    board[4] = deck[c2Index + 2];
                }
                board[3] = deck[c3Index];
                board[4] = deck[c3Index + 1];
            }
            board[4] = deck[c4Index];

            return null;
        }

        public List<int> GetNextBoard(List<Card> board, SortedList<int, Card> deck)
        {
            return GetNextBoard(board.Select(c => c.Id).ToList(), deck.Select(c => c.Value.Id).ToList());
        }

        // returns head2head hand possibilities
        public List<StartingHand> GetAllStartingHandPairs()
        {
            List<StartingHand> startHands = new List<StartingHand>();

            return startHands;
        }

        // unnecessary?
        private int FindCardInsertPlace(int card, List<int> deck)
        {
            int index = -1;
            int min = 0;
            int max = deck.Count;
            int mid = max / 2;
            bool found = false;
            if (card < deck[0])
                return 0;
            if (card > deck[max-1])
                return max;
            
            while (!found)
            {
                mid = (min + max) / 2;
                if (mid >= deck.Count)
                    return deck.Count;
                if (card > deck[mid])
                {
                    if (card < deck[mid + 1])
                        return mid + 1;
                    else
                        min = mid + 1;
                }
                else
                    if (card < deck[mid])
                        max = mid;

            }
            return index;
        }


    }
}
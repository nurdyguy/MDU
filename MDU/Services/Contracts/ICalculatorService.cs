using System;
using System.Collections.Generic;
using System.Linq;

using MDU.Models.PokerModels;

namespace MDU.Services.Contracts
{
    public interface ICalculatorService
    {
        #region HandCalculations
        // returns null if is already the last hand
        // ASSUMPTIONS:
        // hand and deck are in order
        // hand has 2 cards
        // hand cards are not currently in deck
        List<Card> GetNextHand(List<Card> hand, SortedList<int, Card> deck);

        List<Card> GetNextHand2(List<Card> hand, List<Card> deck);

        List<Card> GetNextHand3(List<Card> hand, Deck2 deck);

        int FindIndexById(int id, List<Card> cards);

        #endregion

        #region BoardCalculations
        List<List<Card>> GetAllPossibleBoards(List<Card> deadCards);

        // use GetNextHand instead
        //List<int> GetNextBoard(List<int> board, List<int> deck);
        //List<int> GetNextBoard(List<Card> board, SortedList<int, Card> deck);

        // returns head2head hand possibilities
        List<StartingHand> GetAllStartingHandPairs();

        #endregion

        #region HandWinnerCalculations
        List<HandStatResult> CalculateRound_testing(List<Hand> hands, List<Card> initBoard, List<Card> deadCards);

        List<HandStatResult> CalculateRound(List<Hand> hands, List<Card> initBoard, List<Card> deadCards);

        RoundResult CalculateWinnerDll(List<Hand> hands, List<Card> board);

        #endregion

        #region LinearRegression
        List<double> CalculateLinearRegression(List<double> xVals, List<double> yVals);
        #endregion
    }
}
//using System;
//using System.Collections.Generic;
//using System.Collections.Concurrent;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Linq;
//
//using System.Data;
//using System.Diagnostics;
//using System.Runtime.InteropServices;

//namespace MDU.Models.Poker
//{
//    public class HandCalculator
//    {
//        [DllImport("\\_bin_deployableAssemblies\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
//        //[DllImport("C:\\HostingSpaces\\kayqvolg\\mathdorksunite.com\\wwwroot\\bin\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
//        public static extern bool CalculateWinner(int[] req);
//        public RoundResult CalculateWinnerDll(List<Hand> hands, List<Card> board)
//        {
//            //PInvoke.SetDllDirectory(
//            RoundResult result = new RoundResult();

//            var reqArr = new int[25];
//            for (int i = 0; i < hands.Count; i++)
//                for (int j = 0; j < hands[i].Cards.Count; j++)
//                    reqArr[2 * i + j] = hands[i].Cards[j].Id;
//            for (int i = hands.Count * 2; i < 20; i++)
//                reqArr[i] = -1;
//            for (int i = 0; i < board.Count; i++)
//                reqArr[20 + i] = board[i].Id;

//            var success = CalculateWinner(reqArr);

//            long highScore = (long)reqArr[23] * 10000 + reqArr[24];
//            var winnerNumbers = new List<int>(10);
//            for(int i = 0; reqArr[i] != -1 && i < 10; i++)
//                winnerNumbers.Add(reqArr[i]);

//            return new RoundResult() { WinningScore = highScore, WinningPlayerNumbers = winnerNumbers };
//        }


//        public List<double> Timers = new List<double>();


//        public List<long> CalculateRound_testing(List<Hand> hands, List<Card> initBoard, List<Card> deadCards)
//        {
//            var watch = new Stopwatch();
//            watch.Start();
//            Timers.Add(watch.Elapsed.TotalSeconds);

//            var chopCount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//            var playerWins = new List<long>() { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };
//            var playerChops = new List<long>() { 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 , 0 };
//            long totalHands = 0;

//            Deck d = new Deck();
//            //Deck2 d = new Deck2();
            
//            //var iCalc = new IterationCalculator(52 - (hands.Count*2 + deadCards.Count) + 2);
//            var iCalc = new IterationCalculator();
//            hands.ForEach(h => 
//            {
//                d.RemoveCards(h.Cards);
//            });
//            d.RemoveCards(deadCards);

//            List<Card> currBoard = new List<Card>(5);
//            List<Card> nextBoard;
//            if(initBoard != null && initBoard.Count > 0)
//                nextBoard = new List<Card>(d.DealNextCards(5));
//            else
//                nextBoard = new List<Card>(d.DealNextCards(5));
//            long score = 0;
            
//            // with 1.3 million loop
//            // 3.6 sec for deck manip
//            // 6.8 sec if add in iCalc3
//            // 7.8 sec if add in origin iCalc
//            // almost instant w/o loop 
//            // 
//            while (nextBoard != null)
//            //for(var i = 0; i < 1300000; i++)
//            {

//                d.AddCardsBackToDeckInOrder(currBoard);
//                currBoard = d.DealCards(nextBoard);
//                //Task c = Task.Run(() =>
//                //{
//                    var result = CalculateWinnerDll(hands, currBoard);
//                    score = result.WinningScore;
//                    totalHands++;
//                    if (result.WinningPlayerNumbers.Count > 1)
//                        result.WinningPlayerNumbers.ForEach(n => playerChops[n]++);
//                    else
//                        playerWins[result.WinningPlayerNumbers[0]]++;
//                //});
//                nextBoard = iCalc.GetNextHand(nextBoard, d.Cards);
                
//            }

//            //Task.WaitAll(c);
//            Timers.Add(watch.Elapsed.TotalSeconds);
//            playerWins.AddRange(playerChops);
//            playerWins.Add(totalHands);
//            watch.Stop();
//            return playerWins;
//        }

//        public List<long> CalculateRound(List<Hand> hands, List<Card> initBoard, List<Card> deadCards)
//        {
//            var watch = new Stopwatch();
//            watch.Start();
//            Timers.Add(watch.Elapsed.TotalSeconds);

//            var chopCount = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//            var playerWins = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//            var playerChops = new List<long>() { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
//            long totalHands = 0;

//            Deck d = new Deck();
//            var iCalc = new IterationCalculator();

//            hands.ForEach(h =>
//            {
//                d.RemoveCards(h.Cards);
//            });
//            d.RemoveCards(deadCards);

//            List<Card> currBoard = new List<Card>(5);
//            List<Card> nextBoard;
//            if (initBoard != null && initBoard.Count > 0)
//                nextBoard = new List<Card>(d.DealNextCards(5));
//            else
//                nextBoard = new List<Card>(d.DealNextCards(5));
//            long score = 0;
//            while (nextBoard != null)
//            {
//                d.AddCardsBackToDeckInOrder(currBoard);
//                currBoard = d.DealCards(nextBoard);

//                var result = CalculateWinnerDll(hands, currBoard);
//                score = result.WinningScore;
//                totalHands++;
//                if (result.WinningPlayerNumbers.Count > 1)
//                    result.WinningPlayerNumbers.ForEach(n => playerChops[n]++);
//                else
//                    playerWins[result.WinningPlayerNumbers[0]]++;
//                nextBoard = iCalc.GetNextHand(nextBoard, d.Cards);
//            }
//            Timers.Add(watch.Elapsed.TotalSeconds);
//            playerWins.AddRange(playerChops);
//            playerWins.Add(totalHands);
//            watch.Stop();
//            return playerWins;
//        }



        


//    }
//}
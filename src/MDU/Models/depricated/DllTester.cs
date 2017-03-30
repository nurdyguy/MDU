using System;
using System.Collections.Generic;
using System.Linq;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MDU.Models.PokerModels
{
    public class DllTester
    {
        //public class request
        //{
        //    public int[,] hands { get; set; }
        //    public int[] board { get; set; }
        //}

        //public class response
        //{
        //    public int[] winningPlayers { get; set; }
        //    public int winningScore { get; set; }
        //}


        //[DllImport("C:\\Users\\Your Face\\Documents\\Github\\HandCalculatorDll\\Debug\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int GetCardById(int id);
        //[DllImport("C:\\Users\\Your Face\\Documents\\Github\\HandCalculatorDll\\Debug\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern response CalculateWinner(request req);
        //[DllImport("C:\\Users\\Your Face\\Documents\\Github\\HandCalculatorDll\\Debug\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int CalculateWinner2(int[] req);
        //[DllImport("C:\\Users\\Your Face\\Documents\\Github\\HandCalculatorDll\\Debug\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern int[] CalculateWinner3(int[] req);
        //public void RunTest()
        //{
        //    request req = new request()
        //    {
        //        hands = new int[10,2],
        //        board = new int[5]{12, 8, 5, 15, 2}
        //    };
        //    var arr = new int[5] { 12, 8, 5, 15, 2 };
        //    var x = GetCardById(8);
        //    var y = CalculateWinner2(arr);
        //    var z = CalculateWinner3(arr);
        //}


        //[DllImport("C:\\Users\\Your Face\\Documents\\Github\\HandCalculatorDll\\Debug\\HandCalculatorDll.dll", CallingConvention = CallingConvention.Cdecl)]
        //public static extern bool CalculateWinner(int[] req);
        //public void RunTest()
        //{
        //    var arr = new int[5] { 12, 8, 5, 15, 2 };
        //    var success = CalculateWinner(arr);
        //}
        //public void RunTest()
        //{
        //    List<Card> board = new List<Card>()
        //    {
        //        Card.Club8, Card.Diamond8, Card.Club3, Card.Heart3, Card.Diamond14
        //    };
        //    List<Hand> hands = new List<Hand>()
        //    {
        //        new Hand(new List<Card>(){Card.Club9, Card.Diamond9}){},
        //        new Hand(new List<Card>(){Card.Spade10, Card.Spade11}){},
        //        new Hand(new List<Card>(){Card.Club6, Card.Heart10}){}
        //    };

        //    var watch = new Stopwatch();
        //    watch.Start();
        //    for (int i = 0; i < 1700000; i++)
        //    {
        //        HandCalculator hc = new HandCalculator();
        //        var result = hc.CallWinnerDll(hands, board);
        //    }
        //    watch.Stop();
        //    Debug.WriteLine("Timer: " + watch.Elapsed.TotalSeconds);

        //}

    }
}
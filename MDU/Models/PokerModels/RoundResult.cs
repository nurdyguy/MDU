using System;
using System.Collections.Generic;
using System.Linq;


namespace MDU.Models.PokerModels
{

    public class RoundResult   
    {
        //public Player WinningPlayer { get; set; }
        public List<int> WinningPlayerNumbers { get; set; }
        public long WinningScore { get; set; }
    }
}
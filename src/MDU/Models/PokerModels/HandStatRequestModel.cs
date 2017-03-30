using System;
using System.Collections.Generic;
using System.Linq;


namespace MDU.Models.PokerModels
{
    public class HandStatRequestModel
    {
        public int NumPlayers { get; set; }
        public List<List<int>> HandCardIds { get; set; }
        public List<int> DeadCardIds { get; set; }
        public List<int> BoardCardIds { get; set; }
    }
}
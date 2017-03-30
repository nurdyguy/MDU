using System;
using System.Collections.Generic;
using System.Linq;


namespace MDU.Models.PokerModels
{
    public class HandStatResult
    {
        public long HandId { get; set; }
        public long Wins { get; set; }
        public long Loses { get; set; }
        public long Chops { get; set; }
    }
}
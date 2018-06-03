using System;
using System.Collections.Generic;
using System.Linq;


namespace MDU.Models.PokerModels
{
    public class HeadToHeadStat //------- convert this to generic
    {
        public long Id { get; set; }
        public int Hand0Id { get; set; }
        public int Hand1Id { get; set; }
        public long Hand0Wins { get; set; }
        public long Hand1Wins { get; set; }
        public long Chops { get; set; }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDU.Models.Poker
{
    public class Poker
    {
        public int id { get; set; }


        public virtual Game game { get; set; }
        public int gameId { get; set; }


    }
}
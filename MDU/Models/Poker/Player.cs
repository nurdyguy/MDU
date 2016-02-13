using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MDU.Models.Poker
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Hand Hand { get; set; }

        public Player()
        {
            Hand = new Hand();
        }


    }
}
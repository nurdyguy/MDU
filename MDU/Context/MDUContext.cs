using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MDU.Models;
using MDU.Models.Poker;

namespace MDU.Context
{
    public class MDUContext : DbContext
    {
        //public DbSet<Poker> Pokers { get; set; }

        //public DbSet<Game> Games { get; set; }
        


        public DbSet<HeadToHeadStat> HeadToHeadStats { get; set; }



    }
}
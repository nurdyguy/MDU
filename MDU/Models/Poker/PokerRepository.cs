using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace MDU.Models.Poker
{
    public class PokerRepository
    {
        private static readonly string _mduDb = System.Configuration.ConfigurationManager.ConnectionStrings["MDUContext"].ConnectionString;

        public static List<HeadToHeadStat> GetNextCalcBatch(int batchSize)
        {
            using (var conn = OpenConnection())
            {
                const string query = "update HeadToHeadStats set Chops = 1 "
                                       + " output inserted.Id, inserted.Hand0Id, inserted.Hand1Id "
                                       + " where Id in (select Top (@batchSize) Id from HeadToHeadStats where chops = 0) ";
                return conn.Query<HeadToHeadStat>(query, new { batchSize }).ToList();
            }
        }





        private static SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_mduDb);
            conn.Open();
            return conn;
        }
    }
}
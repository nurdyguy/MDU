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

        public static List<HeadToHeadStat> UpdateHeadToHeadStatValues(long handId, long p0Wins, long p1Wins, long chops)
        {
            //string updateQuery = "UPDATE dbo.HeadToHeadStats SET Hand0Wins = @p0, Hand1Wins = @p1, Chops = @p2 WHERE Id = @p3";
            using (var conn = OpenConnection())
            {
                const string query = "UPDATE dbo.HeadToHeadStats "
                                        + " SET Hand0Wins = @p0Wins, Hand1Wins = @p1Wins, Chops = @chops "
                                        + " output inserted.Id, inserted.Hand0Id, inserted.Hand1Id "
                                        + " WHERE Id = @handId";
                return conn.Query<HeadToHeadStat>(query, new { handId, p0Wins, p1Wins, chops }).ToList();
            }
        }

        public static HeadToHeadStat Get2PlayerStatById(int requestId)
        {
            using (var conn = OpenConnection())
            {
                const string query = "Select * from  HeadToHeadStats "
                                       + " where Id = @requestId ";
                return conn.Query<HeadToHeadStat>(query, new { requestId }).First();
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
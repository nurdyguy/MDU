using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using Dapper;
using MDU.Models.AppraisalModels;
using MDU.Repositories.Contracts;

namespace MDU.Repositories.Implementations
{
    public class PropertySalesRepository : IPropertySalesRepository
    {
        private static string _mduDb;

        public PropertySalesRepository(MDUOptions options)
        {
            _mduDb = options.mduConnectionString;
        }
        
        public List<PropertySale> GetPropertySales(int skip = 0, int take = 0)
        {
            using (var conn = OpenConnection())
            {
                var skipTake = " order by 1 ASC OFFSET @skip ROWS";
                if (take > 0)
                    skipTake += " FETCH NEXT @take";

                string query = @"Select * from  PropertySales " + skipTake;
                                      
                return conn.Query<PropertySale>(query, new { skip, take }).AsList();
            }
        }

        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_mduDb);
            conn.Open();
            return conn;
        }
    }
}
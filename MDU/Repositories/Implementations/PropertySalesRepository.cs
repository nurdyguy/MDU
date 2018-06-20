using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Dapper;
using MDU.Models.AppraisalModels;
using MDU.Repositories.Contracts;
using MDU.Models.Appraisal;
using System.Data;

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
            var skipTake = " order by CloseDate ASC OFFSET @skip ROWS ";
            if (take > 0)
                skipTake += " FETCH NEXT @take ROWS ONLY ";

            using (var conn = OpenConnection())
            {

                string query = @"Select * from  PropertySales "
                    + skipTake;

                return conn.Query<PropertySale>(query, new { skip, take }).AsList();
            }
        }
        public List<PropertySale> GetPropertySales(List<PropertyFilterRange> filterRanges, int skip = 0, int take = 0)
        {
            var filter = CreateParametersDictionary(filterRanges);

            var skipTake = " order by CloseDate ASC  ";
            if (take > 0)
                skipTake += " FETCH NEXT @take ROWS ONLY ";

            var ranges = " WHERE 1 = 1 ";

            for(var i = 0; i < filterRanges.Count; i++)
                ranges += $" AND {filter[$"column_{i}"]} BETWEEN @fromVal_{i} AND @toVal_{i} ";

            using (var conn = OpenConnection())
            {
                string query = @"Select * from  PropertySales " 
                    + ranges
                    + skipTake;

                return conn.Query<PropertySale>(query, filter).AsList();
            }
        }

        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_mduDb);
            conn.Open();
            return conn;
        }

        private Dictionary<string, object> CreateParametersDictionary(List<PropertyFilterRange> filters, int skip = 0, int take = 0)
        {
            var dict = new Dictionary<string, object>()
            {
                { "@skip", skip },
                { "@take", take },
            };

            for (var i = 0; i < filters.Count; i++)
            {
                dict.Add($"column_{i}", filters[i].Filter.Description);
                switch (filters[i].Filter.Id)
                {
                    case 0:
                    case 2:
                    case 4:
                    case 6:
                        dict.Add($"@fromVal_{i}", int.Parse(filters[i].FromValue.Value));
                        dict.Add($"@toVal_{i}", int.Parse(filters[i].ToValue.Value));
                        break;
                    case 1:
                    case 5:
                        dict.Add($"@fromVal_{i}", double.Parse(filters[i].FromValue.Value));
                        dict.Add($"@toVal_{i}", double.Parse(filters[i].ToValue.Value));
                        break;
                    case 3:
                        dict.Add($"@fromVal_{i}", bool.Parse(filters[i].FromValue.Value));
                        dict.Add($"@toVal_{i}", bool.Parse(filters[i].FromValue.Value));
                        break;
                    case 7:
                        dict.Add($"@fromVal_{i}", DateTime.Parse(filters[i].FromValue.Value));
                        dict.Add($"@toVal_{i}", DateTime.Parse(filters[i].ToValue.Value));
                        break;
                    default:
                        break;
                }                
            }

            return dict;
        }

    }
}
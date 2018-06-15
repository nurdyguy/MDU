using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using Dapper;
using MDU.Models.AppraisalModels;
using MDU.Repositories.Contracts;
using MDU.Models.Appraisal;

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
            var filters = MapToFilterObjects(filterRanges);
            var skipTake = " order by CloseDate ASC  ";
            if (take > 0)
                skipTake += " FETCH NEXT @take ROWS ONLY ";

            var ranges = " WHERE 1 = 1 ";

            for(var i = 0; i < filterRanges.Count; i++)
            {
                ranges += " AND @filters[i].columnName BETWEEN @filterRanges[i].fromValue AND @filterRanges[i].toValue ";
            }

            using (var conn = OpenConnection())
            {
                

                string query = @"Select * from  PropertySales " 
                    + ranges
                    + skipTake;

                return conn.Query<PropertySale>(query, new { filters, skip, take }).AsList();
                //return conn.Query<PropertySale>(query, (filter, skip, take) => (filter.columnName, filter.fromValue, filter.toValue, skip, take)).AsList(); 
            }
        }

        private SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(_mduDb);
            conn.Open();
            return conn;
        }

        private List<filterObj> MapToFilterObjects(List<PropertyFilterRange> filterRanges)
        {
            var filters = new List<filterObj>();
            for(var i = 0; i < filterRanges.Count; i++)
            {
                var filter = new filterObj();
                filter.columnName = filterRanges[i].Filter.Description;
                switch(filterRanges[i].Filter.Id)
                {
                    case 0:
                    case 2:
                    case 4:
                    case 6:
                        filter.fromVal = int.Parse(filterRanges[i].FromValue.Value);
                        filter.toVal = int.Parse(filterRanges[i].ToValue.Value);
                        break;
                    case 1:
                    case 5:
                        filter.fromVal = double.Parse(filterRanges[i].FromValue.Value);
                        filter.toVal = double.Parse(filterRanges[i].ToValue.Value);
                        break;
                    case 3:
                        filter.fromVal = bool.Parse(filterRanges[i].FromValue.Value);
                        break;
                    case 7:
                        filter.fromVal = DateTime.Parse(filterRanges[i].FromValue.Value);
                        filter.toVal = DateTime.Parse(filterRanges[i].ToValue.Value);
                        break;
                    default:
                        break;
                }
                filters.Add(filter);
            }
            return filters;
        }

        private class filterObj
        {
            public string columnName { get; set; }
            public object fromVal { get; set; }
            public object toVal { get; set; }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using MDU.Models.AppraisalModels;
using MDU.Services.Contracts;
using MDU.Repositories.Contracts;
using MDU.Models.Appraisal;

namespace MDU.Services.Implementtions
{
    public class PropertySalesService : IPropertySalesService
    {
        private readonly IPropertySalesRepository _propertyRepo;

        public PropertySalesService(IPropertySalesRepository propertyRepo)
        {
            _propertyRepo = propertyRepo;
        }

        public List<PropertySale> GetPropertySales()
        {
            return GetPropertySales(0, 0);
        }

        public List<PropertySale> GetPropertySales(int page, int perPage)
        {
            var skip = 0;
            var take = 0;

            if (perPage > 0)
                take = perPage;
            if (page >= 1)
                skip = (page - 1) * take;

            var props = _propertyRepo.GetPropertySales(skip, take);
            return props;
        }

        public List<PropertySale> GetPropertySales(List<PropertyFilterRange> filterRanges, int page, int perPage)
        {
            var skip = 0;
            var take = 0;

            if (perPage > 0)
                take = perPage;
            if (page >= 1)
                skip = (page - 1)*take;
            

            var props = _propertyRepo.GetPropertySales(skip, 0);
            var filteredProps = new List<PropertySale>();
            for (var i = 0; i < props.Count; i++)
            {
                var prop = props[i];
                var failed = false;
                for (var j = 0; j < filterRanges.Count && !failed; j++)
                {
                    switch (filterRanges[j].Filter.Id)
                    {
                        case 0:
                            if (prop.Beds < int.Parse(filterRanges[j].FromValue.Value) || prop.Beds > int.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        case 1:
                            if (prop.Baths < double.Parse(filterRanges[j].FromValue.Value) || prop.Baths > double.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        case 2:
                            if (prop.Garage < int.Parse(filterRanges[j].FromValue.Value) || prop.Garage > int.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        case 3:
                            if (prop.Pool != bool.Parse(filterRanges[j].FromValue.Value))
                                failed = true;
                            break;
                        case 4:
                            if (prop.SquareFeet < int.Parse(filterRanges[j].FromValue.Value) || prop.SquareFeet > int.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        case 5:
                            if (prop.LotSizeAcreage < double.Parse(filterRanges[j].FromValue.Value) || prop.LotSizeAcreage > double.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        case 6:
                            if (prop.YearBuilt < int.Parse(filterRanges[j].FromValue.Value) || prop.YearBuilt > int.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        case 7:
                            if (prop.CloseDate < DateTime.Parse(filterRanges[j].FromValue.Value) || prop.CloseDate > DateTime.Parse(filterRanges[j].ToValue.Value))
                                failed = true;
                            break;
                        default:
                            break;
                    }
                }
                if(!failed)
                    filteredProps.Add(prop);
            }

            return filteredProps;
        }






    }
}
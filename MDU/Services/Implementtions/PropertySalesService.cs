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
            

            var props = _propertyRepo.GetPropertySales(filterRanges, skip, 0);
            
            return props;
        }






    }
}
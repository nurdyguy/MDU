using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

using MDU.Models.AppraisalModels;
using MDU.Services.Contracts;
using MDU.Repositories.Contracts;


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
            var props = _propertyRepo.GetPropertySales();
            return props;
        }
        







    }
}
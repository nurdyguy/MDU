using System;
using System.Collections.Generic;
using System.Linq;

using MDU.Models.AppraisalModels;

namespace MDU.Repositories.Contracts
{
    public interface IPropertySalesRepository
    {
        List<PropertySale> GetPropertySales(int skip = 0, int take = 0);
        
            
    }
}
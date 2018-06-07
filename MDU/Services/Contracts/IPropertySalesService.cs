using System;
using System.Collections.Generic;
using System.Linq;

using MDU.Models.AppraisalModels;

namespace MDU.Services.Contracts
{
    public interface IPropertySalesService
    {
        List<PropertySale> GetPropertySales();
    }
}
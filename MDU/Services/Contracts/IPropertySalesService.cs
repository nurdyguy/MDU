using System.Collections.Generic;

using MDU.Models.Appraisal;
using MDU.Models.AppraisalModels;

namespace MDU.Services.Contracts
{
    public interface IPropertySalesService
    {
        List<PropertySale> GetPropertySales();

        List<PropertySale> GetPropertySales(int page, int perPage);
        List<PropertySale> GetPropertySales(List<PropertyFilterRange> filterRanges, int page, int perPage);
    }
}
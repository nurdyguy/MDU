using MDU.Models.AppraisalModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MDU.Models.AppraisalViewModels
{
    public class PropertySalesVM
    {
        public List<PropertySale> PropertySales { get; set; }
        public List<PropertyFilter> ActiveFilters { get; set; }

    }

    
}

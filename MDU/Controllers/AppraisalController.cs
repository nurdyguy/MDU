using MDU.Models.AppraisalModels;
using MDU.Models.AppraisalViewModels;
using MDU.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace MDU.Controllers
{
    [Authorize("Admin")]
    public class AppraisalController : Controller
    {
        private readonly IPropertySalesService _propertySalesService;

        public AppraisalController(IPropertySalesService propertySalesService)
        {
            _propertySalesService = propertySalesService;
        }
        public IActionResult Index()
        {
            var props = _propertySalesService.GetPropertySales();
            props = props.OrderBy(p => p.CloseDate).Take(15).ToList();

            var vm = new PropertySalesVM()
            {
                PropertySales = props,
                ActiveFilters = new List<PropertyFilter>()
            };
            return View(vm);
        }

        
    }
}

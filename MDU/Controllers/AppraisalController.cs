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
        private readonly ICalculatorService _calculatorService;
        public AppraisalController(IPropertySalesService propertySalesService, ICalculatorService calculatorService)
        {
            _propertySalesService = propertySalesService;
            _calculatorService = calculatorService;
        }
        public IActionResult Index()
        {
            var props = _propertySalesService.GetPropertySales();
            props = props.OrderBy(p => p.CloseDate).ToList();

            var vm = new PropertySalesVM()
            {
                PropertySales = props,
                ActiveFilters = new List<PropertyFilter>()
            };
            return View(vm);
        }

        [HttpPost, Route("/Appraisal/GetFilteredProperties")]
        public IActionResult GetFilteredProperties([FromBody]PropertyListRequestModel request)
        {
            var props = _propertySalesService.GetPropertySales(request.Filters, request.Page, request.PerPage);

            return PartialView("~/Views/Appraisal/_propertiesList.cshtml", props);
        }
        
        [HttpPost, Route("/Appraisal/GetLinearRegression")]
        public IActionResult GetLinearRegression([FromBody]PropertyListRequestModel request)
        {
            var props = _propertySalesService.GetPropertySales(request.Filters, 0, 0);
            var xVals = props.Select(p => (double)p.CloseDate.Ticks).ToList();
            var yVals = props.Select(p => (double)p.ClosePrice).ToList();

            var linReg = _calculatorService.CalculateLinearRegression(xVals, yVals);
            var y0 = (int)(linReg[0] + xVals.First() * linReg[1]);
            var y1 = (int)(linReg[0] + xVals.Last() * linReg[1]);
            return Json(new { x0 = new DateTime((long)xVals.First()), y0, x1 = new DateTime((long)xVals.Last()), y1, r2 = linReg[2] });
        }
    }
}

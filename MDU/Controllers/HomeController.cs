using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MDU.Models;
using System.Text.RegularExpressions;

namespace MDU.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [Route("DevError/{code:int}")]
        public IActionResult DevError(int code)
        {
            return Error(code);
        }

        [Route("Error/{code:int}")]
        public IActionResult Error(int code)
        {
            return View();
        }

        [Route("Error")]
        public IActionResult Error()
        {
            return View();
        }

        [HttpGet, Route("/textregex/{pattern}/{test}")]
        public IActionResult TestRegex(string pattern, string test)
        {
            var x = "asdf a--/\a %&a#!@?<>,.;:~`#$%^&*2@ -|t/";
            var y = Regex.Replace(x, @"[^a-zA-Z\d\s-()]|[!@#$%^&*\\/]{2,}", "_", RegexOptions.None);
            var z = Regex.Replace(x, @"[^\w\d\s-()]{2,}", "_", RegexOptions.None);
            var w = Regex.Replace(x, @"([^a-zA-Z\d\s-()]|[\\\/%&\@\|]){2,}", "_", RegexOptions.None);

            System.Diagnostics.Debug.WriteLine(x);
            System.Diagnostics.Debug.WriteLine(y);
            System.Diagnostics.Debug.WriteLine(z);
            System.Diagnostics.Debug.WriteLine(w);
            return Json(new { result = Regex.Replace(test, pattern, "_", RegexOptions.None) });
        }
    }
}

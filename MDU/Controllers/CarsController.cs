using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MDU.Models.AppraisalViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace MDU.Controllers
{
    public class CarsController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public CarsController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        [Route("/cars/slideshow/{carId}")]
        public async Task<IActionResult> Slideshow(string carId)
        {
            var imgs = new List<string>();
            if (carId == "Firebird")
            {
                string imgPathRoot = $"{_hostingEnvironment.WebRootPath}/images/Cars/Firebird";
                imgs = Directory.EnumerateFiles(imgPathRoot).Select(f => f.Substring(f.IndexOf("wwwroot") + 7)).ToList();                
            }
            else if (carId == "GTO")
            {
                string imgPathRoot = $"{_hostingEnvironment.WebRootPath}/images/Cars/GTO";
                imgs = Directory.EnumerateFiles(imgPathRoot).Select(f => f.Substring(f.IndexOf("wwwroot") + 7)).ToList();
            }
            else
                throw new NotImplementedException();


            return PartialView("_carSlideshowPartial", imgs);
        }
        

    }
}

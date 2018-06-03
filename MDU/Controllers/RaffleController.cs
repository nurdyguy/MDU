using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MDU.Controllers
{
    public class RaffleController : Controller
    {
        //
        // GET: /Raffle/

        public IActionResult Index()
        {
            return View();
        }

    }
}

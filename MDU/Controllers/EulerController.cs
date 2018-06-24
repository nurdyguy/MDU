﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using EulerService.Contracts;


namespace MDU.Controllers
{
    [Authorize("Admin")]
    public class EulerController : Controller
    {
        private readonly IEulerService _eulerService;

        public EulerController(IEulerService eulerService)
        {
            _eulerService = eulerService;
        }

        public async Task<IActionResult> Index()
        {


            return View();
        }

        [HttpGet,
        Route("Euler/{problemNumber:int}/{x:long}"),
        Route("Euler/{problemNumber:int}/{x:long}/{y:int}"),
        Route("Euler/{problemNumber:int}/{x:long}/{y:int}/{z:int}")]
        public async Task<IActionResult> Problem(int problemNumber, long x = 1, int y = 1, int z = 1)
        {
            
            var watch = new Stopwatch();
            var timers = new List<double>();
            watch.Start();

            object result;
            switch (problemNumber)
            {
                case 207:// completed
                    result = _eulerService.RunProblem207(x);
                    break;
                case 401:// completed
                    result = _eulerService.RunProblem401((int)x);
                    break;
                case 461:// completed
                    result = _eulerService.RunProblem461((int)x);
                    break;
                case 467:
                    result = _eulerService.RunProblem467((int)x);
                    break;
                case 482:
                    result = _eulerService.RunProblem482((int)x);
                    break;
                case 483:
                    result = _eulerService.RunProblem483((int)x);
                    break;
                case 500:// completed
                    result = _eulerService.RunProblem500((int)x);
                    break;
                case 501:
                    result = _eulerService.RunProblem501((int)x);
                    break;
                case 504:// completed
                    result = _eulerService.RunProblem504((int)x);
                    break;
                case 566:
                    result = _eulerService.RunProblem566((int)x, y, z);
                    break;
                case 569:// completed
                    result = _eulerService.RunProblem569((int)x);
                    break;
                case 574:
                    result = _eulerService.RunProblem574((int)x);
                    break;
                case 590:
                    result = _eulerService.RunProblem590((int)x);
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            timers.Add(watch.ElapsedMilliseconds / 1000.0);
            watch.Stop();
            return View("~/Views/Euler/Problem.cshtml", Json(new { timers, Result = result }));
        }

    }
}
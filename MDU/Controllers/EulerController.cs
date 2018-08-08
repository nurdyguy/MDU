using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using _euler8 = EulerService.Implementations.EulerProblem8;
using _euler9 = EulerService.Implementations.EulerProblem9;
using _euler10 = EulerService.Implementations.EulerProblem10;
using _euler11 = EulerService.Implementations.EulerProblem11;
using _euler12 = EulerService.Implementations.EulerProblem12;
using _euler13 = EulerService.Implementations.EulerProblem13;
using _euler53 = EulerService.Implementations.EulerProblem53;
using _euler207 = EulerService.Implementations.EulerProblem207;
using _euler357 = EulerService.Implementations.EulerProblem357;
using _euler401 = EulerService.Implementations.EulerProblem401;
using _euler432 = EulerService.Implementations.EulerProblem432;
using _euler458 = EulerService.Implementations.EulerProblem458;
using _euler461 = EulerService.Implementations.EulerProblem461;
using _euler467 = EulerService.Implementations.EulerProblem467;
using _euler482 = EulerService.Implementations.EulerProblem482;
using _euler483 = EulerService.Implementations.EulerProblem483;
using _euler500 = EulerService.Implementations.EulerProblem500;
using _euler501 = EulerService.Implementations.EulerProblem501;
using _euler504 = EulerService.Implementations.EulerProblem504;
using _euler566 = EulerService.Implementations.EulerProblem566;
using _euler569 = EulerService.Implementations.EulerProblem569;
using _euler574 = EulerService.Implementations.EulerProblem574;
using _euler576 = EulerService.Implementations.EulerProblem576;
using _euler590 = EulerService.Implementations.EulerProblem590;

namespace MDU.Controllers
{
    [Authorize("Admin")]
    public class EulerController : Controller
    {
        
        public async Task<IActionResult> Index()
        {


            return View();
        }

        [HttpGet,
        Route("Euler/{problemNumber:int}/{x:double}"),
        Route("Euler/{problemNumber:int}/{x:double}/{y:double}"),
        Route("Euler/{problemNumber:int}/{x:double}/{y:double}/{z:double}")]
        public async Task<IActionResult> Problem(int problemNumber, double x = 1, double y = 1, double z = 1)
        {
            
            var watch = new Stopwatch();
            var timers = new List<double>();
            watch.Start();

            object result;
            switch (problemNumber)
            {
                case 8:// completed
                    result = _euler8.RunProblem(x, y, z);
                    break;
                case 9:// completed
                    result = _euler9.RunProblem(x, y, z);
                    break;
                case 10:// completed
                    result = _euler10.RunProblem(x, y, z);
                    break;
                case 11:// completed
                    result = _euler11.RunProblem(x, y, z);
                    break;
                case 12:// completed
                    result = _euler12.RunProblem(x, y, z);
                    break;
                case 13:// completed
                    result = _euler13.RunProblem(x, y, z);
                    break;
                case 53:// completed
                    result = _euler53.RunProblem(x, y, z);
                    break;
                case 207:// completed
                    result = _euler207.RunProblem(x, y, z);
                    break;
                case 357: 
                    result = _euler357.RunProblem(x, y, z);
                    break;
                case 401:// completed
                    result = _euler401.RunProblem(x, y, z);
                    break;
                case 432:
                    result = _euler432.RunProblem(x, y, z);
                    break;
                case 458:
                    result = _euler458.RunProblem(x, y, z);
                    break;
                case 461:// completed
                    result = _euler461.RunProblem(x, y, z);
                    break;
                case 467:
                    result = _euler467.RunProblem(x, y, z);
                    break;
                case 482:
                    result = _euler482.RunProblem(x, y, z);
                    break;
                case 483:
                    result = _euler483.RunProblem(x, y, z);
                    break;
                case 500:// completed
                    result = _euler500.RunProblem(x, y, z);
                    break;
                case 501:
                    result = _euler501.RunProblem(x, y, z);
                    break;
                case 504:// completed
                    result = _euler504.RunProblem(x, y, z);
                    break;
                case 566:
                    result = _euler566.RunProblem(x, y, z);
                    break;
                case 569:// completed
                    result = _euler569.RunProblem(x, y, z);
                    break;
                case 574:
                    result = _euler574.RunProblem(x, y, z);
                    break;
                case 576:
                    result = _euler576.RunProblem(x, y, z);
                    break;
                case 590:
                    result = _euler590.RunProblem(x, y, z);
                    break;
                default:
                    throw new NotImplementedException();
                    break;
            }

            timers.Add(watch.ElapsedMilliseconds / 1000.0);
            watch.Stop();
            return Json(new { timers, result });
        }

    }
}

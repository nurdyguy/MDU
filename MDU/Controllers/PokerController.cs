using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MDU.Models;
using MDU.Models.Poker;
using MDU.Context;

using System.Runtime.InteropServices;


namespace MDU.Controllers
{
    public class PokerController : Controller
    {
        //private MDUContext db = new MDUContext();

        //
        // GET: /Poker/

        public ActionResult Index()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            //return View(pokers.ToList());
            return View();
        }

        public ActionResult Game()
        {
            // var pokers = db.Pokers.Include(p => p.game);
            return View();
        }

        public ActionResult Probability()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            return View();
        }

        public ActionResult Simulator()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            return View();
        }

        public ActionResult PermCalculator()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            return View();
        }


        public ActionResult CalculateHand(Hand h)
        {


            return null;
        }

        [HttpPost]
        public JsonResult CalculatePerms(Hand startHand)
        {
            Hand nextHand = new Hand();

            //startHand.cards.



            var response = new Object()
            {

            };

            return Json(nextHand);
        }

        [HttpPost]
        public JsonResult SetupStartHands()
        {
            return null;
            var db = new MDUContext();
            var h2h = new HeadToHeadStat();
            //if (db.HeadToHeadStats.ToList().Count() == 812175)
            //    return null;
            //else
            {
                h2h.SetupStartingHands();

            }
            return null;
        }

        [HttpPost]
        public JsonResult BeginStatCalculator(int num)
        {
            var numPlayers = 2;
            var Game = new Game();
            var outcome = Game.PlayRounds(num);
            ViewBag.PlayerWins = outcome.PlayerWins;
            ViewBag.Timers = outcome.Timers;
            var response = Json(outcome.Timers);
            return response;
        }

        public ActionResult TestPage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult RunDllTest()
        {
            var dllTest = new DllTester();
            //dllTest.RunTest();
            var response = Json("");
            return response;
        }

        [HttpPost]
        public JsonResult RunDllTest2()
        {
            var dllTest = new DllTester();
            //dllTest.RunTest();
            var bin = System.Web.Hosting.HostingEnvironment.MapPath("/");
            var path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            var response = Json(bin);
            return response;
        }

        [HttpGet]
        public ActionResult RunDllTest3()
        {
            var numPlayers = 2;
            var Game = new Game();
            var outcome = Game.PlayRounds(1);
            ViewBag.PlayerWins = outcome.PlayerWins;
            ViewBag.Timers = outcome.Timers;
            return View();
        }



        protected override void Dispose(bool disposing)
        {
            //db.Dispose();
            //base.Dispose(disposing);
        }
    }
}
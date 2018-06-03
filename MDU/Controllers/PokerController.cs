using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;


using Microsoft.AspNetCore.Mvc;

using MDU.Models;
using MDU.Models.PokerModels;
using MDU.Services.Contracts;


namespace MDU.Controllers
{
    public class PokerController : Controller
    {
        private readonly IPokerService _pokerDataService;

        public PokerController(IPokerService pokerDataService)
        {
            _pokerDataService = pokerDataService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Game()
        {
            // var pokers = db.Pokers.Include(p => p.game);
            return View();
        }

        public IActionResult Probability()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            return View();
        }

        public IActionResult Simulator()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            return View();
        }

        public IActionResult PermCalculator()
        {
            //var pokers = db.Pokers.Include(p => p.game);
            return View();
        }


        public IActionResult CalculateHand(Hand h)
        {


            return null;
        }

        [HttpPost]
        public IActionResult CalculatePerms(Hand startHand)
        {
            Hand nextHand = new Hand();

            //startHand.cards.



            var response = new Object()
            {

            };

            return Json(nextHand);
        }

        [HttpPost]
        public IActionResult SetupStartHands()
        {
            
            return null;
        }

        [HttpPost]
        public IActionResult BeginStatCalculator(int num)
        {
            var numPlayers = 2;
            //var Game = new Game();
            //var outcome = Game.PlayRounds(num);
            //ViewBag.PlayerWins = outcome.PlayerWins;
            //ViewBag.Timers = outcome.Timers;
            //var response = Json(outcome.Timers);
            return null;
        }

        public IActionResult TestPage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RunDllTest()
        {
           // var dllTest = new DllTester();
            //dllTest.RunTest();
            var response = Json("");
            return response;
        }

        [HttpPost]
        public IActionResult RunDllTest2()
        {
            //var dllTest = new DllTester();
            //dllTest.RunTest();
            //var bin = System.Web.Hosting.HostingEnvironment.MapPath("/");
            //var path = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath;
            //var response = Json(bin);
            return null;
        }

        [HttpGet]
        public IActionResult RunDllTest3()
        {
            //var numPlayers = 2;
            //var Game = new Game();
            //var outcome = Game.PlayRounds(1);
            //ViewBag.PlayerWins = outcome.PlayerWins;
            //ViewBag.Timers = outcome.Timers;
            return View();
        }

        [HttpPost]
        public IActionResult GetHandStats([FromBody] HandStatRequestModel request)
        {
            var hands = MapIdsToHands(request.HandCardIds);
            var board = MapIdsToCards(request.BoardCardIds);
            var dead = MapIdsToCards(request.DeadCardIds);
            var result = _pokerDataService.GetHandStats(request.NumPlayers, hands, board, dead);
            
            return Json(result);
        }

        private List<Hand> MapIdsToHands(List<List<int>> handIds)
        {
            if (handIds == null)
                return new List<Hand>(0);

            var hands = new List<Hand>(handIds.Count);            
            handIds.ForEach(h =>
            {
                hands.Add(new Hand(MapIdsToCards(h)));
            });
            return hands;
        }

        private List<Card> MapIdsToCards(List<int> cardIds)
        {
            if (cardIds == null)
                return new List<Card>(0);

            var cards = new List<Card>(cardIds.Count);            
            cardIds.ForEach(c =>
            {
                cards.Add(Card.GetCardById(c));
            });
            return cards;
        }
       
        
    }
}
using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PokerGame.Controllers
{
    public class HomeController : Controller
    {
        public string SessionIdentify
        {
            get { return "GameModelo"; }
        }


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Poker()
        {            
            if (TempData.ContainsKey(SessionIdentify))
                TempData.Remove(SessionIdentify);            

            Game game = new Game();
            TempData.Add(SessionIdentify, game);
            return View("~/Views/Home/Poker.cshtml", game);            
        }

        public PartialViewResult shuffleCards()
        {
            Game game = (Game)TempData[SessionIdentify];

            if (TempData.ContainsKey(SessionIdentify))
                TempData.Remove(SessionIdentify);

            game.deck.Shuffle();

            TempData.Add(SessionIdentify, game);

            return PartialView("~/Views/Home/Cards.cshtml", game.CardsInHand);
        }
       
    }
}
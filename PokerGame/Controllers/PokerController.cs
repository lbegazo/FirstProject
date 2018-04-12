using PokerGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PokerGame.Controllers
{
    public class PokerController : Controller
    {
        public string SessionIdentify
        {
            get { return "GameModelo"; }
            
        }

        // GET: Poker
        public ActionResult Index()
        {
            if (TempData.ContainsKey(SessionIdentify))
                TempData.Remove(SessionIdentify);

            Game game = new Game();
            TempData.Add(SessionIdentify, game);
            return View("~/Views/Poker/Poker.cshtml",game);
        }

        public PartialViewResult shuffleCards()
        {
            Game game = (Game)TempData[SessionIdentify];

            if (TempData.ContainsKey(SessionIdentify))
                TempData.Remove(SessionIdentify);

            game.deck.Shuffle();

            TempData.Add(SessionIdentify, game);

            return PartialView("~/Views/Poker/Cards.cshtml", game.CardsInHand);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace KillerApp_V2.Controllers
{
    public class NummerController : Controller
    {
        NummerLogic nLogic = new NummerLogic();
        // GET: Nummer
        public ActionResult AddToPlaylist()
        {
            return View(nLogic.ViewNummer());
        }
        public ActionResult AddNummerToPlaylist(int? playlistid, int? nummerid)
        {          
            nLogic.AddToPlaylist(Convert.ToInt32(playlistid), Convert.ToInt32(nummerid));
            return View();
        }
        public ActionResult SearchNummer(string searchinput)
        {
            return View(nLogic.SearchNummer(searchinput));
        }
    }
}
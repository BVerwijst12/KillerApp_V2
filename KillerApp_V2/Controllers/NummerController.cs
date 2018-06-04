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
        public ActionResult AddToPlaylistPlaylistID(int? playlistid)
        {
            nLogic.AddToPlaylistPlaylistID(Convert.ToInt32(playlistid));
            return View(nLogic.ViewNummer());
        }
        public ActionResult AddToPlaylistNummerID(int? nummerid)
        {
            nLogic.AddToPlaylistNummerID(Convert.ToInt32(nummerid));
            return RedirectToAction("Index","Home");
        }

    }
}
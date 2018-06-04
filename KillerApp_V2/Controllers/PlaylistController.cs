using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace KillerApp_V2.Controllers
{
    public class PlaylistController : Controller
    {
        PlaylistLogic Plogic = new PlaylistLogic();
        NummerLogic Nlogic = new NummerLogic();
        // GET: Playlist
        [HttpGet]
        public ActionResult AddPlaylist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddPlaylist([Bind(Exclude = "PlaylistID")] Playlist p, Gebruiker g, int? id)
        {
            int playlistid = 0;
            Plogic.GetByID(Convert.ToInt32(id), g);
            playlistid = Plogic.AddPlaylist(p, Convert.ToInt32(id));
            if (playlistid != -1)
            {
                p.PlaylistID = playlistid;
                Plogic.AddVolgerPerLijst(Convert.ToInt32(id), playlistid);
                ViewBag.Message = "playlist aangemaakt ";
                ViewBag.Status = true;
                return View(p);
            }
            ViewBag.Status = false;
            return View();
        }
        [HttpGet]
        public ActionResult ViewPlayList(int? id)
        {
            return View(Plogic.ViewMyPlaylist(Convert.ToInt32(id)));
        }
        [HttpGet]
        public ActionResult ViewOpenbaarPlaylist()
        {
            return View(Plogic.ViewOpenbaarPlaylist());
        }
        [HttpGet]
        public ActionResult VoegNummerToe()
        {
            return View(Nlogic.ViewNummer());
        }
        public ActionResult ViewVolgend(int? id)
        {
            return View(Plogic.ViewVolgend(Convert.ToInt32(id)));
        }
        public ActionResult VolgLijst(int? gebruikerid, int? playlistid)
        {
            Plogic.AddVolgerPerLijst(Convert.ToInt32(gebruikerid), Convert.ToInt32(playlistid));
            return RedirectToAction("ViewOpenbaarPlaylist");
        }
        public ActionResult ViewNummersInLijst(int playlistid)
        {
            var model = Plogic.ViewNummersInLijst(playlistid);
            return View(model);
        }
        //public ActionResult Unfollow(int playlistid)
        //{
        //    Plogic.Unfollow(playlistid);
        //    return RedirectToAction("ViewVolgend");
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Models;

namespace KillerApp_V2.Controllers
{
    public class AlbumController : Controller
    {
        AlbumLogic aLogic = new AlbumLogic();
        // GET: Album
        public ActionResult AllAlbums()
        {
            return View(aLogic.AllAlbums());
        }
        public ActionResult ViewNummerOpAlbum(int albumid)
        {
            return View(aLogic.ViewNummerOpAlbum(albumid));
        }
    }
}
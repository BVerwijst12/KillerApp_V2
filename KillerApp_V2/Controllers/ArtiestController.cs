using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;

namespace KillerApp_V2.Controllers
{
    public class ArtiestController : Controller
    {
        ArtiestLogic aLogic = new ArtiestLogic();
        public ActionResult AllArtiest()
        {
            return View(aLogic.AllArtiest());
        }
        public ActionResult NummerVanArtiest(int artiestid)
        {
            return View(aLogic.NummerVanArtiest(artiestid));
        }
    }
}
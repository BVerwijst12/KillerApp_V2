using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using Models;
using BLL;

namespace KillerApp_V2.Controllers
{
    public class HomeController : Controller
    {
        NummerLogic logic = new NummerLogic();
        public ActionResult Index()
        {
            return View(logic.ViewNummer());
        }
    }
}
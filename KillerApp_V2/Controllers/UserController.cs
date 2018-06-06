using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Models;
using BLL;

namespace KillerApp_V2.Controllers
{
    public class UserController : Controller
    {
        private UserLogic userlogic = new UserLogic();
        // GET: User
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register([Bind(Exclude ="GebruikerID")] Gebruiker g)
        {
            string message = "";
            message = userlogic.register(g);

            if (message == "succes")
            {
                message = " Account is succesvol aangemaakt.";
                ViewBag.Message = message;
                ViewBag.Status = true;
                return View(g);
            }
            ViewBag.Status = false;
            ViewBag.Message = message;
            return View(g);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login)
        {
            string message = "";
            string username = login.Username;
            string password = login.Wachtwoord;
            Gebruiker g = new Gebruiker();
            var gebruiker = userlogic.Login(username, password);
            if (gebruiker is Gebruiker)
            {
                message = " U bent succesvol ingelogd.";
                ViewBag.Message = message;
                ViewBag.Status = true;

                int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                var ticket = new FormsAuthenticationTicket(login.Username, login.RememberMe, timeout);
                string encrypted = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                cookie.Expires = DateTime.Now.AddMinutes(timeout);
                cookie.HttpOnly = true;
                Response.Cookies.Add(cookie);

                //Login Sessie aanmaken
                Session["Gebruiker"] = gebruiker;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login", "User");
        }
    }
}
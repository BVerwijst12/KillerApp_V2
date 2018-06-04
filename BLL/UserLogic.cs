using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class UserLogic
    {
        private UserEngine Engine = new UserEngine();

        public string register(Gebruiker g)
        {
            return Engine.Register(g);
        }
        public object Login(string Gebruikersnaam, string Password)
        {
            return Engine.Login(Gebruikersnaam, Password);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using DAL.repositories;

namespace BLL
{
    public class UserLogic
    {
        public UserRepository repo = new UserRepository(new UserEngine());
         
        public string register(Gebruiker g)
        {
            return repo.Register(g);
        }
        public object Login(string Gebruikersnaam, string Password)
        {
            return repo.Checklogin(Gebruikersnaam, Password);
        }
    }
}

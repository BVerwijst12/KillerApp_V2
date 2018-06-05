using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.repositories
{
    public class UserRepository
    {
        private IUserEngine Interface;
        public UserRepository(IUserEngine Interface)
        {
            this.Interface = Interface;
        }

        public object Login(string Gebruikersnaam, string Password)
        {
            return Interface.Login(Gebruikersnaam, Password);
        }
        public string Register(Gebruiker g)
        {
            return Interface.Register(g);
        }
    }
}

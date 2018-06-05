using Models;

namespace DAL
{
    public interface IUserEngine
    {
        object Login(string Gebruikersnaam, string Password);
        string Register(Gebruiker g);
    }
}
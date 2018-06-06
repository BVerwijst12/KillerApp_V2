using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class UserEngine : IUserEngine
    {
        public string Connectionstring = Database.GetConnectionString();

        public string Register(Gebruiker g)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            try
            {
                con.Open();
                string InsertQuery = "INSERT INTO [Gebruiker](Username, Wachtwoord, Email, DateofBirth)" +
                    " VALUES(@naam, @wachtwoord, @email, @dateofbirth)";
                SqlCommand cmd = new SqlCommand(InsertQuery, con);
                cmd.Parameters.AddWithValue("@naam", g.Username);
                cmd.Parameters.AddWithValue("@wachtwoord", g.Wachtwoord);
                cmd.Parameters.AddWithValue("@email", g.Email);
                cmd.Parameters.AddWithValue("@dateofbirth", g.DateOfBirth);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                string error = e.ToString();
                return error;
            }
            return "succes";
        }

        public object Login(string Gebruikersnaam, string Password)
        {
            int resultuser = 0;
            SqlConnection con = new SqlConnection(Connectionstring);
            try
            {
                con.Open();
                string query = @"SELECT GebruikerID FROM [Gebruiker] WHERE Username = @username AND Wachtwoord = @wachtwoord";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Gebruikersnaam);
                cmd.Parameters.AddWithValue("@wachtwoord", Password);
                resultuser = (int)cmd.ExecuteScalar();
                con.Close();
                if (resultuser > 0)
                {
                    string UserQuerty = @"SELECT GebruikerID, Username, Email, DateofBirth FROM [Gebruiker] WHERE Username = @username and Wachtwoord = @wachtwoord";
                    Gebruiker g = new Gebruiker();
                    SqlCommand cmd2 = new SqlCommand(UserQuerty, con);
                    cmd2.Parameters.AddWithValue("@username", Gebruikersnaam);
                    cmd2.Parameters.AddWithValue("@wachtwoord", Password);
                    con.Open();
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            g.GebruikerID = reader.GetInt32(0);
                            g.Username = reader.GetString(1);
                            g.Email = reader.GetString(2);
                            g.DateOfBirth = reader.GetDateTime(3);
                            g.Username = Gebruikersnaam;
                        }
                    }
                    con.Close();
                    return g;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                con.Close();
                return "gegevens bestaan niet";
            }
            return "unknown error";
        }

    }
}

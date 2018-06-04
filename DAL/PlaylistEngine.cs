using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class PlaylistEngine
    {
        string Connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\bramv\source\repos\KillerApp_V2\KillerApp_V2\App_Data\KillerAppDB.mdf;Integrated Security=True";

        public void GetByID(int id, Gebruiker g)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT GebruikerID, Username, Email FROM [Gebruiker] WHERE GebruikerID = @id", con);
            cmd.Parameters.AddWithValue("@id", id);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    g.GebruikerID = reader.GetInt32(0);
                    g.Username = reader.GetString(1);
                    g.Email = reader.GetString(2);
                }
            }
            con.Close();
        }
        public int AddPlaylist(Playlist p, int gebruikerid)
        {
            Gebruiker g = new Gebruiker();
            g.GebruikerID = gebruikerid;
            try
            {
                string sql = "INSERT INTO [Playlist] (Naam, Openbaar, GemaaktdoorID) VALUES (@naam, @openbaar, @gemaaktdoorid)" +
                    " SET @newid = SCOPE_IDENTITY()";

                SqlConnection con = new SqlConnection(Connectionstring);
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@naam", p.Naam);
                cmd.Parameters.AddWithValue("@openbaar", p.Openbaar);
                cmd.Parameters.AddWithValue("@gemaaktdoorid", g.GebruikerID);
                cmd.Parameters.Add("@newid", SqlDbType.Int).Direction = ParameterDirection.Output;
                //cmd.Parameters.AddWithValue("@gebruikerid", g.GebruikerID);
                //cmd.Parameters.AddWithValue("@playlistid", p.PlaylistID);

                cmd.ExecuteScalar();
                con.Close();
                return (int)cmd.Parameters["@newid"].Value;
            }
            catch (Exception e)
            {
                return -1;
            }
            //return (int)
        }
        public void AddVolgerPerLijst(int gebruikerid, int playlistid)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            string sql2 = "INSERT INTO [Volgersperlijst](GebruikerID, PlaylistID) VALUES (@gebruikerid, @playlistid)";
            SqlCommand cmd2 = new SqlCommand(sql2, con);
            con.Open();
            cmd2.Parameters.AddWithValue("@gebruikerid", gebruikerid);
            cmd2.Parameters.AddWithValue("@playlistid", playlistid);
            cmd2.ExecuteNonQuery();
            con.Close();
        }
        
        public List<Playlist> ViewMyPlayList(int id)
        {
            string sql = "SELECT * FROM Playlist WHERE (GemaaktdoorID = @gebruikersid)";
            var model = new List<Playlist>();
            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@gebruikersid", id);
                cmd.ExecuteNonQuery();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    model.Add(Lijsten.GetPlaylistData(rdr));
                }
                con.Close();
            }
            return model;
        }
        public List<Playlist> ViewOpenbaarPlaylist()
        {
            string sql = "SELECT * FROM Playlist WHERE Openbaar = 1";
            var model = new List<Playlist>();
            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    model.Add(Lijsten.GetPlaylistData(rdr));
                }
                con.Close();
            }
            return model;
        }
        public List<Playlist> ViewVolgend(int gebruikerid)
        {
            string sql = "SELECT PlaylistID FROM Volgersperlijst WHERE GebruikerID = @id";
            List<int> Playlistid = new List<int>();
            SqlConnection con = new SqlConnection(Connectionstring);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@id", gebruikerid);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Playlistid.Add(rdr.GetInt32(0));
            }
            var model = new List<Playlist>();
            con.Close();
            foreach (int i in Playlistid)
            {
                string sql2 = "SELECT * FROM Playlist WHERE PlaylistID = @playlistid";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                con.Open();
                cmd2.Parameters.AddWithValue("@playlistid", i);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    model.Add(Lijsten.GetPlaylistData(rdr2));
                }
                con.Close();
            }
            return model;
        }
        public List<Nummer> ViewNummersInLijst(int playlistid)
        {
            string sql = "SELECT NummerID FROM Nummerperlijst WHERE PlaylistID = @playlistid";
            List<int> nummerid = new List<int>();
            SqlConnection con = new SqlConnection(Connectionstring);
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@playlistid", playlistid);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                nummerid.Add(rdr.GetInt32(0));
            }
            con.Close();
            var model = new List<Nummer>();
            foreach (int i in nummerid)
            {
                con.Open();
                string sql2 = "SELECT * FROM Nummer WHERE NummerID = @nummerid";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.Parameters.AddWithValue("@nummerid", i);
                cmd2.ExecuteNonQuery();
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    model.Add(Lijsten.GetNummerData(rdr2));
                }
                con.Close();
            }
            return model;
        }
        public void Unfollow(int playlistid)
        {
            string sql = "DELETE FROM Volgersperlijst WHERE PlaylistID = @playlistid";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@playlistid", playlistid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}

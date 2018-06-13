using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class NummerEngine : INummerEngine
    {
        string Connectionstring = Database.GetConnectionString();
        public List<Nummer> ViewNummer()
        {
            string sql = "SELECT * FROM Nummer";
            var model = new List<Nummer>();
            using (SqlConnection con = new SqlConnection(Connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    model.Add(Lijsten.GetNummerData(rdr));
                }
                con.Close();
            }
            return model;
        }
        public void AddToPlaylist(int playlistid, int nummerid)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            string sql = "INSERT INTO Nummerperlijst(PlaylistID, NummerID) VALUES (@playlistid, @nummerid)";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@playlistid", playlistid);
            cmd.Parameters.AddWithValue("@nummerid", nummerid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<Nummer> SearchNummer(string searchinput)
        {
            string query = "SELECT * FROM Nummer WHERE Naam = @naam";
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@naam", searchinput);
            cmd.ExecuteScalar();
            var model = new List<Nummer>();
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                model.Add(Lijsten.GetNummerData(rdr));
            }
            con.Close();
            return model;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class NummerEngine
    {
        string Connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\bramv\source\repos\KillerApp_V2\KillerApp_V2\App_Data\KillerAppDB.mdf;Integrated Security=True";
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
        public void AddToPlaylistPlatlistID(int playlistid)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            string sql = "INSERT INTO Nummerperlijst(PlaylistID) VALUES (@playlistid)";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@playlistid", playlistid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void AddToPlaylistNummerID(int nummerid)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            string sql = "UPDATE Nummerperlijst SET NummerID = @nummerid WHERE Id= (SELECT MAX(Id) FROM Nummerperlijst)";
            SqlCommand cmd = new SqlCommand(sql, con);
            con.Open();
            cmd.Parameters.AddWithValue("@nummerid", nummerid);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        
    }
}

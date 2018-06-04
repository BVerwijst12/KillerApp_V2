using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;

namespace DAL
{
    public class AlbumEngine
    {
        public string Connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\bramv\source\repos\KillerApp_V2\KillerApp_V2\App_Data\KillerAppDB.mdf;Integrated Security=True";

        public List<Album> AllAlbums()
        {
            List<Album> model = new List<Album>();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            string query = "SELECT * FROM Album";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                model.Add(Lijsten.GetAlbumData(rdr));
            }
            con.Close();
            return model;
        }
        public List<Nummer> ViewNummerOpAlbum(int albumid)
        {
            SqlConnection con = new SqlConnection(Connectionstring);
            string query = "SELECT NummerID FROM Nummeropalbum WHERE AlbumID = @albumid";
            List<int> nummerid = new List<int>();
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@albumid", albumid);
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
                string querynummer = "SELECT * FROM Nummer WHERE NummerID = @nummerid";
                SqlCommand cmd2 = new SqlCommand(querynummer, con);
                cmd2.Parameters.AddWithValue("@nummerid", i);
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    model.Add(Lijsten.GetNummerData(rdr2));
                }
                con.Close();
            }
            return model;
        }
    }
}

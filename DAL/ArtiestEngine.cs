using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class ArtiestEngine
    {
        string Connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\bramv\source\repos\KillerApp_V2\KillerApp_V2\App_Data\KillerAppDB.mdf;Integrated Security=True; MultipleActiveResultSets=True;";

        public List<Artiest> AllArtiest()
        {
            string sql = "SELECT * FROM Artiest";
            SqlConnection con = new SqlConnection(Connectionstring);
            var model = new List<Artiest>();
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                model.Add(Lijsten.GetArtiestData(rdr));
            }
            return model;
        }
        public List<Nummer> NummerVanArtiest(int artiestid)
        {
            string query = "SELECT NummerID FROM Nummerperartiest WHERE ArtiestID = @artiestid";
            List<int> nummerid = new List<int>();
            SqlConnection con = new SqlConnection(Connectionstring);
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@artiestid", artiestid);
            cmd.ExecuteNonQuery();
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
    }
}

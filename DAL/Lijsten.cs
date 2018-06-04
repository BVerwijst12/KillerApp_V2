﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL
{
    class Lijsten
    {
        public static Nummer GetNummerData(SqlDataReader rdr)
        {
            Nummer nummer = new Nummer
            {
                NummerID = Convert.ToInt32(rdr["NummerID"]),
                Naam = (string)rdr["Naam"],
                Lengte = Convert.ToInt32(rdr["Lengte"]),
                Genre = (string)rdr["Genre"],
                Jaar = Convert.ToInt32(rdr["Jaar"]),
                CoverURL = (string)rdr["CoverURL"],
                Embedcode = (string)rdr["Embedcode"]
            };
            return nummer;
        }
        public static Playlist GetPlaylistData(SqlDataReader rdr)
        {
            Playlist p = new Playlist
            {
                PlaylistID = Convert.ToInt32(rdr["PlaylistID"]),
                Naam = (string)rdr["Naam"],
                Openbaar = Convert.ToBoolean(rdr["Openbaar"])
            };
            return p;
        }
        public static Artiest GetArtiestData(SqlDataReader rdr)
        {
            Artiest a = new Artiest
            {
                ArtiestID = Convert.ToInt32(rdr["ArtiestID"]),
                Naam = (string)rdr["Naam"],
                Genre = (string)rdr["Genre"],
                Photo = (string)rdr["Photo"]
            };
            return a;
        }
        public static Album GetAlbumData(SqlDataReader rdr)
        {
            Album a = new Album
            {
                AlbumID = Convert.ToInt32(rdr["AlbumID"]),
                Naam = (string)rdr["Naam"],
                Genre = (string)rdr["Genre"],
                Jaar = Convert.ToInt32(rdr["Jaar"]),
                Lengte = Convert.ToInt32(rdr["Lengte"]),
                Coverurl = (string)rdr["Coverurl"]
            };
            return a;
        }
    }
}
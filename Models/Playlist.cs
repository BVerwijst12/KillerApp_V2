using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public string Naam { get; set; }
        public bool Openbaar { get; set; }
    }
}
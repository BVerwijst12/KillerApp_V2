using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Naam { get; set; }
        public int Lengte { get; set; }
        public string Genre { get; set; }
        public int Jaar { get; set; }
        public string Coverurl { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models
{
    public class Nummer
    {
        public int NummerID { get; set; }
        public string Naam { get; set; }
        public int Lengte { get; set; }
        public string Genre { get; set; }
        public int Jaar { get; set; }      
        public string CoverURL { get; set; }
        public string Embedcode { get; set; }
        
    }
}
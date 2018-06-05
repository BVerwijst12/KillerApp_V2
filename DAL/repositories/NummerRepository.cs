using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.repositories
{
    public class NummerRepository
    {
        private INummerEngine Interface;
        public NummerRepository(INummerEngine Interface)
        {
            this.Interface = Interface;
        }
        public void AddToPlaylistNummerID(int nummerid)
        {
            Interface.AddToPlaylistNummerID(nummerid);
        }
        public void AddToPlaylistPlaylistID(int playlistid)
        {
            Interface.AddToPlaylistPlaylistID(playlistid);
        }
        public List<Nummer> SearchNummer(string searchinput)
        {
            return Interface.SearchNummer(searchinput);
        }
        public List<Nummer> ViewNummer()
        {
            return Interface.ViewNummer();
        }
    }
}

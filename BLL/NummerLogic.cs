using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.repositories;
using Models;

namespace BLL
{
    public class NummerLogic
    {
        NummerEngine engine = new NummerEngine();
        public NummerRepository repo = new NummerRepository(new NummerEngine());
        public List<Nummer> ViewNummer()
        {
            return repo.ViewNummer();
        }
        public void AddToPlaylistPlaylistID(int playlistid)
        {
            repo.AddToPlaylistPlaylistID(playlistid);
        }
        public void AddToPlaylistNummerID(int nummerid)
        {
            repo.AddToPlaylistNummerID(nummerid);
        }
        public List<Nummer> SearchNummer(string searchinput)
        {
            return repo.SearchNummer(searchinput);
        }

    }
}

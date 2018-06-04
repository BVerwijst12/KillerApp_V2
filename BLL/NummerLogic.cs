using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class NummerLogic
    {
        private NummerEngine engine = new NummerEngine();
        public List<Nummer> ViewNummer()
        {
            return engine.ViewNummer();
        }
        public void AddToPlaylistPlaylistID(int playlistid)
        {
            engine.AddToPlaylistPlatlistID(playlistid);
        }
        public void AddToPlaylistNummerID(int nummerid)
        {
            engine.AddToPlaylistNummerID(nummerid);
        }

    }
}

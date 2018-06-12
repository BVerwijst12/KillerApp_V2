using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface INummerEngine
    {
        void AddToPlaylist(int playlistid, int nummerid);
        List<Nummer> SearchNummer(string searchinput);
        List<Nummer> ViewNummer();
    }
}
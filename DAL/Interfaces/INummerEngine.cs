using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface INummerEngine
    {
        void AddToPlaylistNummerID(int nummerid);
        void AddToPlaylistPlaylistID(int playlistid);
        List<Nummer> SearchNummer(string searchinput);
        List<Nummer> ViewNummer();
    }
}
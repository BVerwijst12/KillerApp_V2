using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface IPlaylistEngine
    {
        int AddPlaylist(Playlist p, int gebruikerid);
        void AddVolgerPerLijst(int gebruikerid, int playlistid);
        void GetByID(int id, Gebruiker g);
        void Unfollow(int playlistid);
        List<Playlist> ViewMyPlayList(int id);
        List<Nummer> ViewNummersInLijst(int playlistid);
        List<Playlist> ViewOpenbaarPlaylist();
        List<Playlist> ViewVolgend(int gebruikerid);
    }
}
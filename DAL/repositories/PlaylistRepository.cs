using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.repositories
{
    public class PlaylistRepository
    {
        private IPlaylistEngine Interface;

        public PlaylistRepository(IPlaylistEngine Interface)
        {
            this.Interface = Interface;
        }
        public int AddPlaylist(Playlist p, int gebruikerid)
        {
            return Interface.AddPlaylist(p, gebruikerid);
        }
        public void AddVolgerPerLijst(int gebruikerid, int playlistid)
        {
            Interface.AddVolgerPerLijst(gebruikerid, playlistid);
        }
        public void GetByID(int id, Gebruiker g)
        {
            Interface.GetByID(id, g);
        }
        public void Unfollow(int playlistid)
        {
            Interface.Unfollow(playlistid);
        }
        public List<Playlist> ViewMyPlayList(int id)
        {
            return Interface.ViewMyPlayList(id);
        }
        public List<Nummer> ViewNummersInLijst(int playlistid)
        {
            return Interface.ViewNummersInLijst(playlistid);
        }
        public List<Playlist> ViewOpenbaarPlaylist()
        {
            return Interface.ViewOpenbaarPlaylist();
        }
        public List<Playlist> ViewVolgend(int gebruikerid)
        {
            return Interface.ViewVolgend(gebruikerid);
        }
    }
}

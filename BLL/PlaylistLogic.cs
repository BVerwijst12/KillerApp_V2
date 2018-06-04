using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BLL
{
    public class PlaylistLogic
    {
        private PlaylistEngine engine = new PlaylistEngine();

        public void GetByID(int id, Gebruiker g)
        {
            engine.GetByID(id, g);
        }
        public int AddPlaylist(Playlist p, int gebruikerid)
        {
            return engine.AddPlaylist(p, gebruikerid);
        }
        public void AddVolgerPerLijst(int gebruikerid, int playlistid)
        {
            engine.AddVolgerPerLijst(gebruikerid, playlistid);
        }
        public List<Playlist> ViewMyPlaylist(int id)
        {
            return engine.ViewMyPlayList(id);
        }
        public List<Playlist> ViewOpenbaarPlaylist()
        {
            return engine.ViewOpenbaarPlaylist();
        }
        public List<Playlist> ViewVolgend(int id)
        {
            return engine.ViewVolgend(id);
        }
        public List<Nummer> ViewNummersInLijst(int playlistid)
        {
            return engine.ViewNummersInLijst(playlistid);
        }
        public void Unfollow(int playlistid)
        {
            engine.Unfollow(playlistid);
        }
    }
}

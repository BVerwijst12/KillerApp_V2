using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using DAL.repositories;

namespace BLL
{
    public class PlaylistLogic
    {
        public PlaylistRepository repo = new PlaylistRepository(new PlaylistEngine());

        public void GetByID(int id, Gebruiker g)
        {
            repo.GetByID(id, g);
        }
        public int AddPlaylist(Playlist p, int gebruikerid)
        {
            return repo.AddPlaylist(p, gebruikerid);
        }
        public void AddVolgerPerLijst(int gebruikerid, int playlistid)
        {
            repo.AddVolgerPerLijst(gebruikerid, playlistid);
        }
        public List<Playlist> ViewMyPlaylist(int id)
        {
            return repo.ViewMyPlayList(id);
        }
        public List<Playlist> ViewOpenbaarPlaylist()
        {
            return repo.ViewOpenbaarPlaylist();
        }
        public List<Playlist> ViewVolgend(int id)
        {
            return repo.ViewVolgend(id);
        }
        public List<Nummer> ViewNummersInLijst(int playlistid)
        {
            return repo.ViewNummersInLijst(playlistid);
        }
        public void Unfollow(int playlistid)
        {
            repo.Unfollow(playlistid);
        }
    }
}

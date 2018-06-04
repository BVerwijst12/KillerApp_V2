using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class AlbumLogic
    {
        AlbumEngine engine = new AlbumEngine();
        public List<Album> AllAlbums()
        {
            return engine.AllAlbums();
        }
        public List<Nummer> ViewNummerOpAlbum(int albumid)
        {
            return engine.ViewNummerOpAlbum(albumid);
        }
    }
}

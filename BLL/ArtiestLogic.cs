using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Models;

namespace BLL
{
    public class ArtiestLogic
    {
        ArtiestEngine aEngine = new ArtiestEngine();

        public List<Artiest> AllArtiest()
        {
            return aEngine.AllArtiest();
        }
        public List<Nummer> NummerVanArtiest(int artiestid)
        {
            return aEngine.NummerVanArtiest(artiestid);
        }
    }
}

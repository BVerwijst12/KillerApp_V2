using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DAL.repositories
{
    public class ArtiestRepository
    {
        IArtiestEngine Interface;
        public ArtiestRepository(IArtiestEngine Interface)
        {
            this.Interface = Interface;
        }
        public List<Artiest> AllArtiest()
        {
            return Interface.AllArtiest();
        }
        public List<Nummer> NummerVanArtiest(int artiestid)
        {
            return Interface.NummerVanArtiest(artiestid);
        }
    }
}

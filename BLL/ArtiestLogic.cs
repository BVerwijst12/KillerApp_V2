using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.repositories;
using Models;

namespace BLL
{
    public class ArtiestLogic
    {
        public ArtiestRepository repo = new ArtiestRepository(new ArtiestEngine()); 

        public List<Artiest> AllArtiest()
        {
            return repo.AllArtiest();
        }
        public List<Nummer> NummerVanArtiest(int artiestid)
        {
            return repo.NummerVanArtiest(artiestid);
        }
    }
}

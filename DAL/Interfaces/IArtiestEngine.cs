using System.Collections.Generic;
using Models;

namespace DAL
{
    public interface IArtiestEngine
    {
        List<Artiest> AllArtiest();
        List<Nummer> NummerVanArtiest(int artiestid);
    }
}
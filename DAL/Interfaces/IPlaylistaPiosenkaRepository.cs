using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPlaylistaPiosenkaRepository
    {
        void Add(PiosenkaNaPlayliscie playlistaPiosenka);
        void Remove(PiosenkaNaPlayliscie playlistaPiosenka);
        IEnumerable<PiosenkaNaPlayliscie>? GetAllByPlaylistaId(int id);
        IEnumerable<PiosenkaNaPlayliscie> GetAll();
    }
}

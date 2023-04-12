using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAlbumNaCharcieRepository
    {
        void Add(AlbumNaCharcie albumNaCharcie);
        void Remove(AlbumNaCharcie albumNaCharcie);
        IEnumerable<AlbumNaCharcie>? GetByAlbumId(int id);
        IEnumerable<AlbumNaCharcie> GetAll();
    }
}

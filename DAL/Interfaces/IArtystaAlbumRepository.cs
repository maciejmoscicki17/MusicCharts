using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IArtystaAlbumRepository
    {
        void Add(ArtystaAlbum artystaAlbum);
        void Remove(ArtystaAlbum artystaAlbum);
        ArtystaAlbum? GetById(int id);
        IEnumerable<ArtystaAlbum> GetAll();
    }
}

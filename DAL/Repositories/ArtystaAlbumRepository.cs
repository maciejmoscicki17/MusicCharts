using DAL.Interfaces;
using ListaPrzebojow.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ArtystaAlbumRepository : IArtystaAlbumRepository
    {
        private readonly ListaPrzebojowContext _context;

        public ArtystaAlbumRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(ArtystaAlbum artystaAlbum)
        {
            _context.artystaAlbumDb.Add(artystaAlbum);
        }

        public IEnumerable<ArtystaAlbum> GetAll()
        {
            return _context.artystaAlbumDb.ToList();
        }

        public ArtystaAlbum? GetById(int id)
        {
            return _context.artystaAlbumDb.Find(id);
        }

        public void Remove(ArtystaAlbum artystaAlbum)
        {
            _context.artystaAlbumDb.Remove(artystaAlbum);
        }
    }
}

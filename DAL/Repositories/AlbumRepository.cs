using DAL.Interfaces;
using ListaPrzebojow.DAL;

namespace DAL.Repositories
{
    public class AlbumRepository : IAlbumRepository
    {
        private readonly ListaPrzebojowContext _context;

        public AlbumRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(Album album)
        {
            _context.albumDb.Add(album);
        }

        public IEnumerable<Album> GetAll()
        {
            return _context.albumDb.ToList();

        }

        public Album GetById(int id)
        {
            return _context.albumDb.FirstOrDefault(a => a.AlbumID == id);
        }

        public void Remove(Album album)
        {
            _context.albumDb.Remove(album);
        }
    }
}

using DAL.Interfaces;
using ListaPrzebojow.DAL;

namespace DAL.Repositories
{
    public class AlbumNaCharcieRepository : IAlbumNaCharcieRepository
    {
        private readonly ListaPrzebojowContext _context;
        public AlbumNaCharcieRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(AlbumNaCharcie albumNaCharcie)
        {
            _context.albumNaCharcieDb.Add(albumNaCharcie);
        }

        public IEnumerable<AlbumNaCharcie> GetAll()
        {
            return _context.albumNaCharcieDb.ToList();
        }

        public IEnumerable<AlbumNaCharcie>? GetByAlbumId(int id)
        {
            return _context.albumNaCharcieDb.Where(x => x.ChartAlbumowID == id);
        }

        public void Remove(AlbumNaCharcie albumNaCharcie)
        {
            _context.albumNaCharcieDb.Remove(albumNaCharcie);
        }
    }
}

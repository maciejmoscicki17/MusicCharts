using DAL.Interfaces;
using ListaPrzebojow.DAL;

namespace DAL.Repositories
{
    public class ChartAlbumowRepository : IChartAlbumowRepository
    {
        private readonly ListaPrzebojowContext _context;

        public ChartAlbumowRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(ChartAlbumow chart)
        {
            _context.chartAlbumowDb.Add(chart);
        }

        public IEnumerable<ChartAlbumow> GetAll()
        {
            return _context.chartAlbumowDb.ToList();

        }

        public ChartAlbumow GetById(int id)
        {
            return _context.chartAlbumowDb.FirstOrDefault(a => a.ChartAlbumowID == id);
        }

        public void Remove(ChartAlbumow chart)
        {
            _context.chartAlbumowDb.Remove(chart);
        }
    }
}

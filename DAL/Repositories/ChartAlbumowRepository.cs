using DAL.Interfaces;
using ListaPrzebojow.DAL;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IEnumerable<ChartAlbumow>> GetAllAsync()
        {
            return await _context.chartAlbumowDb.ToListAsync();
        }

        public void Update(ChartAlbumow chartAlbumow)
        {
            _context.chartAlbumowDb.Update(chartAlbumow);
        }

        public async Task<ChartAlbumow?> FirstOrDefaultAsync(int? id)
        {
            return await _context.chartAlbumowDb.FirstOrDefaultAsync(m => m.ChartAlbumowID == id);
        }

        public async Task<ChartAlbumow?> FindAsync(int? id)
        {
            return await _context.chartAlbumowDb.FindAsync(id);
        }

        public bool Any(int id)
        {
            return _context.chartAlbumowDb.Any(e => e.ChartAlbumowID == id);
        }
    }
}

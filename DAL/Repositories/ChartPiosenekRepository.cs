using DAL.Interfaces;
using ListaPrzebojow.DAL;

namespace DAL.Repositories
{
    public class ChartPiosenekRepository : IChartPiosenekRepository
    {
        private readonly ListaPrzebojowContext _context;

        public ChartPiosenekRepository(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public void Add(ChartPiosenek chart)
        {
            _context.chartPiosenekDb.Add(chart);
        }

        public IEnumerable<ChartPiosenek> GetAll()
        {
            return _context.chartPiosenekDb.ToList();

        }

        public ChartPiosenek GetById(int id)
        {
            return _context.chartPiosenekDb.FirstOrDefault(a => a.ChartPiosenekID == id);
        }

        public void Remove(ChartPiosenek chart)
        {
            _context.chartPiosenekDb.Remove(chart);
        }
    }
}

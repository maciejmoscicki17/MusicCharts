using DAL;

namespace DAL.Interfaces
{
    public interface IChartPiosenekRepository
    {
        void Add(ChartPiosenek chartPiosenek);
        void Remove(ChartPiosenek chartPiosenek);
        ChartPiosenek GetById(int id);
        IEnumerable<ChartPiosenek> GetAll();
        //Task<IEnumerable<ChartPiosenek>> GetAllAsync();
        //void Update(ChartPiosenek chartPiosenek);
        //Task<ChartPiosenek?> FirstOrDefaultAsync(int? id);
        //Task<ChartPiosenek?> FindAsync(int? id);
        //bool Any(int id);
    }
}

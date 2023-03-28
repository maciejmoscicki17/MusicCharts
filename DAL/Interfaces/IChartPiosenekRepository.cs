using DAL;

namespace DAL.Interfaces
{
    public interface IChartPiosenekRepository
    {
        void Add(ChartPiosenek chartPiosenek);
        void Remove(ChartPiosenek chartPiosenek);
        ChartPiosenek GetById(int id);
        IEnumerable<ChartPiosenek> GetAll();
    }
}

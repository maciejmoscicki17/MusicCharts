using DAL;

namespace DAL.Interfaces
{
    public interface IChartAlbumowRepository
    {
        void Add(ChartAlbumow chartAlbumow);
        void Remove(ChartAlbumow chartAlbumow);
        ChartAlbumow GetById(int id);
        IEnumerable<ChartAlbumow> GetAll();
    }
}

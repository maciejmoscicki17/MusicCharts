using DAL;

namespace DAL.Interfaces
{
    public interface IChartAlbumowRepository
    {
        void Add(ChartAlbumow chartAlbumow);
        void Remove(ChartAlbumow chartAlbumow);
        ChartAlbumow GetById(int id);
        IEnumerable<ChartAlbumow> GetAll();
        Task<IEnumerable<ChartAlbumow>> GetAllAsync();
        void Update(ChartAlbumow chartAlbumow);
        Task<ChartAlbumow?> FirstOrDefaultAsync(int? id);
        Task<ChartAlbumow?> FindAsync(int? id);
        bool Any(int id);
    }
}

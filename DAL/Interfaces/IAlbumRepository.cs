using DAL;

namespace DAL.Interfaces
{
    public interface IAlbumRepository
    {
        void Add(Album album);
        void Remove(Album album);
        Album? GetById(int id);
        IEnumerable<Album> GetAll();
        Task<IEnumerable<Album>> GetAllAsync();
        void Update(Album album);
        Task<Album?> FirstOrDefaultAsync(int? id);
        Task<Album?> FindAsync(int? id);
        bool Any(int id);

    }
}

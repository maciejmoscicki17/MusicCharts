using DAL;

namespace DAL.Interfaces
{
    public interface IPlaylistaRepository
    {
        void Add(Playlista playlista);
        void Remove(Playlista playlista);
        Playlista GetById(int id);
        IEnumerable<Playlista> GetAll();
        Task<IEnumerable<Playlista>> GetAllAsync();
        void Update(Playlista playlista);
        Task<Playlista?> FirstOrDefaultAsync(int? id);
        Task<Playlista?> FindAsync(int? id);
        bool Any(int id);
    }
}

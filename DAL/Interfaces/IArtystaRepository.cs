using DAL;

namespace DAL.Interfaces
{
    public interface IArtystaRepository
    {
        void Add(Artysta artysta);
        void Remove(Artysta artysta);
        Artysta GetById(int id);
        IEnumerable<Artysta> GetAll();
        Task<IEnumerable<Artysta>> GetAllAsync();
        void Update(Artysta artysta);
        Task<Artysta?> FirstOrDefaultAsync(int? id);
        Task<Artysta?> FindAsync(int? id);
        bool Any(int id);
    }
}

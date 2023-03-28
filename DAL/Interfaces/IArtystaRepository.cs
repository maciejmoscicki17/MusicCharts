using DAL;

namespace DAL.Interfaces
{
    public interface IArtystaRepository
    {
        void Add(Artysta artysta);
        void Remove(Artysta artysta);
        Artysta GetById(int id);
        IEnumerable<Artysta> GetAll();
    }
}

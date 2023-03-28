using DAL;

namespace DAL.Interfaces
{
    public interface IPlaylistaRepository
    {
        void Add(Playlista playlista);
        void Remove(Playlista playlista);
        Playlista GetById(int id);
        IEnumerable<Playlista> GetAll();
    }
}

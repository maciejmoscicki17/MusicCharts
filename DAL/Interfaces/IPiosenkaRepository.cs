using DAL;

namespace DAL.Interfaces
{
    public interface IPiosenkaRepository
    {
        void Add(Piosenka piosenka);
        void Remove(Piosenka piosenka);
        Piosenka? GetById(int id);
        IEnumerable<Piosenka> GetAll();
        Task<IEnumerable<Piosenka>> GetAllAsync();
        void Update(Piosenka piosenka);
        Task<Piosenka?> FirstOrDefaultAsync(int? id);
        Task<Piosenka?> FindAsync(int? id);
        bool Any(int id);
    }
}

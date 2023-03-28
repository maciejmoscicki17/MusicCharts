using DAL;

namespace DAL.Interfaces
{
    public interface IPiosenkaRepository
    {
        void Add(Piosenka piosenka);
        void Remove(Piosenka piosenka);
        Piosenka GetById(int id);
        IEnumerable<Piosenka> GetAll();
    }
}

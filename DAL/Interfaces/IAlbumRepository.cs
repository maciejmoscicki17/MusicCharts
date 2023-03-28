using DAL;

namespace DAL.Interfaces
{
    public interface IAlbumRepository
    {
        void Add(Album album);
        void Remove(Album album);
        Album GetById(int id);
        IEnumerable<Album> GetAll();
    }
}

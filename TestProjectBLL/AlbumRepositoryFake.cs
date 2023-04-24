using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectBLL
{
    internal class AlbumRepositoryFake : IAlbumRepository
    {
        public void Add(Album album)
        {
            throw new NotImplementedException();
        }

        public bool Any(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Album?> FindAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Album?> FirstOrDefaultAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAll()
        {
            return new List<Album>();
        }

        public Task<IEnumerable<Album>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Album? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Album album)
        {
            throw new NotImplementedException();
        }

        public void Update(Album album)
        {
            throw new NotImplementedException();
        }
    }
}

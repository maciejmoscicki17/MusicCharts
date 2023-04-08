using BusinessLogicLayer.Interfaces;
using DAL;
using DAL.Interfaces;

namespace BusinessLogicLayer
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unit) 
        {
            unitOfWork = unit;
        }
        public async Task<IEnumerable<Piosenka>> GetSongsByArtistId(int artistId)
        {
            var artist = await unitOfWork.Artyści.FindAsync(artistId);
            var artystaAlbum = unitOfWork.artystaAlbum.GetAll().Where(a => a.ArtystaID == artistId);
            if (!artystaAlbum.Any()) return null;
            List<Album> albums = new List<Album>();
            foreach(var aa in artystaAlbum) 
            {
                albums.Add(unitOfWork.Albums.GetById(aa.AlbumID));
            }
            List<Piosenka> songs = albums
                .Where(album => album.piosenkaCol is not null)
                .SelectMany(album => album.piosenkaCol)
                .ToList();
            
            //foreach(var album in albums)
            //{
            //    if(album.piosenkaCol is not null)
            //    {
            //        foreach(var piosenka in album.piosenkaCol)
            //        {
            //            songs.Add(piosenka);
            //        }

            //    }
            //}
            return songs;

        }
    }
}
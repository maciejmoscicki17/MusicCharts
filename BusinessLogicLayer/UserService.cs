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

            //if (!artystaAlbum.Any()) return null;

            List<Album> albums = new List<Album>();
            foreach(var aa in artystaAlbum) 
            {
                albums.Add(unitOfWork.Albums.GetById(aa.AlbumID));
            }
            //List<Piosenka> songs = albums
            //    .Where(album => album.piosenkaCol is not null)
            //    .SelectMany(album => album.piosenkaCol)
            //    .ToList();

            var allSongs = unitOfWork.Piosenki.GetAll();
            List<Piosenka> songs = new List<Piosenka>();
            foreach(var album in albums)
            {
                allSongs
                    .Where(a => a.AlbumID == album.AlbumID)
                    .ToList()
                    .ForEach(s => songs.Add(s));
            }
            
            if(songs.Count() == 0)
            {
                var piosenkaArtysta = unitOfWork.piosenkaArtysta.GetAll().Where(pa => pa.ArtystaID == artistId);
                
                foreach(var pa in piosenkaArtysta)
                {
                    allSongs.Where(s => s.PiosenkaID == pa.PiosenkaID).ToList().ForEach(p => songs.Add(p));
                }
            }

            return songs;

        }

        public async Task<IEnumerable<Piosenka>> GetSongsByPlaylistId(int playlistId)
        {
            List<Piosenka> songs = new List<Piosenka>();
            var playlistaPiosenka = unitOfWork.playlistaPiosenka.GetAllByPlaylistaId(playlistId);
            var allSongs = unitOfWork.Piosenki.GetAll();
            foreach( var pp in playlistaPiosenka)
            {
                songs.Add(allSongs.First(x => x.PiosenkaID == pp.PiosenkaID));
            }
            return songs;
        }

        public async Task<IEnumerable<Playlista>> GetAllPlaylist()
        {
            return unitOfWork.Playlisty.GetAll();
        }

        public IEnumerable<ChartPiosenek> GetAllChartPiosenek()
        {
            var ChartyPiosenek = unitOfWork.ChartyPiosenek.GetAll();
            return ChartyPiosenek;
        }

        public IEnumerable<Piosenka> GetSongsByChartId(int chartId)
        {
            List<Piosenka> songs = new List<Piosenka>();
            var piosenkaNaCharcie = unitOfWork.piosenkaNaCharcie.GetPiosenkiByChartId(chartId);
            var allSongs = unitOfWork.Piosenki.GetAll();
            foreach (var pp in piosenkaNaCharcie)
            {
                songs.Add(allSongs.First(x => x.PiosenkaID == pp.PiosenkaID));
            }
            return songs;
        }

        public IEnumerable<ChartAlbumow> GetAllChartAlbumow()
        {
            var chartyAlbumow = unitOfWork.ChartyAlbumow.GetAll();
            return chartyAlbumow;
        }

        public IEnumerable<Album> GetAlbumsByChartId(int chartId)
        {
            List<Album> albums = new List<Album>();
            var albumyNaCharcie = unitOfWork.albumNaCharcie.GetByAlbumId(chartId);
            var allAlbums = unitOfWork.Albums.GetAll();
            foreach(var album in albumyNaCharcie)
            {
                albums.Add(allAlbums.First(a => a.AlbumID == album.AlbumID));
            }
            return albums;
        }
    }
}
namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IAlbumRepository Albums { get; }
        IPiosenkaRepository Piosenki { get; }
        IArtystaRepository Artyści { get; }
        IPlaylistaRepository Playlisty { get; }
        IChartPiosenekRepository ChartyPiosenek { get; }
        IChartAlbumowRepository ChartyAlbumow { get; }
        IArtystaAlbumRepository artystaAlbum { get; }
        IPiosenkaArtystaRepository piosenkaArtysta { get; }
        IPlaylistaPiosenkaRepository playlistaPiosenka { get; }
        IPiosenkaNaCharcieRepository piosenkaNaCharcie { get; } 
        IAlbumNaCharcieRepository albumNaCharcie { get; }



        void Save();
        Task<int> SaveAsync();
        void Dispose();
    }
}

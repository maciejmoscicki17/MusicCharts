using ListaPrzebojow.DAL;

namespace WebListaPrzebojow.Utils
{
    public static class GlobalFunctions
    {
        private static ListaPrzebojowContext _context;

        public static void Init(ListaPrzebojowContext context)
        {
            _context = context;
        }

        public static string GetAlbumNameById(int albumID)
        {
            return _context.albumDb.FirstOrDefault(a => a.AlbumID == albumID).Nazwa;
        }
        public static string GetSongNameById(int songID)
        {
            return _context.piosenkaDb.FirstOrDefault(a => a.PiosenkaID == songID).Nazwa;
        }
    }

}

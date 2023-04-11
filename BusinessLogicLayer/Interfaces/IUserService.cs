using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<Piosenka>> GetSongsByArtistId(int artistId);
        Task<IEnumerable<Piosenka>> GetSongsByPlaylistId(int playlistId);
        Task<IEnumerable<Playlista>> GetAllPlaylist();
    }
}

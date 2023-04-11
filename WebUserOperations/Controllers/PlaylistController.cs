using BusinessLogicLayer.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{
    public class PlaylistController : Controller
    {
        private readonly IUserService userService;

        public PlaylistController(IUserService userService)
        {
            this.userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var playlists = await userService.GetAllPlaylist();
            return View(playlists);
        }
        public async Task<IActionResult> SongsAsync(int playlistaId)
        {
            var songs = await userService.GetSongsByPlaylistId(playlistaId);

            return View(songs);
        }
    }
}

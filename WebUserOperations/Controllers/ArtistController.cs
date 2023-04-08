using BusinessLogicLayer.Interfaces;
using DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IUserService userService;
        private readonly IUnitOfWork unitOfWork;

        public ArtistController(IUserService userService, IUnitOfWork unit)
        {
            this.userService = userService;
            this.unitOfWork = unit;
        }
        public IActionResult Index()
        {
            var artists = unitOfWork.Artyści.GetAll();

            return View(artists);
        }
        public async Task<IActionResult> SongsAsync(int artistId)
        {
            var songs = await userService.GetSongsByArtistId(artistId);

            return View(songs);
        }
    }
}

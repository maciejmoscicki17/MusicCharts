using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{
    public class ChartAlbumówController : Controller
    {
        private readonly IUserService userService;

        public ChartAlbumówController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            var chartyAlbumow = userService.GetAllChartAlbumow();
            return View(chartyAlbumow);
        }
        public IActionResult Albums(int chartAlbumowId)
        {
            var albums = userService.GetAlbumsByChartId(chartAlbumowId);
            return View(albums);
        }
    }
}

using BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{
    public class ChartPiosenekController : Controller
    {
        private readonly IUserService userService;

        public ChartPiosenekController(IUserService userService)
        {
            this.userService = userService;
        }
        public IActionResult Index()
        {
            var chartyPiosenek = userService.GetAllChartPiosenek();
            return View(chartyPiosenek);
        }
        public async Task<IActionResult> Songs(int chartPiosenekId)
        {
            var songs = userService.GetSongsByChartId(chartPiosenekId);
            return View(songs);
        }
    }
}

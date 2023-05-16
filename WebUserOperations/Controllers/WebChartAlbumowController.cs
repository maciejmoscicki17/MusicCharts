using BusinessLogicLayer.Interfaces;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class WebChartAlbumowController : ControllerBase
    {
        private readonly IUserService userService;

        public WebChartAlbumowController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("allAlbumCharts")]

        public IEnumerable<ChartAlbumow> allAlbumCharts()
        {
            return userService.GetAllChartAlbumow();
        }

    }
}

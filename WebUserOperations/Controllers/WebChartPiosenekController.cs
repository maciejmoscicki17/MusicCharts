using BusinessLogicLayer.Interfaces;
using DAL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUserOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebChartPiosenekController : ControllerBase
    {
        private readonly IUserService userService;

        public WebChartPiosenekController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("allSongsCharts")]
        public IEnumerable<ChartPiosenek> allSongsCharts()
        {
            return this.userService.GetAllChartPiosenek();
        }
    }
}

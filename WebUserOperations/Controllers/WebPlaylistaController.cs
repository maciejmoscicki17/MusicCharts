using BusinessLogicLayer.Interfaces;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebPlaylistaController : ControllerBase
    {
        private readonly IUserService userService;

        public WebPlaylistaController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("allPlaylists")]
        public Task<IEnumerable<Playlista>> allPlaylists()
        {
            return this.userService.GetAllPlaylist();
        }
    }
}

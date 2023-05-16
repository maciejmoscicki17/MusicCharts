using BusinessLogicLayer.Interfaces;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebUserOperations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebArtistController : ControllerBase
    {
        private readonly IUserService userService;

        public WebArtistController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("{id:int}")]
        public Task<IEnumerable<Piosenka>> allSongsByArtistId(int id)
        {
            var piosenki = new List<Piosenka>();
            //piosenki = this.userService.GetSongsByArtistId(id);
            return this.userService.GetSongsByArtistId(id);
        }
    }
}

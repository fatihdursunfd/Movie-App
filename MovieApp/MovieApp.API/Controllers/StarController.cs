using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Service.Interfaces;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarController : ControllerBase
    {

        private readonly IStarService starService;

        public StarController(IStarService starService)
        {
            this.starService = starService;
        }

        [HttpGet("GetStarsByMovieId")]
        public async Task<IActionResult> GetStarsByMovieId(int movieId)
        {
            var stars = await starService.GetStarsByMovieId(movieId);
            return Ok(stars);
        }
    }
}

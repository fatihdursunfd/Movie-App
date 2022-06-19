using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieApp.Service.Interfaces;
using Newtonsoft.Json;
using System.Text.Json;

namespace MovieApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet("GetMoviesByCategory")]
        public async Task<IActionResult> GetMoviesByCategory(string categoryName)
        {
            var movies = await movieService.GetMoviesByCategory(categoryName);
            return Ok(movies);
        }


        [HttpGet("GetAllMovies")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await movieService.GetMoviesWithFeatures();
            return Ok(movies);
        }
    }
}

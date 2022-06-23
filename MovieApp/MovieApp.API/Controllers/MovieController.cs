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


        [HttpGet("GetMovieById")]
        public async Task<IActionResult> GetMovieById(int movieId)
        {
            var movie = await movieService.GetMovieById(movieId);
            return Ok(movie);
        }


        [HttpGet("GetMoviesByName")]
        public async Task<IActionResult> GetMoviesByName(string name)
        {
            var movies = await movieService.GetMoviesByName(name);
            return Ok(movies);
        }

        [HttpGet("GetTrendingMovies")]
        public async Task<IActionResult> GetTrendingMovies()
        {
            var movies = await movieService.GetTrendingMovies();
            return Ok(movies);
        }
    }
}

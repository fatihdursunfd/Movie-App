using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Interfaces;
using MovieApp.EntityLayer.Entities;
using MovieApp.Service.Dtos;
using MovieApp.Service.Interfaces;
using MovieApp.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class StarService : IStarService
    {
        private readonly IGenericRepo<Movie> movieRepo;
        private readonly IGenericRepo<Star> starRepo;

        public StarService(IGenericRepo<Star> starRepo, IGenericRepo<Movie> movieRepo)
        {
            this.starRepo = starRepo;
            this.movieRepo = movieRepo;
        }

        public async Task<Response<IEnumerable<StarDto>>> GetStarsByMovieId(int movieId)
        {
            var movie = await movieRepo.Where(x => x.MovieID == movieId)
                                  .Include(x => x.Stars)
                                  .FirstOrDefaultAsync();

            if (movie is null)
                return new Response<IEnumerable<StarDto>>() { Data = null, Error = "Movie not found", StatusCode = 404 };

            var stars = movie.Stars.Select(x => new StarDto()
            {
                Name = x.Name,
                ImageUrl = x.ImageUrl
            }).ToList();

            if(stars is null)
                return new Response<IEnumerable<StarDto>>() { Data = null, Error = "Stars not found", StatusCode = 404 };

            return new Response<IEnumerable<StarDto>>() { Data = stars , Error = null , StatusCode = 200};
        }
    }
}

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
    public class MovieService : IMovieService
    {
        private readonly IGenericRepo<Movie> movieRepo;
        private readonly IGenericRepo<Category> categoryRepo;

        public MovieService(IGenericRepo<Movie> movieRepo, IGenericRepo<Category> categoryRepo)
        {
            this.movieRepo = movieRepo;
            this.categoryRepo = categoryRepo;
        }

        public async Task<Response<IEnumerable<Movie>>> GetAllMovies(int page)
        {
            var movies = await movieRepo.Where(x => x.MovieID > 0)
                                        .Skip((page - 1) * 20)
                                        .Take(20)
                                        .ToListAsync();
            
            if (movies == null)
                return new Response<IEnumerable<Movie>>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            return new Response<IEnumerable<Movie>>() { Data = movies, Error = null, StatusCode = 200 };

        }

        public async Task<Response<MovieDto>> GetMovieById(int movieId)
        {
            var movie = await movieRepo.GetByIdAsync(movieId);
            if(movie == null)
                return new Response<MovieDto>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            var movieDto = new MovieDto()
            {
                Name = movie.Name,
                Date = movie.Date,
                Image_sm = movie.ImageSmUrl,
                Image_lg = movie.ImageLgUrl,
                //Rating = movie.Rating,
                Description = movie.Description,
            };

            return new Response<MovieDto>() { Data = movieDto, Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<Movie>>> GetMoviesByCategory(string categoryName)
        {
            var category = await categoryRepo.Where(x => x.Name.ToLower().Contains(categoryName))
                                       .Select(x => new
                                       {
                                           x.CategoryID,
                                           x.Name,
                                           Movies = x.Movies.Select(e => new Movie()
                                           {
                                               MovieID =  e.MovieID,
                                               Rating = e.Rating,
                                               Name = e.Name,
                                               Date = e.Date,
                                               Description = e.Description,
                                               Director = e.Director,
                                               ImageLgUrl = e.ImageLgUrl,
                                               ImageSmUrl = e.ImageSmUrl
                                           }).ToList()
                                       }).ToListAsync();

            if (category == null)
                return new Response<IEnumerable<Movie>>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            return new Response<IEnumerable<Movie>>() { Data = category[0].Movies , Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<MovieDto>>> GetMoviesByName(string title)
        {
            var movies = await movieRepo.Where(x => x.Name.ToLower()
                                                             .Contains(title.ToLower()))
                                                             .ToListAsync();

            if (movies == null)
                return new Response<IEnumerable<MovieDto>>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            var moviesDto = movies.Select(x => new MovieDto()
            {
                Name = x.Name,
                Rating = x.Rating,
                Date = x.Date,
                Image_lg = x.ImageLgUrl,
                Image_sm = x.ImageSmUrl,
                Description = x.Description,
            }).ToList();

            return new Response<IEnumerable<MovieDto>>() { Data = moviesDto, Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<MovieDto>>> GetMoviesWithFeatures()
        {
            var movies = await movieRepo.Where(x => x.MovieID > 0)
                                  .Include(x => x.Stars)
                                  .Include(x => x.Categories)
                                  .Include(x => x.Director)
                                  .ToListAsync();

            var moviesDto = movies.Select(x => new MovieDto()
            {
                Name = x.Name,
                Rating = x.Rating,
                Date = x.Date,
                Image_lg = x.ImageLgUrl,
                Image_sm = x.ImageSmUrl,
                Description = x.Description,
                Director = x.Director,
                Stars = x.Stars.Select(y => y.Name).ToList(),
                Categories = x.Categories.Select(y => y.Name).ToList(),
            }).ToList();

            return new Response<IEnumerable<MovieDto>>() { Data = moviesDto, Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<MovieDto>>> GetTrendingMovies()
        {
            var movies = await movieRepo.Where(x => x.MovieID > 0)
                                        .OrderByDescending(x => x.Rating)
                                        .Take(20)
                                        .ToListAsync();

            var moviesDto = movies.Select(x => new MovieDto()
            {
                Id = x.MovieID,
                Name = x.Name,
                Rating = x.Rating,
                Date = x.Date,
                Image_lg = x.ImageLgUrl,
                Image_sm = x.ImageSmUrl,
                Description = x.Description,
            }).ToList();

            return new Response<IEnumerable<MovieDto>>() { Data = moviesDto, Error = null, StatusCode = 200 };

        }
    
    }
}

using AutoMapper;
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
        private readonly IGenericRepo<Director> directorRepo;
        private readonly IMapper mapper;

        public MovieService(IGenericRepo<Movie> movieRepo,
                            IGenericRepo<Category> categoryRepo,
                            IGenericRepo<Director> directorRepo,
                            IMapper mapper)
        {
            this.movieRepo = movieRepo;
            this.categoryRepo = categoryRepo;
            this.mapper = mapper;
            this.directorRepo = directorRepo;
        }

        public async Task<Response<IEnumerable<Movie>>> GetAllMovies(int page)
        {

            var movies = await movieRepo.Where(x => x.MovieID > 0)
                                        .OrderByDescending(x => x.Rating)      
                                        .Skip((page - 1) * 20)
                                        .Take(20)
                                        .ToListAsync();
            
            if (movies == null)
                return new Response<IEnumerable<Movie>>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            var totalPageCount = movieRepo.Where(x => x.MovieID > 0).ToList().Count / 20 + 1;
            return new Response<IEnumerable<Movie>>() { Data = movies, Error = null, StatusCode = 200 , TotalPageCount = totalPageCount };

        }

        public async Task<Response<MovieDto>> GetMovieById(int movieId)
        {
            var movie = await movieRepo.GetByIdAsync(movieId);
            if(movie == null)
                return new Response<MovieDto>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            var movieDto = mapper.Map<MovieDto>(movie);
            movieDto.Director = await directorRepo.GetByIdAsync(movieDto.DirectorID);
            

            return new Response<MovieDto>() { Data = movieDto, Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<MovieDto>>> GetMoviesByCategory(string categoryName , int page)
        {
            var category = await categoryRepo.Where(x => x.Name.ToLower().Contains(categoryName))
                                             .Select(x => new
                                             {
                                                x.CategoryID,
                                                x.Name,
                                                Movies = x.Movies.Select(e => new MovieDto()
                                                {
                                                    MovieID =  e.MovieID,
                                                    Rating = e.Rating,
                                                    Name = e.Name,
                                                    Date = e.Date,
                                                    Minute = e.Minute,
                                                    Description = e.Description,
                                                    Director = e.Director,
                                                    ImageLgUrl = e.ImageLgUrl,
                                                    ImageSmUrl = e.ImageSmUrl
                                                }).ToList()
                                             })
                                             .ToListAsync();

            if (category == null)
                return new Response<IEnumerable<MovieDto>>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            var movies = category[0].Movies.OrderByDescending(x => x.Rating)
                                                 .Skip((page - 1 ) * 20)
                                                 .Take(20)
                                                 .ToList();

            var totalPageCount = category[0].Movies.Count / 20 + 1;

            return new Response<IEnumerable<MovieDto>>() { Data = movies, Error = null, StatusCode = 200 , TotalPageCount = totalPageCount };

        }

        public async Task<Response<IEnumerable<MovieDto>>> GetMoviesByName(string title)
        {
            var movies = await movieRepo.Where(x => x.Name.ToLower()
                                                             .Contains(title.ToLower()))
                                                             .ToListAsync();

            if (movies == null)
                return new Response<IEnumerable<MovieDto>>() { Data = null, Error = "Movies not found", StatusCode = 404 };

            var moviesDto = mapper.Map<IEnumerable<MovieDto>>(movies);

            return new Response<IEnumerable<MovieDto>>() { Data = moviesDto, Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<Movie>>> GetMoviesWithFeatures()
        {
            var movies = await movieRepo.Where(x => x.MovieID > 0)
                                  .Include(x => x.Stars)
                                  .Include(x => x.Categories)
                                  .Include(x => x.Director)
                                  .ToListAsync();

            var moviesDto = movies.Select(x => new Movie()
            {
                MovieID = x.MovieID,
                Name = x.Name,
                Rating = x.Rating,
                Date = x.Date,
                ImageLgUrl = x.ImageLgUrl,
                ImageSmUrl = x.ImageSmUrl,
                Description = x.Description,
                Director = x.Director,
                Stars = x.Stars.Select(y => new Star() { StarID = y.StarID, Name = y.Name , ImageUrl = y.ImageUrl}).ToList(),
                Categories = x.Categories.Select(y => new Category() { Name = y.Name , CategoryID = y.CategoryID}).ToList(),
            }).ToList();

            return new Response<IEnumerable<Movie>>() { Data = moviesDto, Error = null, StatusCode = 200 };

        }

        public async Task<Response<IEnumerable<MovieDto>>> GetTrendingMovies()
        {
            var movies = await movieRepo.Where(x => x.MovieID > 0)
                                        .OrderByDescending(x => x.Rating)
                                        .Take(20)
                                        .ToListAsync();

            var moviesDto = mapper.Map<IEnumerable<MovieDto>>(movies);
            return new Response<IEnumerable<MovieDto>>() { Data = moviesDto, Error = null, StatusCode = 200 };
        }
    
    }
}

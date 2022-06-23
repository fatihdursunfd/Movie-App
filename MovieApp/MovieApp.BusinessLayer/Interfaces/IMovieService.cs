﻿using MovieApp.EntityLayer.Entities;
using MovieApp.Service.Dtos;
using MovieApp.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Interfaces
{
    public interface IMovieService
    {
        Task<Response<IEnumerable<Movie>>> GetAllMovies();

        Task<Response<IEnumerable<Movie>>> GetMoviesByCategory(string categoryName);

        Task<Response<IEnumerable<MovieDto>>> GetMoviesWithFeatures();

        Task<Response<IEnumerable<MovieDto>>> GetTrendingMovies();

        Task<Response<IEnumerable<MovieDto>>> GetMoviesByName(string title);

        Task<Response<MovieDto>> GetMovieById(int movieId);
    }
}

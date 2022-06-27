using MovieApp.Data.Interfaces;
using MovieApp.EntityLayer.Entities;
using MovieApp.Service.Dtos;
using MovieApp.Service.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class DataService : IDataService
    {
        private readonly IGenericRepo<Category> categoryRepo;
        private readonly IGenericRepo<Star> starRepo;
        private readonly IGenericRepo<Director> directorRepo;
        private readonly IGenericRepo<Writer> writerRepo;
        private readonly IGenericRepo<Movie> movieRepo;
        private readonly IUnitOfWork unitOfWork;

        public DataService(IGenericRepo<Movie> movieRepo,
                           IGenericRepo<Writer> writerRepo,
                           IGenericRepo<Director> directorRepo,
                           IGenericRepo<Star> starRepo,
                           IGenericRepo<Category> categoryRepo, 
                           IUnitOfWork unitOfWork)
        {
            this.movieRepo = movieRepo;
            this.writerRepo = writerRepo;
            this.directorRepo = directorRepo;
            this.starRepo = starRepo;
            this.categoryRepo = categoryRepo;
            this.unitOfWork = unitOfWork;
        }

        public List<JsonDto> ReadDataFromJson()
        {
            List<JsonDto> movies = new List<JsonDto>();

            using (StreamReader r = new StreamReader(@"./Data/moviesnew.json"))
            {
                string json = r.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<JsonDto>>(json);
            }
            return movies;
        }

        public async Task SaveDataToDb()
        {
            var movies = ReadDataFromJson();

            foreach (var m in movies)
            {
                var mv = movieRepo.Where(x => x.Name == m.Title).FirstOrDefault();

                if (mv is not null)
                    continue;

                Director director = new Director();
                Movie movie = new Movie();

                List<Star> stars = new List<Star>();
                List<Star> starsA = new List<Star>();
                List<Category> categories = new List<Category>();
                List<Category> categoriesA = new List<Category>();

                Star star;
                Category category;

                foreach (var s in m.Stars)
                {
                    var st = starRepo.Where(x => x.Name == s.Name).FirstOrDefault();
                    if (st is null)
                    {
                        star = new Star();
                        star.Name = s.Name;
                        star.ImageUrl = s.ImageUrl;
                        stars.Add(star);
                        starsA.Add(star);
                    }
                    else
                        starsA.Add(st);
                }

                await starRepo.AddRangeAsync(stars);
                unitOfWork.Commit();



                foreach (var w in m.Genres)
                {
                    var c = categoryRepo.Where(x => x.Name == w).FirstOrDefault();
                    if (c is null)
                    {
                        category = new Category();
                        category.Name = w;
                        categories.Add(category);
                        categoriesA.Add(category);
                    }
                    else
                        categoriesA.Add(c);

                }

                await categoryRepo.AddRangeAsync(categories);
                unitOfWork.Commit();

                var dr = directorRepo.Where(x => x.Fullname == m.Director).FirstOrDefault();

                if (dr is null)
                    director.Fullname = m.Director;
                else
                    director = dr;

                movie.Name = m.Title;
                movie.Date = m.ReleaseDate;
                movie.ImageSmUrl = m.ImageSm;
                movie.Rating = Convert.ToDouble(m.Rating);
                movie.Description = m.Description;
                movie.ImageLgUrl = m.ImageLg;
                movie.Minute = m.Minute;
                movie.Director = director;
                movie.Stars = starsA;
                movie.Categories = categoriesA;

                await movieRepo.AddAsync(movie);
                unitOfWork.Commit();

            }
        }
    }
}

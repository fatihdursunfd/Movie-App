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

        public List<MovieDto> ReadDataFromJson()
        {
            List<MovieDto> movies = new List<MovieDto>();

            using (StreamReader r = new StreamReader("../Data/data.json"))
            {
                string json = r.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<MovieDto>>(json);
            }
            return movies;
        }

        public async Task SaveDataToDb()
        {
            var movies = ReadDataFromJson();

            foreach (var m in movies)
            {
                Director director = new Director();
                Movie movie = new Movie();

                List<Star> stars = new List<Star>();
                List<Star> starsA = new List<Star>();
                List<Writer> writers = new List<Writer>();
                List<Writer> writersA = new List<Writer>();
                List<Category> categories = new List<Category>();
                List<Category> categoriesA = new List<Category>();

                Star star;
                Writer writer;
                Category category;

                foreach (var s in m.Stars)
                {
                    var st = starRepo.Where(x => x.Name == s).FirstOrDefault();
                    if (st is null)
                    {
                        star = new Star();
                        star.Name = s;
                        stars.Add(star);
                        starsA.Add(star);
                    }
                    else
                        starsA.Add(st);
                }

                await starRepo.AddRangeAsync(stars);
                unitOfWork.Commit();

                foreach (var w in m.Writers)
                {
                    var wr = writerRepo.Where(x => x.Name == w).FirstOrDefault();
                    if (wr is null)
                    {
                        writer = new Writer();
                        writer.Name = w;
                        writers.Add(writer);
                        writersA.Add(writer);
                    }
                    else
                        writersA.Add(wr);
                }

                await writerRepo.AddRangeAsync(writers);
                unitOfWork.Commit();

                foreach (var w in m.Categories)
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

                var dr = directorRepo.Where(x => x.Fullname == m.Director.Fullname).FirstOrDefault();

                if (dr is null)
                {
                    director.BirthdayMonth = m.Director.BirthdayMonth;
                    director.BirthdayPlace = m.Director.BirthdayPlace;
                    director.BirthdayYear = m.Director.BirthdayYear;
                    director.Fullname = m.Director.Fullname;
                    director.ImageUrl = m.Director.ImageUrl;
                    director.Biography = m.Director.Biography;
                }
                else
                    director = dr;

                movie.Name = m.Name;
                movie.Date = m.Date;
                movie.ImageSmUrl = m.Image_sm;
                movie.Rating = m.Rating;
                movie.Description = m.Description;
                movie.ImageLgUrl = m.Image_lg;

                movie.Director = director;
                movie.Stars = starsA;
                movie.Writers = writersA;
                movie.Categories = categoriesA;

                await movieRepo.AddAsync(movie);
                unitOfWork.Commit();
            }
        }
    }
}

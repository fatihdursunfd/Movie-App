using Microsoft.AspNetCore.Mvc;
using MovieApp.API.InitialData;
using MovieApp.DataAccessLayer.Contexts;
using MovieApp.EntityLayer.Entities;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly MovieContext _context;

        ReadData readData = new ReadData();

        public DataController(MovieContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetData()
        {
            var movies = readData.Read();

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
                    var st = _context.Stars.Where(x => x.Name == s).FirstOrDefault();
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

                _context.Stars.AddRange(stars);
                _context.SaveChanges();

                foreach (var w in m.Writers)
                {
                    var wr = _context.Writers.Where(x => x.Name == w).FirstOrDefault();
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

                _context.Writers.AddRange(writers);
                _context.SaveChanges();

                foreach (var w in m.Categories)
                {
                    var c = _context.Categories.Where(x => x.Name == w).FirstOrDefault();
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

                _context.Categories.AddRange(categories);
                _context.SaveChanges();

                var dr = _context.Directors.Where(x => x.Fullname == m.Director.Fullname).FirstOrDefault();

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

                _context.Movies.Add(movie);
                _context.SaveChanges();

            }
            return Ok();
        }
    }
}
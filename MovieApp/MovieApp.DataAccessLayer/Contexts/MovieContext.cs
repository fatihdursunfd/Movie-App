using Microsoft.EntityFrameworkCore;
using MovieApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.DataAccessLayer.Contexts
{
    public class MovieContext : DbContext
    {
        //public MovieContext(DbContextOptions options) : base(options)
        //{
        //}

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {
            //optionsBuilder.UseSqlServer("server=LAPTOP-421MEBMV; database=MovieDB; integrated security=true;");
        }

        public DbSet<Movie> Movies { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Star> Stars { get; set; }

        public DbSet<Writer> Writers { get; set; }
    }
}

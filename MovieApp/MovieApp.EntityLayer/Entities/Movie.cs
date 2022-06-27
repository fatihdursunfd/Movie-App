using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.EntityLayer.Entities
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public string ImageSmUrl { get; set; }
        public string ImageLgUrl { get; set; }
        public Director Director { get; set; }
        public int DirectorID { get; set; }
        public List<Category> Categories { get; set; }
        public List<Star> Stars { get; set; }

    }
}

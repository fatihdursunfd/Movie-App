using MovieApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Dtos
{
    public class MovieDto
    {
        public int MovieID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }
        public float Rating { get; set; }
        public string ImageSmUrl { get; set; }
        public string ImageLgUrl { get; set; }
        public Director Director { get; set; }
        public int DirectorID { get; set; }

    }
}

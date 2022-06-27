using MovieApp.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Dtos
{
    public class JsonDto
    {
        public string Title { get; set; }
        public string ReleaseDate { get; set; }
        public string Minute { get; set; }
        public string ImageSm { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public List<string> Genres { get; set; }
        public List<Star> Stars { get; set; }
        public string ImageLg { get; set; }
        public string YoutubeLink { get; set; }
    }
}

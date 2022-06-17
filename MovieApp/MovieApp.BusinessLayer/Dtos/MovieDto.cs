using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Dtos
{
    public class MovieDto
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public string Image_sm { get; set; }
        public string Rating { get; set; }
        public string Description { get; set; }
        public DirectorDto Director { get; set; }
        public List<string> Categories { get; set; }
        public List<string> Writers { get; set; }
        public List<string> Stars { get; set; }
        public string Image_lg { get; set; }
    }
}

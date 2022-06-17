using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Dtos
{
    public interface DirectorDto
    {
        public string Fullname { get; set; }
        public string BirthdayMonth { get; set; }
        public string BirthdayYear { get; set; }
        public string BirthdayPlace { get; set; }
        public string ImageUrl { get; set; }
        public string Biography { get; set; }
    }
}

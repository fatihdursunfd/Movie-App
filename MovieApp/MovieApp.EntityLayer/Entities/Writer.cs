using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.EntityLayer.Entities
{
    public class Writer
    {
        public int WriterID { get; set; }
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }

    }
}

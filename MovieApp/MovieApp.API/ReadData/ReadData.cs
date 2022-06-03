using MovieApp.API.InitialData.Dto;
using MovieApp.DataAccessLayer.Contexts;
using MovieApp.EntityLayer.Entities;
using Newtonsoft.Json;

namespace MovieApp.API.InitialData
{
    public class ReadData
    {
        public List<MovieDto> Read() 
        {
            List<MovieDto> movies = new List<MovieDto>();

            using (StreamReader r = new StreamReader("InitialData/data.json"))
            {
                string json = r.ReadToEnd();
                movies = JsonConvert.DeserializeObject<List<MovieDto>>(json);
            }
            return movies;

        }
    }
}

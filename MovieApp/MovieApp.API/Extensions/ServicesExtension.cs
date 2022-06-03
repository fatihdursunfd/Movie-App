using Microsoft.EntityFrameworkCore;
using MovieApp.DataAccessLayer.Contexts;

namespace MovieApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServiceAndRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MovieContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("MovieDbConnString")));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

        }
    }
}

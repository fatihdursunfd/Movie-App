using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Interfaces;
using MovieApp.Data.Repositories;
using MovieApp.DataAccessLayer.Contexts;
using MovieApp.Service.Interfaces;
using MovieApp.Service.Services;

namespace MovieApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServiceAndRepository(this IServiceCollection services, IConfiguration configuration)
        {
            // Db Context
            services.AddDbContext<MovieContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("MovieDbConnString")));

            // Default services
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Repos
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<ICategoryService, CategoryService>();

        }
    }
}

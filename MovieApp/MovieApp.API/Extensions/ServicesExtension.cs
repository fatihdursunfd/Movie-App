using Microsoft.EntityFrameworkCore;
using MovieApp.Data.Interfaces;
using MovieApp.Data.Repositories;
using MovieApp.DataAccessLayer.Contexts;
using MovieApp.Service.Interfaces;
using MovieApp.Service.Services;
using System.Text.Json.Serialization;

namespace MovieApp.API.Extensions
{
    public static class ServicesExtension
    {
        public static void AddServiceAndRepository(this IServiceCollection services, IConfiguration configuration)
        {
            // Db Context

            //services.AddDbContext<MovieContext>(opt =>
            //    opt.UseSqlServer(configuration.GetConnectionString("MovieDbConnString")));

            services.AddDbContext<MovieContext>(options =>
                  options.UseMySql(connectionString:configuration.GetConnectionString("MovieDbMysqlConnString"),
                  new MySqlServerVersion(new Version(10, 4, 17))
           ));

            // Default services
            services.AddControllers();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // AutoMapper
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Repos
            services.AddScoped(typeof(IGenericRepo<>), typeof(GenericRepo<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IStarService, StarService>();

        }
    }
}

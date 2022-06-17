using MovieApp.Data.Interfaces;
using MovieApp.EntityLayer.Entities;
using MovieApp.Service.Dtos;
using MovieApp.Service.Interfaces;
using MovieApp.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepo<Category> categoryRepo;

        public CategoryService(IGenericRepo<Category> categoryRepo)
        {
            this.categoryRepo = categoryRepo;
        }

        public async Task<Response<IEnumerable<CategoryDto>>> GetCategoriesAsync()
        {
            var categories = await categoryRepo.GetAllAsync();
            if (categories == null)
                return new Response<IEnumerable<CategoryDto>>() { Data = null, Error = "There is no category", StatusCode = 400 };
            
            var categoriesDto = categories.Select(x => new CategoryDto() { Name = x.Name }).ToList();
            return new Response<IEnumerable<CategoryDto>>() { Data = categoriesDto, Error = null, StatusCode = 200 };
        }
    }
}

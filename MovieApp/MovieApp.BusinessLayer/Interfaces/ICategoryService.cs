using MovieApp.EntityLayer.Entities;
using MovieApp.Service.Dtos;
using MovieApp.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Interfaces
{
    public interface ICategoryService
    {
        Task<Response<IEnumerable<CategoryDto>>> GetCategoriesAsync();
    }
}

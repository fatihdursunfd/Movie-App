using Microsoft.AspNetCore.Mvc;
using MovieApp.DataAccessLayer.Contexts;
using MovieApp.EntityLayer.Entities;
using MovieApp.Service.Interfaces;

namespace MovieApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DataController : ControllerBase
    {
        private readonly IDataService dataService;

        public DataController(IDataService dataService)
        {
            this.dataService = dataService;
        }

        [HttpPost]
        public IActionResult SaveDataToDb()
        {
            dataService.SaveDataToDb();
            return Ok();
        }
    }}
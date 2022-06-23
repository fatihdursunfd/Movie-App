using MovieApp.Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Service.Interfaces
{
    public interface IDataService
    {
        List<JsonDto> ReadDataFromJson();

        Task SaveDataToDb();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommmitAsync();

        void Commit();
    }
}

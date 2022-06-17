using MovieApp.Data.Interfaces;
using MovieApp.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MovieContext context;

        public UnitOfWork(MovieContext context)
        {
            this.context = context;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public async Task CommmitAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}

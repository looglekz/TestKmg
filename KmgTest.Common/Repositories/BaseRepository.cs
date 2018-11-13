using TestKmg.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestKmg.Common.Repositories
{
    public abstract class BaseRepository : IRepository
    {
        protected readonly ApplicationDbContext _dbContext; 
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected ApplicationDbContext Context;
    }
}

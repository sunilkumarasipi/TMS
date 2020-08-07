using System;
using System.Collections.Generic;
using System.Text;
using TMS.Contracts;
using TMS.Data;
using TMS.Data.Models;

namespace TMS.Repository
{
    public class SchoolRepository : Repository<School>, ISchoolRepository
    {
        private readonly AppDBContext _dbContext;
        public SchoolRepository(AppDBContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

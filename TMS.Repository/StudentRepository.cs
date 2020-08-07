using System;
using System.Collections.Generic;
using System.Text;
using TMS.Contracts;
using TMS.Data;
using TMS.Data.Models;

namespace TMS.Repository
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        private readonly AppDBContext _dbContext;
        public StudentRepository(AppDBContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

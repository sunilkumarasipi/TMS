using System;
using System.Collections.Generic;
using System.Text;
using TMS.Contracts;
using TMS.Data;

namespace TMS.Repository
{
    public class UnitOfWork : IUnitOfWork
    {

        private ISchoolRepository _schoolRepository;
        private IStudentRepository _studentRepository;
        private IUserRepository _userRepository;

        private readonly AppDBContext _dbContext;
        public UnitOfWork(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ISchoolRepository SchoolRepository
        {
            get
            {
                if (_schoolRepository == null)
                {
                    return new SchoolRepository(_dbContext);
                }
                return _schoolRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (_studentRepository == null)
                {
                    return new StudentRepository(_dbContext);
                }
                return _studentRepository;
            }
        }

        public IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                    return new UserRepository(_dbContext);
                }
                return _userRepository;
            }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

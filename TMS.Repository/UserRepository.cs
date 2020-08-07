using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMS.Contracts;
using TMS.Data;
using TMS.Data.Models;

namespace TMS.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDBContext _dbContext;
        public UserRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetUserByUserNamePassword(string userName, string password)
        {
            return _dbContext.User
                   .Where(x => x.UserName == userName && x.Password == password)
                   .FirstOrDefault();
        }
    }
}

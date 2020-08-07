using System;
using System.Collections.Generic;
using System.Text;
using TMS.Data.Models;

namespace TMS.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUserNamePassword(string userName,string password);
    }
}

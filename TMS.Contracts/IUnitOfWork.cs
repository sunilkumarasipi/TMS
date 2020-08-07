using System;
using System.Collections.Generic;
using System.Text;

namespace TMS.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        ISchoolRepository SchoolRepository { get; }
        IStudentRepository StudentRepository { get; }
        IUserRepository UserRepository { get; }
        void Commit();
    }
}

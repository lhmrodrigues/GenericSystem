using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}

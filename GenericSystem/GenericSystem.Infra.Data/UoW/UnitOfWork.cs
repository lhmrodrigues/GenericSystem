using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.UoW
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly GenericSystemsContext _context;

        public UnitOfWork(GenericSystemsContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

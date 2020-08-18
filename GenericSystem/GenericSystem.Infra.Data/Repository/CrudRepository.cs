using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Infra.Data.Context;
using GenericSystem.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSystem.Infra.Data.Repository
{
    internal class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly GenericSystemsContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public CrudRepository(GenericSystemsContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public TEntity Get(Guid id, bool getDependencies = true)
        {
            IQueryable<TEntity> obj = _dbSet.AsNoTracking();

            if (getDependencies)
            {
                obj = obj.Include(_context.GetIncludePaths(typeof(TEntity)));
            }

            return obj.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<TEntity> List(bool getDependencies = false)
        {
            IQueryable<TEntity> obj = _dbSet.AsNoTracking();

            if (getDependencies)
            {
                obj = obj.Include(_context.GetIncludePaths(typeof(TEntity)));
            }

            return obj;
        }

        public void Delete(TEntity obj)
        {
            _dbSet.Remove(obj);
        }

        public void Post(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Put(TEntity obj)
        {
            _dbSet.Update(obj);
        }
    }
}

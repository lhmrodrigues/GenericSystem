using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GenericSystem.Domain.Services
{
    internal class CrudService<TEntity> : ICrudService<TEntity> where TEntity : BaseEntity
    {
        protected readonly ICrudRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        public CrudService(ICrudRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public TEntity Put(TEntity obj, bool getDependencies = false)
        {
            if (obj.Id == Guid.Empty)
            {
                obj.Id = Guid.NewGuid();
            }

            _repository.Put(obj);

            if (!_unitOfWork.Commit())
            {
                return null;
            }

            return Get(obj.Id, getDependencies);
        }
        public IEnumerable<TEntity> List(bool getDependencies = false)
        {
            return _repository.List(getDependencies).ToList();
        }
        public TEntity Get(Guid id, bool getDependencies = true)
        {
            return _repository.Get(id, getDependencies);
        }
        public bool Delete(Guid id)
        {
            TEntity obj = _repository.Get(id);

            _repository.Post(obj);

            return _unitOfWork.Commit();
        }
        public bool Post(TEntity obj)
        {
            _repository.Post(obj);

            return _unitOfWork.Commit();
        }
        public Guid GetGuid()
        {
            return Guid.NewGuid();
        }

    }
}

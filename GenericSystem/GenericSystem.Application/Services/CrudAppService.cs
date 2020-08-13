using AutoMapper;
using GenericSystem.Application.Interfaces;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Services
{
    internal class CrudAppService<TEntity, TViewModel> : ICrudAppService<TViewModel> where TViewModel : BaseViewModel
    {
        protected readonly IMapper _mapper;
        private readonly ICrudService<TEntity> _service;

        public CrudAppService(IMapper mapper, ICrudService<TEntity> service)
        {
            _mapper = mapper;
            _service = service;
        }

        public bool Delete(Guid id)
        {
            return _service.Delete(id);
        }

        public TViewModel Get(Guid id, bool getDependencies = true)
        {
            return _mapper.Map<TViewModel>(_service.Get(id, getDependencies));

        }

        public IEnumerable<TViewModel> List(bool getDependencies = false)
        {
            return _mapper.Map<IEnumerable<TViewModel>>(_service.List(getDependencies));

        }

        public bool Post(TViewModel obj)
        {
            return _service.Post(_mapper.Map<TEntity>(obj));
        }

        public TViewModel Put(TViewModel obj, bool getDependencies = false)
        {
            return _mapper.Map<TViewModel>(_service.Put(_mapper.Map<TEntity>(obj), getDependencies));

        }
    }
}

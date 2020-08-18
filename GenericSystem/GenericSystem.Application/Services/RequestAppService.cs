using AutoMapper;
using GenericSystem.Application.Interfaces;
using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Services;
using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Services
{
    internal class RequestAppService : CrudAppService<Request, RequestViewModel>, IRequestAppService
    {
        private readonly IRequestService _requestService;

        public RequestAppService(IMapper mapper, IRequestService requestService) : base(mapper, requestService)
        {
            _requestService = requestService;
        }
    }
}

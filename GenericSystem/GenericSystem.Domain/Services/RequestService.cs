using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Services
{
    internal class RequestService : CrudService<Request>, IRequestService
    {
        public readonly IRequestRepository _requestRepository;

        public RequestService(IRequestRepository requestRepository, IUnitOfWork unitOfWork) : base(requestRepository, unitOfWork)
        {
            _requestRepository = requestRepository;
        }
    }
}

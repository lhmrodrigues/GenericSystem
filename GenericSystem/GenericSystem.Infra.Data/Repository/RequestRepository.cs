using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Repository
{
    internal class RequestRepository : CrudRepository<Request>, IRequestRepository
    {
        public RequestRepository(GenericSystemsContext context) : base(context)
        {
        }
    }
}

using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Infra.Data.Repository
{
    internal class OrderRepository : CrudRepository<Order>, IOrderRepository
    {
        public OrderRepository(GenericSystemsContext context) : base(context)
        {
        }
    }
}

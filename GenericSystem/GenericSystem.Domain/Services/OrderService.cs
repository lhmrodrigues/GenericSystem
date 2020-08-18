using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Services
{
    internal class OrderService : CrudService<Order>, IOrderService
    {
        public readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository, IUnitOfWork unitOfWork) : base(orderRepository, unitOfWork)
        {
            _orderRepository = orderRepository;
        }
    }
}

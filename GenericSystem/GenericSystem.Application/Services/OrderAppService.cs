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
    internal class OrderAppService : CrudAppService<Order, OrderViewModel>, IOrderAppService
    {
        private readonly IOrderService _categoryService;

        public OrderAppService(IMapper mapper, IOrderService categoryService) : base(mapper, categoryService)
        {
            _categoryService = categoryService;
        }
    }
}

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
    internal class ProductAppService : CrudAppService<Product, ProductViewModel>, IProductAppService
    {
        private readonly IProductService _productService;

        public ProductAppService(IMapper mapper, IProductService productService) : base(mapper, productService)
        {
            _productService = productService;
        }
    }
}

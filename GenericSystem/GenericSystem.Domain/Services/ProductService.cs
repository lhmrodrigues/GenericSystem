using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Services
{
    internal class ProductService : CrudService<Product>, IProductService
    {
        public readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork) : base(productRepository, unitOfWork)
        {
            _productRepository = productRepository;
        }
    }
}

using GenericSystem.Domain.Entities;
using GenericSystem.Domain.Interfaces.Repositories;
using GenericSystem.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Services
{
    internal class CategoryService : CrudService<Category>, ICategoryService
    {
        public readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, 
            IUnitOfWork unitOfWork) 
            : base(categoryRepository, unitOfWork)
        {
            _categoryRepository = categoryRepository;
        }
    }
}

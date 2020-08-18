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
    internal class CategoryAppService : CrudAppService<Category, CategoryViewModel>, ICategoryAppService
    {
        private readonly ICategoryService _categoryService;
        public CategoryAppService(IMapper mapper, 
            ICategoryService categoryService) 
            : base(mapper, categoryService)
        {
            _categoryService = categoryService;
        }
    }
}

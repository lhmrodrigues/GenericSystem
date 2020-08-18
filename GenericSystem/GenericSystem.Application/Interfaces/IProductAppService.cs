using GenericSystem.Infra.CrossCutting.Util.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Application.Interfaces
{
    public interface IProductAppService : ICrudAppService<ProductViewModel>
    {
    }
}

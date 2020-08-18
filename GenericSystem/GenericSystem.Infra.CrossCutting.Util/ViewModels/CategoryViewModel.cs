using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public string Name { get; set; }
    }
}

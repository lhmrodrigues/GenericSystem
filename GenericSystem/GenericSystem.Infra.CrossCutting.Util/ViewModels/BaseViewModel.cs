using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.ViewModels
{
    public abstract class BaseViewModel
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        public Guid Id { get; set; }
    }
}

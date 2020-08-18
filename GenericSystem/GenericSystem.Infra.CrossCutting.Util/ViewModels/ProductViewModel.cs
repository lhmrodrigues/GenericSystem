using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.ViewModels
{
    public class ProductViewModel : BaseViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public string Name { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public double Price { get; set; }

        [Display(Name = "IdCategoria")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        public Guid IdCategory { get; set; }
        public CategoryViewModel Category { get; set; }
    }
}

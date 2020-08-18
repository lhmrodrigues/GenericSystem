using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.ViewModels
{
    public class OrderViewModel : BaseViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        [MaxLength(15, ErrorMessage = "{0} pode conter no máximo {1} caractéres.")]
        public string Name { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        [DataType(DataType.Date, ErrorMessage = "{0} em formato inválido")]
        public DateTime Date { get; set; }

        [Display(Name = "Status")]
        public bool Status { get; set; }
    }
}

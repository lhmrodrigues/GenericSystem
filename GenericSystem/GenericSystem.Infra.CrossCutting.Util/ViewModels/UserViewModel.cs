using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.ViewModels
{
    public class UserViewModel : BaseViewModel
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        [MaxLength(15, ErrorMessage = "{0} pode conter no máximo {1} caractéres.")]
        public string Username { get; set; }

        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public string Password { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public string Name { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public string CPF { get; set; }

        [Display(Name = "Data")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        [DataType(DataType.Date, ErrorMessage = "{0} em formato inválido")]
        public DateTime Date { get; set; }
    }
}

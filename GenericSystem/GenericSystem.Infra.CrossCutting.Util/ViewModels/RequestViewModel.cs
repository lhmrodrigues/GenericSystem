using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GenericSystem.Infra.CrossCutting.Util.ViewModels
{
    public class RequestViewModel : BaseViewModel
    {
        [Display(Name = "Data")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        [DataType(DataType.Date, ErrorMessage = "{0} em formato inválido")]
        public DateTime Date { get; set; }

        [Display(Name = "IdComanda")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        public Guid IdOrder { get; set; }
        public OrderViewModel Order { get; set; }

        [Display(Name = "IdProduto")]
        [Required(ErrorMessage = "Necessário informar a {0}.")]
        public Guid IdProduct { get; set; }
        public ProductViewModel Product { get; set; }

        [Display(Name = "Qauntidade")]
        [Required(ErrorMessage = "Necessário informar o {0}.")]
        public int Quantity { get; set; }
    }
}

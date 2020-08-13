using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime Date { get; set; }
    }
}

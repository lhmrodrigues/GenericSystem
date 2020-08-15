using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string CPF { get; set; }
        public DateTime Date { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
    }
}

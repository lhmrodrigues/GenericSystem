using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Entities
{
    public class Request : BaseEntity
    {
        public DateTime Date { get; set; }
        public Guid IdOrder { get; set; }
        public Order Order { get; set; }
        public Guid IdProduct { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}

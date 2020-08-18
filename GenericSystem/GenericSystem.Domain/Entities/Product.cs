using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSystem.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Photo { get; set; }
        public double Price { get; set; }
        public Guid IdCategory { get; set; }
        public Category Category { get; set; }

    }
}

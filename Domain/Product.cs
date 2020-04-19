using System;

namespace Domain
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        public Product()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

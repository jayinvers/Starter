﻿namespace Starter.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }

        public string Sn { get; set; }

        public string Detail { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}

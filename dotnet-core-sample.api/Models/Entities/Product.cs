using System;
using dotnet_core_sample.api.Enums;
using dotnet_core_sample.api.Models.Entities;

namespace dotnet_core_sample.api.Models
{
    public class Product : Entity
    {
        public Product()
        {
            Id = Guid.NewGuid();
            Name = "Name";
            Quantity = 10;
            Price = new Price
            {
                Amount = 10m,
                Currency = "EUR"
            };
            ProductType = ProductType.Type1;
        }

        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public Price Price { get; private set; }
        public ProductType ProductType { get; private set; }
    }
}

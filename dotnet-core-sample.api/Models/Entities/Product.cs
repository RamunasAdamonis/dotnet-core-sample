using dotnet_core_sample.api.Enums;
using dotnet_core_sample.api.Models.Entities;

namespace dotnet_core_sample.api.Models
{
    public class Product : Entity
    {
        public Product()
        {

        }

        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public ProductType ProductType { get; set; }
    }
}

using dotnet_core_sample.api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace dotnet_core_sample.api.ModelConfigurations
{
    public class ProductConfiguration : ConfigurationBase<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductType).HasColumnType("VARCHAR(50)");

            builder.OwnsOne(n => n.Price, p => p.Property(x => x.Amount).HasColumnType("DECIMAL(18, 2)"));

            base.Configure(builder);
        }
    }
}

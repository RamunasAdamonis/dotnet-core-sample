using System;
using Microsoft.EntityFrameworkCore;
using dotnet_core_sample.api.ModelConfigurations;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using dotnet_core_sample.api.Models;

namespace dotnet_core_sample.api.unitTests
{
    public class DatabaseTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        public DatabaseTests()
        {
            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetAllProducts_WithOrdering_ReturnsProduct()
        {
            //Arrange
            using (var context = new DatabaseContext(_options))
            {
                var product = new Product();
                context.Products.Add(product);
                await context.SaveChangesAsync();
            }

            //Act and assert
            using (var context = new DatabaseContext(_options))
            {
                var products = await context.Products
                    .OrderBy(x => x.ProductType)
                    .ThenByDescending(x => x.Price.Amount)
                    .ToListAsync();

                Assert.Single(products);
            }
        }
    }
}

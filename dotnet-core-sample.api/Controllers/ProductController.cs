using System.Linq;
using System.Threading.Tasks;
using dotnet_core_sample.api.ModelConfigurations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace dotnet_core_sample.api.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly DatabaseContext _dbContext;

        public ProductController(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("sum")]
        public async Task<ActionResult<object>> GetSum()
        {
            var query = _dbContext.Products.Where(x => x.Name == "Product");

            var summary = await _dbContext.Products
                .Select(x => new { Sum = query.Sum(x => x.Price.Amount), Count = query.Count() })
                .ToListAsync();
            return Ok(summary);
        }

        [HttpGet("max")]
        public async Task<ActionResult<object>> GetMax()
        {
            var summary = await _dbContext.Products
                .GroupBy(p => p.ProductType, p => p.Price.Amount)
                .Select(g => new { ProductType = g.Key, Sum = g.Max(x => x) })
                .ToListAsync();
            return Ok(summary);
        }
    }
}

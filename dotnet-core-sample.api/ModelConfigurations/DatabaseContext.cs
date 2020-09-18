using Microsoft.EntityFrameworkCore;

namespace dotnet_core_sample.api.ModelConfigurations
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}

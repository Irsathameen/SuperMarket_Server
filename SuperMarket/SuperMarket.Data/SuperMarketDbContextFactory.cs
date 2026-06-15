using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SuperMarket.Context;

namespace SuperMarket.Data
{
    public class SuperMarketDbContextFactory : IDesignTimeDbContextFactory<SuperMarketDbContext>
    {
        public SuperMarketDbContext CreateDbContext(string[] args)
        {
            // Set base path to ProfileService project directory
            var basePath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "../SuperMarket"));
            // Build configuration
            var config = new ConfigurationBuilder()
                 .SetBasePath(basePath) // Current directory
                 .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true) // Load appsettings.json
                 //.AddJsonFile($"appsettings.Local.json", optional: true, reloadOnChange: true) // Load environment-specific file
                 .Build();

            // Get the connection string
            var connectionString = config.GetConnectionString("DefaultConnection");
            if (string.IsNullOrEmpty(connectionString))
                throw new InvalidOperationException("DefaultConnection string is missing or empty.");

            // Create DbContextOptions
            var optionsBuilder = new DbContextOptionsBuilder<SuperMarketDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // Return the DbContext
            return new SuperMarketDbContext(optionsBuilder.Options);
        }
    }
}

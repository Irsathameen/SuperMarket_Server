using Microsoft.EntityFrameworkCore;
using SuperMarket.Data.Models;

namespace SuperMarket.Context
{
    public class SuperMarketDbContext : DbContext
    {

        public SuperMarketDbContext(DbContextOptions<SuperMarketDbContext> options)
               : base(options) { }
        public DbSet<User> Users { get; set; }
    }
}

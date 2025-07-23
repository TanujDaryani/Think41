using Microsoft.EntityFrameworkCore;
using Think41.BaggageAPI.Models;

namespace Think41.BaggageAPI
{
    public class Think41DbContext : DbContext
    {
        public Think41DbContext(DbContextOptions<Think41DbContext> options) : base(options) { }

        public DbSet<BagScan> BagScans { get; set; }
    }
}

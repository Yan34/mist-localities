using Microsoft.EntityFrameworkCore;

namespace LocalityBaseNetCore.Models
{
    public class LocalitiesContext : DbContext
    {
        public DbSet<Locality> Localities { get; set; }
        
        public LocalitiesContext(DbContextOptions<LocalitiesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
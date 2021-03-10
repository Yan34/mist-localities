using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace LocalityBaseNetCore.Models
{
    public class LocalitiesContext : DbContext, IDataSource
    {
        private DbSet<Locality> Localities { get; set; }
        
        public LocalitiesContext(DbContextOptions<LocalitiesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public List<Locality> GetLocalities()
        {
            if(Localities.Any())
                return Localities.ToList();
            return null;
        }

        public void AddLocality(Locality loc)
        {
            Localities.Add(loc);
            SaveChanges();
        }

        public void AddLocalities(params Locality[] locs)
        {
            Localities.AddRange(locs);
            SaveChanges();
        }

        public int LocalitiesCount()
        {
            if(Localities.Any())
                return Localities.Count();
            return 0;
        }
    }
}
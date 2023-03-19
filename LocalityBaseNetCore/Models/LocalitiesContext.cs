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

        public Locality GetLocality(int id)
        {
            Locality loc = Localities.Find(id);
            return loc;
        }

        public void AddLocality(Locality loc)
        {
            Localities.Add(loc);
            SaveChanges();
        }

        public void UpdateLocality(Locality loc)
        {
            Localities.Update(loc);
            SaveChanges();
        }

        public void AddLocalities(params Locality[] locs)
        {
            Localities.AddRange(locs);
            SaveChanges();
        }

        public void DeleteLocality(int id)
        {
            Localities.Remove(Localities.Find(id));
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
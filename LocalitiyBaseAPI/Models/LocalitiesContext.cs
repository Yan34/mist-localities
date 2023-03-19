using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LocalityBaseAPI.Models
{
    public class LocalitiesContext : DbContext, IDataSource
    {
        private DbSet<Locality> Localities { get; set; }
        
        public LocalitiesContext(DbContextOptions<LocalitiesContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public async Task <IEnumerable<Locality> > GetLocalities()
        {
            return await Localities.ToListAsync();
        }
        public async Task<Locality> GetLocality(int id)
        {
            return await Localities.FindAsync(id);
        }

        public async Task<Locality> AddLocality(Locality loc)
        {
            Localities.Add(loc);
            await SaveChangesAsync();
            return loc;
        }

        public async Task<Locality> UpdateLocality(Locality loc)
        {
            Entry(loc).State = EntityState.Modified;
            await SaveChangesAsync();
            return loc;
        }
        public bool DeleteLocality(int id)
        {
            bool result = false;
            var loc = Localities.Find(id);
            if (loc != null)
            {
                Entry(loc).State = EntityState.Deleted;
                SaveChanges();
                result = true;
            }
            return result;
        }

        public async Task<int> LocalitiesCount()
        {
            return await Localities.CountAsync();
        }
    }
}
using System.Collections.Generic;

namespace LocalityBaseNetCore.Models
{
    public interface IDataSource
    {
        public List<Locality> GetLocalities();
        public void AddLocality(Locality loc);
        public void AddLocalities(params Locality[] locs);
        public int LocalitiesCount();
    }
}
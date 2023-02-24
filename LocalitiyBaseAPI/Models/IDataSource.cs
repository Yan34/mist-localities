using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalityBaseAPI.Models
{
    public interface IDataSource
    {
        Task<IEnumerable<Locality> > GetLocalities();
        Task<Locality> GetLocality(int id);
        Task<Locality> InsertLocality(Locality loc);
        Task<Locality> UpdateLocality(Locality loc);
        bool DeleteLocality(int id);
    }
}
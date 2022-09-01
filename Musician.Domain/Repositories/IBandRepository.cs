using Musician.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Musician.Domain.Repositories
{
    public interface IBandRepository
    {
        Task<List<Band>> GetBands();
        Task CreateBand(Band band);
        Task<Band> GetByBandId(int id);
        Task Update(Band band);
        Task DeleteBand(Band band);
    }
}

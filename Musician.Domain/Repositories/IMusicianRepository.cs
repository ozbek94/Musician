using System.Collections.Generic;
using System.Threading.Tasks;

namespace Musician.Domain.Repositories
{
    public interface IMusicianRepository
    {
        Task<List<Entity.Musician>> GetMusicians();
        Task<Entity.Musician> GetByMusicianId(int MusicianId);
        Task CreateNewMusician(Entity.Musician Musician);
        Task Update(Entity.Musician Musician);
        Task DeleteMusician(Entity.Musician Musician);
    }
}

using Microsoft.EntityFrameworkCore;
using Musician.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musician.Data.Repositories
{
    public class MusicianRepository : IMusicianRepository
    {
        private readonly PostgreSqlContext _context;

        public MusicianRepository(PostgreSqlContext context)
        {
            this._context = context;
        }

        public async Task CreateNewMusician(Domain.Entity.Musician Musician)
        {
            await _context.Musicians.AddAsync(Musician);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMusician(Domain.Entity.Musician Musician)
        {
            Musician.DeleteTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<Domain.Entity.Musician> GetByMusicianId(int MusicianId)
        {
            return await _context.Musicians.FirstOrDefaultAsync(x => x.Id == MusicianId);
        }

        public async Task<List<Domain.Entity.Musician>> GetMusicians()
        {
            return await _context.Musicians.ToListAsync();
        }

        public async Task Update(Domain.Entity.Musician Musician)
        {
            _context.Musicians.Update(Musician);
            await _context.SaveChangesAsync();
        }
    }
}

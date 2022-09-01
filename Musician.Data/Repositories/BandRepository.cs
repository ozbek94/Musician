using Microsoft.EntityFrameworkCore;
using Musician.Domain.Entity;
using Musician.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Data.Repositories
{
    public class BandRepository : IBandRepository
    {
        private readonly PostgreSqlContext _context;

        public BandRepository(PostgreSqlContext context)
        {
            this._context = context;
        }

        public async Task CreateBand(Band band)
        {
            await _context.Bands.AddAsync(band);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBand(Band band)
        {
            band.DeleteTime = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Band>> GetBands()
        {
            return await _context.Bands
                .Include(b => b.BandMusicians)
                .ToListAsync();
        }

        public async Task<Band> GetByBandId(int id)
        {
            return await _context.Bands.FirstOrDefaultAsync();
        }

        public async Task Update(Band band)
        {
            _context.Bands.Update(band);
            await _context.SaveChangesAsync();
        }
    }
}

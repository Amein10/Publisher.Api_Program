using Microsoft.EntityFrameworkCore;
using Publisher.Data.Data;
using Publisher.Domain.Models;

namespace Publisher.Domain.Repositories
{
    public class CoverRepository : ICoverRepository
    {
        private readonly PublisherDbContext _context;

        public CoverRepository(PublisherDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cover>> GetAllAsync()
        {
            return await _context.Covers
                .Include(c => c.Book)
                .Include(c => c.ArtistCovers)
                    .ThenInclude(ac => ac.Artist)
                .ToListAsync();
        }

        public async Task<Cover?> GetByIdAsync(int id)
        {
            return await _context.Covers
                .Include(c => c.Book)
                .Include(c => c.ArtistCovers)
                    .ThenInclude(ac => ac.Artist)
                .FirstOrDefaultAsync(c => c.CoverId == id);
        }

        public async Task AddAsync(Cover cover)
        {
            _context.Covers.Add(cover);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cover cover)
        {
            _context.Covers.Update(cover);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cover = await _context.Covers.FindAsync(id);
            if (cover != null)
            {
                _context.Covers.Remove(cover);
                await _context.SaveChangesAsync();
            }
        }
    }
}

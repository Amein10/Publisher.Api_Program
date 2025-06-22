using Microsoft.EntityFrameworkCore;
using Publisher.Data.Data;
using Publisher.Domain.Models;

namespace Publisher.Domain.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly PublisherDbContext _context;

        public ArtistRepository(PublisherDbContext context)
        {
            _context = context;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _context.Artists
                .Include(a => a.ArtistCovers)
                .ToListAsync();
        }

        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _context.Artists
                .Include(a => a.ArtistCovers)
                .ThenInclude(ac => ac.Cover)
                .FirstOrDefaultAsync(a => a.ArtistId == id);
        }

        public async Task AddAsync(Artist artist)
        {
            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Artist artist)
        {
            _context.Artists.Update(artist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist != null)
            {
                _context.Artists.Remove(artist);
                await _context.SaveChangesAsync();
            }
        }
    }
}

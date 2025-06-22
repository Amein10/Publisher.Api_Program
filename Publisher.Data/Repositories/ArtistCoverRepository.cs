using Microsoft.EntityFrameworkCore;
using Publisher.Data.Data;
using Publisher.Domain.Models;

namespace Publisher.Domain.Repositories
{
    public class ArtistCoverRepository : IArtistCoverRepository
    {
        private readonly PublisherDbContext _context;

        public ArtistCoverRepository(PublisherDbContext context)
        {
            _context = context;
        }

        public async Task<List<ArtistCover>> GetAllAsync()
        {
            return await _context.ArtistCovers
                .Include(ac => ac.Artist)
                .Include(ac => ac.Cover)
                .ToListAsync();
        }

        public async Task<ArtistCover?> GetByIdsAsync(int artistId, int coverId)
        {
            return await _context.ArtistCovers
                .Include(ac => ac.Artist)
                .Include(ac => ac.Cover)
                .FirstOrDefaultAsync(ac => ac.ArtistId == artistId && ac.CoverId == coverId);
        }

        public async Task AddAsync(ArtistCover artistCover)
        {
            _context.ArtistCovers.Add(artistCover);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int artistId, int coverId)
        {
            var artistCover = await _context.ArtistCovers
                .FirstOrDefaultAsync(ac => ac.ArtistId == artistId && ac.CoverId == coverId);
            if (artistCover != null)
            {
                _context.ArtistCovers.Remove(artistCover);
                await _context.SaveChangesAsync();
            }
        }
    }
}

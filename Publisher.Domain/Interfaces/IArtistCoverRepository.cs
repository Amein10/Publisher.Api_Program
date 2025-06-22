using Publisher.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publisher.Domain.Repositories
{
    public interface IArtistCoverRepository
    {
        Task<List<ArtistCover>> GetAllAsync();
        Task<ArtistCover?> GetByIdsAsync(int artistId, int coverId);
        Task AddAsync(ArtistCover artistCover);
        Task DeleteAsync(int artistId, int coverId);
    }
}

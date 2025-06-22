using Publisher.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publisher.Domain.Repositories
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllAsync();
        Task<Artist?> GetByIdAsync(int id);
        Task AddAsync(Artist artist);
        Task UpdateAsync(Artist artist);
        Task DeleteAsync(int id);
    }
}

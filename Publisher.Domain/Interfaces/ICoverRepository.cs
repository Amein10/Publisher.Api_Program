using Publisher.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publisher.Domain.Repositories
{
    public interface ICoverRepository
    {
        Task<List<Cover>> GetAllAsync();
        Task<Cover?> GetByIdAsync(int id);
        Task AddAsync(Cover cover);
        Task UpdateAsync(Cover cover);
        Task DeleteAsync(int id);
    }
}

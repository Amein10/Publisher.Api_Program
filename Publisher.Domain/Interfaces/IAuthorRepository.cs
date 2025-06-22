using Publisher.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publisher.Domain.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
    }
}

using Publisher.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Publisher.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAllAsync();
        Task<Book?> GetByIdAsync(int id);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
    }
}

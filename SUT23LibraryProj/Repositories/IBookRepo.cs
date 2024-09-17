using SUT23LibraryProj.Models;

namespace SUT23LibraryProj.Repositories
{
    public interface IBookRepo
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByIdAsync(int id);
        Task<Book> GetByNameAsync(string name);

        Task CreateBookAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(Book book);
        Task SaveAsync();
    }
}

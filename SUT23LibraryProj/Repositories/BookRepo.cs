using Microsoft.EntityFrameworkCore;
using SUT23LibraryProj.Data;
using SUT23LibraryProj.Models;

namespace SUT23LibraryProj.Repositories
{
    public class BookRepo : IBookRepo
    {

        private readonly AppDbContext _db;
        public BookRepo(AppDbContext db)
        {
            _db = db;
        }

        public async Task CreateBookAsync(Book book)
        {
            _db.Books.Add(book);
        }

        public async Task DeleteAsync(Book book)
        {
           _db.Books.Remove(book);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.BookID == id);
        }

        public async Task<Book> GetByNameAsync(string title)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Title == title.ToLower());
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
        }
    }
}

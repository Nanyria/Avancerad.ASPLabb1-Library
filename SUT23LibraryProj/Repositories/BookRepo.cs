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
            //Borde det inte vara await på något sätt här?
            await _db.Books.AddAsync(book);
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

        public async Task<Book> GetByTitleAsync(string title)
        {
            return await _db.Books.FirstOrDefaultAsync(b => b.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync(); //Vi använde inte await här, why not?
        }

        public async Task UpdateAsync(Book book)
        {
            _db.Books.Update(book);
        }

        public async Task UpdateStockAsync(int id, Book book)
        {
            _db.Books.Update(book);
        }
    }
}

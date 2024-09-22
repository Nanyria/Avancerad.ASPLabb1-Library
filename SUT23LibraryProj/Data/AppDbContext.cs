using Microsoft.EntityFrameworkCore;
using SUT23LibraryProj.Models;

namespace SUT23LibraryProj.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
            new Book
            {
                BookID = 101,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "Fiction",
                PublicationYear = 1925,
                BookDescription = "Lorem Ipsum",
                IsInStock = true
            },
            new Book
            {
                BookID = 102,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Genre = "Fiction",
                PublicationYear = 1960,
                BookDescription = "Lorem Ipsum",
                IsInStock = true
            },
            new Book
            {
                BookID = 103,
                Title = "1984",
                Author = "George Orwell",
                Genre = "Fiction",
                PublicationYear = 1949,
                BookDescription = "Lorem Ipsum",
                IsInStock = false
            });
        }
    }
}

using SUT23LibraryProj.Models;

namespace SUT23LibraryProj.Data
{
    public static class LibraryTestObjects
    {
        public static List<Book> bookList = new List<Book>
        {
            new Book
            {
                BookID = 1,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Genre = "Fiction",
                PublicationYear = 1925,
                BookDescription = "Lorem Ipsum",
                IsInStock = true
            },
            new Book
            {
                BookID = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Genre = "Fiction",
                PublicationYear = 1960,
                BookDescription = "Lorem Ipsum",
                IsInStock = true
            },
            new Book
            {
                BookID = 3,
                Title = "1984",
                Author = "George Orwell",
                Genre = "Fiction",
                PublicationYear = 1949,
                BookDescription = "Lorem Ipsum",
                IsInStock = false
            }
        };
    }

}

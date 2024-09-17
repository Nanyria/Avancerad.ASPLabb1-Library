using System.ComponentModel.DataAnnotations;

namespace SUT23LibraryProj.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public string BookDescription { get; set; }
        public bool IsInStock { get; set; }
    }
}

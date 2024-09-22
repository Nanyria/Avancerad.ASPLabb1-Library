using System.ComponentModel.DataAnnotations;

namespace SUT23LibraryProj.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(75)]
        public string Author { get; set; }
        [Required]
        [MaxLength(25)]
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public string BookDescription { get; set; }
        public bool IsInStock { get; set; }
    }
}

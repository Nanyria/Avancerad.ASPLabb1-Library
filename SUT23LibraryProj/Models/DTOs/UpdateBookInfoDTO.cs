using System.ComponentModel.DataAnnotations;

namespace SUT23LibraryProj.Models.DTOs
{
    public class UpdateBookInfoDTO
    {
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Genre { get; set; }
        public int PublicationYear { get; set; }
        public string BookDescription { get; set; }

    }
}

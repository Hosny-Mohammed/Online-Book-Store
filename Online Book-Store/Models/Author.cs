using System.ComponentModel.DataAnnotations;

namespace Online_Book_Store.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }
        [Required] public string? AuthorName { get; set; }
        [Required] public string? AuthorBio  { get; set; }
        [Required] public DateOnly? DateOfBirth { get; set; }
        public ICollection<Book>? Books { get; set; }
    }
}

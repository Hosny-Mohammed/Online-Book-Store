using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Online_Book_Store.Models
{
    public class Book
    {
        [Key] public int BookId { get; set; }
        [Required] public string? Title { get; set; }
        [Required] public string? ImgURL { get; set; }
        [Required] public string? Genre { get; set; }
        [Required] public float? Price { get; set; }
        [Required] public DateOnly? PublicationDate { get; set; }
        [Required]public int? AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author? Author { get; set; }
    }
}

using BookStoreApplication.Enums;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter Title")]
        public string Title { get; set; }
        [Required(ErrorMessage ="please enter Author")]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage ="Please enter TotalPages")]
        public int? TotalPages { get; set; }
    }
}

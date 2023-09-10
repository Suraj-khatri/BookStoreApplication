using BookStoreApplication.Enums;
using Microsoft.AspNetCore.Http;
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
        [Display(Name ="Choose you cover photo")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }
        [Display(Name = "Choose you gallery images of your photo")]
        [Required]
        public IFormCollection GalleryFiles { get; set; }
    }
}

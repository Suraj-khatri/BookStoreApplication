﻿using System.ComponentModel.DataAnnotations;

namespace BookStoreApplication.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required]
        public int TotalPages { get; set; }
    }
}

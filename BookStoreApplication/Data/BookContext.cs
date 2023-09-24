
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApplication.Data
{
    public class BookContext : IdentityDbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<BookGallery> BooksGallery { get; set; }
    }
}

﻿
using Microsoft.EntityFrameworkCore;

namespace BookStoreApplication.Data
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Book> books { get; set; }
        public DbSet<Language> Language { get; set; }
    }
}

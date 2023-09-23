using BookStoreApplication.Data;
using BookStoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Repository
{
    public class BookRepository
    {
        private readonly BookContext _context = null;

        public BookRepository(BookContext bookContext)
        {
            _context = bookContext;
        }

        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Book()
            {
                Author = model.Author,
                Title = model.Title,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                LanguageId = model.LanguageId,
                Category = model.Category,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl = model.CoverImageUrl,
                BookPdfUrl = model.BookpdfUrl,
            };
            newBook.Gallery = new List<BookGallery>();

            foreach(var file in model.Gallery)
            {
                newBook.Gallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.URL,
                });
            }

            await _context.books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.books.Select(x => new BookModel()
            {
                Title = x.Title,
                Author = x.Author,
                Category = x.Category,
                Description = x.Description,
                TotalPages = x.TotalPages,
                Id = x.Id,
                LanguageId = x.LanguageId,
                Language = x.Language.Name,
                CoverImageUrl= x.CoverImageUrl,
                
            }
            ).ToListAsync();
            return allBooks;
        }

        public async Task<BookModel> GetById(int id)
        {
            return await _context.books.Where(x => x.Id == id).Select(
                book => new BookModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Id = id,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Name,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.Gallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL,
                    }).ToList(),
                    BookpdfUrl = book.BookPdfUrl,
                }).FirstOrDefaultAsync(); 
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return null;
        }

        
    }
}

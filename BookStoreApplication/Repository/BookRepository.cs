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
                TotalPages = model.TotalPages,
                //Language = model.Language,
                Category = model.Category,
                CreatedOn = DateTime.UtcNow,
                UpdatedOn = DateTime.UtcNow,
            };
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
                Language = x.Language,
                
            }
            ).ToListAsync();
            return allBooks;
        }

        public async Task<BookModel> GetById(int id)
        {
            var book =await _context.books.FindAsync(id);  // find is used for promary key and we use where for other.
            if(book != null)
            {
                var bookmodel = new BookModel()
                {
                    Title = book.Title,
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    TotalPages = book.TotalPages,
                    Id = id,
                    Language = book.Language,

                };
                return bookmodel;
            }
            return null;
        }

        public List<BookModel> SearchBook(string title,string authorName)
        {
            return DataSource().Where(x=>x.Title==title && x.Author ==authorName).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel(){Id=1,Title="MVC",Author="XYZ",Description="This is the description for MVC.",Category="Programming",Language="English",TotalPages=112},
                new BookModel(){Id=2,Title="ASP.NET",Author="ABC",Description="This is the description for ASP.NET.",Category="Programming",Language="English",TotalPages=222},
                new BookModel(){Id=3,Title="PYTHON",Author="PQR",Description="This is the description for PYTHON.",Category="Programming",Language="English",TotalPages=312},
                new BookModel(){Id=4,Title="PHP",Author="MNO",Description="This is the description for PHP.",Category="Programming",Language="English",TotalPages=412},
                new BookModel(){Id=5,Title="LARAVEL",Author="QRS",Description="This is the description for LARAVEL.",Category="Programming",Language="English",TotalPages=512},
                new BookModel(){Id=6,Title="NODEJS",Author="CDE",Description="This is the description for NODEJS.",Category="Programming",Language="English",TotalPages=612},
            };
        }
    }
}

using BookStoreApplication.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookStoreApplication.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetById(int id)
        {
            return DataSource().Where(x=>x.Id == id).FirstOrDefault();
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

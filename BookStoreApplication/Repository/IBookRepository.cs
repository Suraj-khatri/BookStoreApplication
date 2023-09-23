using BookStoreApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreApplication.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBook(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetById(int id);
        Task<List<BookModel>> GetTopBooks(int count);
        List<BookModel> SearchBook(string title, string authorName);
        string GetAppName();
    }
}
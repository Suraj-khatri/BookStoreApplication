using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository = null;
        public BookController(BookRepository repository)
        {
            _repository = repository;
        }
        public ViewResult GetAllBooks()
        {
            var data = _repository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id)
        {
            var data = _repository.GetById(id);
            return View(data);
        }
    }
}

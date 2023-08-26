using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository = null;
        public BookController(BookRepository repository)
        {
            _repository = repository;
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _repository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {
            var data =await _repository.GetById(id);
            return View(data);
        }

        public ViewResult AddNewBook(bool isSuccess=false , int bookId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if(ModelState.IsValid)
            {
                int id = await _repository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction("AddNewBook", new { isSuccess = true, bookId = id });
                }
            }


            //we have to assign it with initial value
            //we write this because after if block this will execute not addnewbook
        /*    ViewBag.IsSuccess = false;
            ViewBag.BookId = 0;*/


            return View();
        }
    }
}

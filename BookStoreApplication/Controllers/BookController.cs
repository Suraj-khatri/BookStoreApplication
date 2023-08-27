using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository = null;
        private readonly LanguageRepository _languageRepository = null;
        public BookController(BookRepository repository, LanguageRepository languageRepository)
        {
            _repository = repository;
            _languageRepository = languageRepository;
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

        public async Task<ViewResult> AddNewBook(bool isSuccess=false , int bookId = 0)
        {
            var model = new BookModel()
            {
/*                Language="Nepali"
*/            };

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(),"Id","Name");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View(model);
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

            ViewBag.Languages = new SelectList(await _languageRepository.GetLanguages(), "Id", "Name");


            //we have to assign it with initial value
            //we write this because after if block this will execute not addnewbook
            /*    ViewBag.IsSuccess = false;
                ViewBag.BookId = 0;*/


            return View();
        }
    }
}

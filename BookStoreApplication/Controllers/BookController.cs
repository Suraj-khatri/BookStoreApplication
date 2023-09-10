using BookStoreApplication.Models;
using BookStoreApplication.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _repository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public BookController(BookRepository repository, LanguageRepository languageRepository, IWebHostEnvironment env)
        {
            _repository = repository;
            _languageRepository = languageRepository;
            _webHostEnvironment = env;
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
                if(bookModel.CoverPhoto != null)
                {
                    string folder = "books/cover/";
                   bookModel.CoverImageUrl= await UploadImage(folder,bookModel.CoverPhoto);
                }

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

             async Task<string> UploadImage(string folderPath,IFormFile file)
            {
                
                // here we upload photo with unique name and if 2 pto have same name so we append guid for unique name

                folderPath += Guid.NewGuid().ToString() + "_" + bookModel.CoverPhoto.FileName;
                string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);
                await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
                return "/" + folderPath;
                
            }
        }
    }
}

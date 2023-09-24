using BookStoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApplication.Controllers
{
    public class AccountController : Controller
    {
        [Route("signup")]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [Route("signup")]
        public IActionResult SignUp(SignUpUserModel model)
        {
            if(ModelState.IsValid)
            {
                ModelState.Clear();
            }
            return View();
        }
    }
}

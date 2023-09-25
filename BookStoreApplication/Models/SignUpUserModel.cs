using System;
using System.ComponentModel.DataAnnotations;

namespace BookStoreApplication.Models
{
    public class SignUpUserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [Required(ErrorMessage ="please enter your email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please enter a valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage ="please enter a strong password")]
        [Compare("ConfirmPassword",ErrorMessage ="Password doesnot match")]
        [Display(Name ="Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage ="please confirm your password")]
        [Display(Name ="Confirm Password")]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

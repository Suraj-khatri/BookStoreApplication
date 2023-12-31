﻿using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;
using System;

namespace BookStoreApplication.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
    }
}

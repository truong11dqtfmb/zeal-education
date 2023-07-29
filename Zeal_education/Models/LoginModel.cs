﻿using System.ComponentModel.DataAnnotations;

namespace Zeal_education.Models
{
    public class LoginModel
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

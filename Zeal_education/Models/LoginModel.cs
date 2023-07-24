using System.ComponentModel.DataAnnotations;

namespace Zeal_education.Models
{
    public class LoginModel
    {
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}

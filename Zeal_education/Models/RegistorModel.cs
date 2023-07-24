using System.ComponentModel.DataAnnotations;

namespace Zeal_education.Models
{
    public class RegistorModel
    {
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Invalid Email")]
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
    }
}

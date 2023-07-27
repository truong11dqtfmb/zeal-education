using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class User
    {
        public User()
        {
            Exams = new HashSet<Exam>();
        }

        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int? RoleId { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}

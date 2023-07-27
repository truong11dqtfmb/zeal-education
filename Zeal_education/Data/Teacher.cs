using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class Teacher
    {
        public Teacher()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Description { get; set; }
        public DateTime? CreateAt { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class Course
    {
        public Course()
        {
            Cartitems = new HashSet<Cartitem>();
            Exams = new HashSet<Exam>();
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Id { get; set; }
        public string? CourceName { get; set; }
        public string? Title { get; set; }
        public string? Fee { get; set; }
        public int? CategoryId { get; set; }
        public string? Description { get; set; }
        public int? TeacherId { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? CreateBy { get; set; }
        public DateTime? ModifyAt { get; set; }
        public string? ModifyBy { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Cartitem> Cartitems { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class Exam
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? UserId { get; set; }
        public int? Score { get; set; }
        public DateTime? TestDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual Course? Course { get; set; }
        public virtual User? User { get; set; }
    }
}

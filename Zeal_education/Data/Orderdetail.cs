﻿using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class Orderdetail
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? OrderId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Order? Order { get; set; }
    }
}

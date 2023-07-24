using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class Order
    {
        public Order()
        {
            Orderdetails = new HashSet<Orderdetail>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public string? Note { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
    }
}

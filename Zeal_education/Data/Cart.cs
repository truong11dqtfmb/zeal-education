using System;
using System.Collections.Generic;

namespace Zeal_education.Data
{
    public partial class Cart
    {
        public Cart()
        {
            Cartitems = new HashSet<Cartitem>();
        }

        public int Id { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<Cartitem> Cartitems { get; set; }
    }
}

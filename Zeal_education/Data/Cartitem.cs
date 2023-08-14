using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Zeal_education.Data
{
    public partial class Cartitem
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public int? CartId { get; set; }
        public bool? IsActive { get; set; }
        [JsonIgnore]

        public virtual Cart? Cart { get; set; }
        public virtual Course? Course { get; set; }
    }
}

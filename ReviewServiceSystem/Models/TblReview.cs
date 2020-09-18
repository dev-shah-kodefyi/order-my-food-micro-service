using System;
using System.Collections.Generic;

namespace ReviewServiceSystem.Models
{
    public partial class TblReview
    {
        public int RevId { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
        public double Rating { get; set; }
        public string Email { get; set; }
        public int RestId { get; set; }
    }
}

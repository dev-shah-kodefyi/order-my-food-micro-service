using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class TblReview
    {
        public int RevId { get; set; }
        public string CustomerName { get; set; }
        public string Comments { get; set; }
        public double Rating { get; set; }
        public string Email { get; set; }
        public int RestId { get; set; }
    }
}

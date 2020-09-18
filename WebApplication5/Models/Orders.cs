using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class Orders
    {
        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }

        public string Email { get; set; }
    }
}

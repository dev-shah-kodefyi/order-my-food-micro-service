using System;
using System.Collections.Generic;

namespace OrderFoodService.Models
{
    public partial class Orders
    {
        public Orders()
        {
            CartItem = new HashSet<CartItem>();
        }

        public int OrderId { get; set; }
        public int TotalPrice { get; set; }
        public string CustomerName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }

        public ICollection<CartItem> CartItem { get; set; }
    }
}

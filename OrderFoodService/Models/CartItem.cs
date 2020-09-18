using System;
using System.Collections.Generic;

namespace OrderFoodService.Models
{
    public partial class CartItem
    {
        public int CartId { get; set; }
        public int? RestId { get; set; }
        public int? FoodId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int Units { get; set; }
        public string PictureUrl { get; set; }
        public int? OrderId { get; set; }
        public string UserEmail { get; set; }
        public string Status { get; set; }

        public Orders Order { get; set; }
    }
}

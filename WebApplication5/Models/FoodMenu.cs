using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class FoodMenu
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }

        public int units { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ResturantManagementSystem.Models
{
    public partial class FoodResturant
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int RestId { get; set; }
        public int Price { get; set; }

        public TblFood Food { get; set; }
        public TblResturant Rest { get; set; }
    }
}

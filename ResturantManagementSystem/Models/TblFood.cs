using System;
using System.Collections.Generic;

namespace ResturantManagementSystem.Models
{
    public partial class TblFood
    {
        public TblFood()
        {
            FoodResturant = new HashSet<FoodResturant>();
        }

        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Quantity { get; set; }

        public ICollection<FoodResturant> FoodResturant { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace ResturantManagementSystem.Models
{
    public partial class TblResturant
    {
        public TblResturant()
        {
            CusineRestaurant = new HashSet<CusineRestaurant>();
            FoodResturant = new HashSet<FoodResturant>();
        }

        public int RestId { get; set; }
        public string RestName { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public double Rating { get; set; }
        public int? Budget { get; set; }

        public ICollection<CusineRestaurant> CusineRestaurant { get; set; }
        public ICollection<FoodResturant> FoodResturant { get; set; }
    }
}

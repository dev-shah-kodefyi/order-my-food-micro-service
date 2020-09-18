using System;
using System.Collections.Generic;

namespace ResturantManagementSystem.Models
{
    public partial class CusineRestaurant
    {
        public int Id { get; set; }
        public int CusineId { get; set; }
        public int RestId { get; set; }

        public TblCusine Cusine { get; set; }
        //public TblResturant Rest { get; set; } 
    }
}

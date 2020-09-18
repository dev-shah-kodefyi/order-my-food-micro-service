using System;
using System.Collections.Generic;

namespace ResturantManagementSystem.Models
{
    public partial class TblCusine
    {
        public TblCusine()
        {
            CusineRestaurant = new HashSet<CusineRestaurant>();
        }

        public int CusineId { get; set; }
        public string CusineType { get; set; }

        public ICollection<CusineRestaurant> CusineRestaurant { get; set; }
    }
}

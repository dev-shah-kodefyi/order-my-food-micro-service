using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class TblCuisine
    {
        public TblCuisine()
        {

        }
        public TblCuisine(int cusineId)
        {
            CusineId = cusineId;
        }

        public int CusineId { get; set; }
        public string CusineType { get; set; }
    }
}

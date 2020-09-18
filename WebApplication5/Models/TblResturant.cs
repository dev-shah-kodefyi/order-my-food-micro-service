using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication5.Models
{
    public class TblResturant
    {
        public TblResturant()
        {

        }

        public TblResturant(float rating)
        {
            Rating = rating;
        }

        public TblResturant(string restName)
        {
            RestName = restName;
        }
        public TblResturant(int Distance)
        {
            this.Distance = Distance;
        }


        public int RestId { get; set; }
        public string RestName { get; set; }
        public string Location { get; set; }
        public int Distance { get; set; }
        public double Rating { get; set; }
        public int? Budget { get; set; }
    }
}

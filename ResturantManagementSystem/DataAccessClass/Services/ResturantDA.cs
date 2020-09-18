using ResturantManagementSystem.DataAccessClass.Repositories;
using ResturantManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace ResturantManagementSystem.DataAccessClass.Services
{
    public class ResturantDA : IResturantDA
    {
        RestaurantDbContext dbContext = new RestaurantDbContext();

        public List<TblResturant> SearchByCuisine(TblCusine tblCusine)
        {

            List<CusineRestaurant> cusineRestaurants = dbContext.CusineRestaurant.Where(i => i.CusineId == tblCusine.CusineId).ToList();
            List<TblResturant> tblResturants = dbContext.TblResturant.ToList();
            List<TblResturant> resturants = new List<TblResturant>();
            foreach (TblResturant r in tblResturants)
            {
                foreach (CusineRestaurant c in cusineRestaurants)
                {
                    if (r.RestId == c.RestId)
                    {
                        resturants.Add(r);
                    }
                }
            }
            return resturants;


        }

        public List<TblResturant> SearchByLocation(TblResturant tblResturant)
        {

            List<TblResturant> resturantLists = dbContext.TblResturant.Where(s => s.Location == tblResturant.Location).ToList();

            return resturantLists;

        }

        public List<TblResturant> SearchByName(TblResturant tblResturant)
        {

            List<TblResturant> resturantDetails = dbContext.TblResturant.Where(i => i.RestName == tblResturant.RestName).ToList();
            return resturantDetails;
        }
        public List<TblResturant> SearchByDistance(TblResturant tblResturant)
        {
            List<TblResturant> result = dbContext.TblResturant.Where(s => s.Distance <= tblResturant.Distance).ToList();
            return result;
        }
        public List<TblResturant> SearchByRating(TblResturant tblResturant)
        {
            List<TblResturant> result = dbContext.TblResturant.Where(s => s.Rating == tblResturant.Rating).ToList();
            return result;
        }

        public List<TblResturant> SearchByBudget(TblResturant tblResturant)
        {

            List<TblResturant> result = dbContext.TblResturant.Where(i => i.Budget <= tblResturant.Budget).ToList();
            return result;
        }

        public List<TblCusine> CuisineList()
        {

            List<TblCusine> res = dbContext.TblCusine.ToList();
            return res;
        }

        public List<FoodMenu> MenuDetails(TblResturant tblResturant)
        {
            List<FoodResturant> foodResturants = dbContext.FoodResturant.Where(i => i.RestId == tblResturant.RestId).ToList();
            List<TblFood> FoodDetails = dbContext.TblFood.ToList();
          
            List<FoodMenu> foodMenus = new List<FoodMenu>();
   
            foreach (FoodResturant c in foodResturants)
                
            {
                foreach (TblFood f in FoodDetails)
                {
                    if (f.FoodId == c.FoodId)
                    {

                        FoodMenu result = new FoodMenu();
                        result.FoodId = f.FoodId;
                        result.FoodName = f.FoodName;
                        result.Price = c.Price;
                        result.Quantity = f.Quantity;
                        foodMenus.Add(result);


                    }
                   
                }
                
            }
            
            
            return foodMenus;

        }
    }
}

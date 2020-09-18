using ResturantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantManagementSystem.BusinessClass.Repositories
{
    public interface IResturantBLL
    {
        List<TblResturant> SearchByLocation(TblResturant tblResturant);
        List<TblResturant> SearchByCuisine(TblCusine tblCusine);
        List<TblResturant> SearchByName(TblResturant tblResturant);
        List<TblResturant> SearchByDistance(TblResturant tblResturant);
        List<TblResturant> SearchByRating(TblResturant tblResturant);
        List<TblResturant> SearchByBudget(TblResturant tblResturant);
        List<TblCusine> CuisineList();
        List<FoodMenu> MenuDetails(TblResturant tblResturant);
    }
}

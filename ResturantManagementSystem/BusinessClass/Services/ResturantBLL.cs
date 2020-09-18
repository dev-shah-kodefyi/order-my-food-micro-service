using ResturantManagementSystem.BusinessClass.Repositories;
using ResturantManagementSystem.DataAccessClass.Repositories;
using ResturantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantManagementSystem.BusinessClass.Services
{
    public class ResturantBLL : IResturantBLL
    {
      
        private readonly IResturantDA _dataAccess;

        public ResturantBLL(IResturantDA dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public List<TblCusine> CuisineList()
        {

            return _dataAccess.CuisineList();
        }

        public List<FoodMenu> MenuDetails(TblResturant tblResturant)
        {

            return _dataAccess.MenuDetails(tblResturant);
        }

        public List<TblResturant> SearchByBudget(TblResturant tblResturant)
        {
            return _dataAccess.SearchByBudget(tblResturant);
        }

        public List<TblResturant> SearchByCuisine(TblCusine tblCusine)
        {
            return _dataAccess.SearchByCuisine(tblCusine);
        }

        public List<TblResturant> SearchByDistance(TblResturant tblResturant)
        {

            return _dataAccess.SearchByDistance(tblResturant);
        }

        public List<TblResturant> SearchByLocation(TblResturant tblResturant)
        {
            return _dataAccess.SearchByLocation(tblResturant);
        }

        public List<TblResturant> SearchByName(TblResturant tblResturant)
        {
            return _dataAccess.SearchByName(tblResturant);
        }

        public List<TblResturant> SearchByRating(TblResturant tblResturant)
        {

            return _dataAccess.SearchByRating(tblResturant);
        }
    }
}

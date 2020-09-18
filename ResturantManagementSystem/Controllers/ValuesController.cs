using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ResturantManagementSystem.BusinessClass.Repositories;
using ResturantManagementSystem.Models;

namespace ResturantManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IResturantBLL _businessClass;

        public ValuesController(IResturantBLL businessClass)
        {
            _businessClass = businessClass;
        }
      
        [Route("SearchByLocation")]
        public ActionResult SearchByLocation(TblResturant tblResturant)
        {
            List<TblResturant> tblResturants = _businessClass.SearchByLocation(tblResturant);
            return Ok(tblResturants);

        }
        [HttpGet]
        [Route("CuisineList")]
        public ActionResult CuisineList()
        {
            List<TblCusine> cuisineLists = _businessClass.CuisineList();
            return Ok(cuisineLists);
        }
    
       [Route("SearchByCuisine")]
       public ActionResult<TblResturant> SearchByCuisine(TblCusine tblCusine)
        {

            try
            {
                List<TblResturant> ResturantLists = _businessClass.SearchByCuisine(tblCusine);
                return Ok(ResturantLists);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
     
        [Route("SearchByName")]
        public ActionResult SearchByName(TblResturant tblResturant)
        {

            List<TblResturant> resturantdetails = _businessClass.SearchByName(tblResturant);
            return Ok(resturantdetails);
        }
       
        [Route("SearchByDistance")]
        public ActionResult SearchByDistance(TblResturant tblResturant)
        {
            List<TblResturant> resturants = _businessClass.SearchByDistance(tblResturant);
            return Ok(resturants);
        }
       
        [Route("SearchByRating")]
        public ActionResult SearchByRating(TblResturant tblResturant)
        {
            List<TblResturant> resturants = _businessClass.SearchByRating(tblResturant);
            return Ok(resturants);
        }
        
        [Route("SearchByBudget")]
        public ActionResult SearchByBudget(TblResturant tblResturant)
        {
            List<TblResturant> resturants = _businessClass.SearchByBudget(tblResturant);
            return Ok(resturants);
        }
        [Route("MenuDetails")]
        public ActionResult MenuDetails(TblResturant tblResturant)
        {
            List<FoodMenu> foodDetails = _businessClass.MenuDetails(tblResturant);
            return Ok(foodDetails);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult About()
        //{
        //    ViewData["Message"] = "Your application description page.";

        //    return View();
        //}

        //public IActionResult Contact()
        //{
        //    ViewData["Message"] = "Your contact page.";

        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
        HttpClient WebApiClient = new HttpClient();

        public IActionResult First()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/CuisineList");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.GetAsync("CuisineList").Result;
            List<TblCuisine> cuisineList = response.Content.ReadAsAsync<List<TblCuisine>>().Result;


            return View(cuisineList);

        }

        public async Task<ActionResult> ResturantDetails(string location, string restName, float rating, int CusineId, int dist, int budget)
        {
            if (location != null)
            {
                TblResturant tblResturants = new TblResturant();
                tblResturants.Location = location;
                WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/SearchByLocation");

                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("SearchByLocation", tblResturants).Result;

                response.EnsureSuccessStatusCode();

                IEnumerable<TblResturant> resturantlist = response.Content.ReadAsAsync<IEnumerable<TblResturant>>().Result;
                return View("ResturantDetails", resturantlist);

            }
            else if (restName != null)
            {
                TblResturant tblResturant = new TblResturant(restName);
                WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/SearchByName");

                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("SearchByName", tblResturant).Result;

                response.EnsureSuccessStatusCode();

                IEnumerable<TblResturant> resturantlist = response.Content.ReadAsAsync<IEnumerable<TblResturant>>().Result;
                return View("ResturantDetails", resturantlist);
            }
            else if (rating != 0)
            {
                TblResturant tblResturant = new TblResturant(rating);
                WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/SearchByRating");

                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("SearchByRating", tblResturant).Result;

                response.EnsureSuccessStatusCode();

                IEnumerable<TblResturant> resturantlist = response.Content.ReadAsAsync<IEnumerable<TblResturant>>().Result;
                return View("ResturantDetails", resturantlist);
            }
            else if (CusineId != 0)
            {
                TblCuisine tblCuisine = new TblCuisine(CusineId);
                WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/SearchByCuisine");

                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("SearchByCuisine", tblCuisine).Result;

                response.EnsureSuccessStatusCode();

                IEnumerable<TblResturant> resturantlist = response.Content.ReadAsAsync<IEnumerable<TblResturant>>().Result;
                return View("ResturantDetails", resturantlist);
            }
            else if (dist != 0)
            {
                TblResturant tblResturant = new TblResturant();
                tblResturant.Distance = dist;
                WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/SearchByDistance");

                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("SearchByDistance", tblResturant).Result;

                response.EnsureSuccessStatusCode();

                IEnumerable<TblResturant> resturantlist = response.Content.ReadAsAsync<IEnumerable<TblResturant>>().Result;
                return View("ResturantDetails", resturantlist);
            }
            else if (budget != 0)
            {
                TblResturant tblResturant = new TblResturant();
                tblResturant.Budget = budget;
                WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/SearchByBudget");

                WebApiClient.DefaultRequestHeaders.Clear();
                WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = WebApiClient.PostAsJsonAsync("SearchByBudget", tblResturant).Result;

                response.EnsureSuccessStatusCode();

                IEnumerable<TblResturant> resturantlist = response.Content.ReadAsAsync<IEnumerable<TblResturant>>().Result;
                return View("ResturantDetails", resturantlist);
            }

            return RedirectToAction("First");

        }
        [Authorize]
        public ActionResult MenuDetails(int id)
        {
          
            ViewBag.id = 1;
            if (TempData["id"] != null)
            {
                id = (int)TempData["id"];
            }
           
            TblResturant tblResturant = new TblResturant();
            tblResturant.RestId = id;
            WebApiClient.BaseAddress = new Uri("http://localhost:41025/api/values/MenuDetails");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("MenuDetails", tblResturant).Result;

            response.EnsureSuccessStatusCode();

            IEnumerable<FoodMenu> foodItemlist = response.Content.ReadAsAsync<IEnumerable<FoodMenu>>().Result;
            return View(foodItemlist);


        }

        public ActionResult AddedToCart(int id, string foodname, int foodId, int price, int units)
        {
            string emailId = User.Identity.Name;
            TempData["id"] = id;
            CartItem cartItems = new CartItem();
            cartItems.FoodId = foodId;
            cartItems.FoodName = foodname;
            cartItems.RestId = id;
            cartItems.Price = price;
            cartItems.Units = units;
            cartItems.UserEmail = emailId;

            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/AddedToCart");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("AddedToCart", cartItems).Result;



            return RedirectToAction("MenuDetails", id);
        }
        public ActionResult CartDetails()
        {
            string EmailId = User.Identity.Name;
            CartItem cartItem = new CartItem();
            cartItem.UserEmail = EmailId;
            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/CartDetails");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("CartDetails", cartItem).Result;
            response.EnsureSuccessStatusCode();
            List<CartItem> cartItems = response.Content.ReadAsAsync<List<CartItem>>().Result;

            return View(cartItems);
           







        }
        public ActionResult Delete(int id)
        {
            CartItem item = new CartItem();
            item.CartId = id;
          
            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/Delete");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("Delete", item).Result;

           


            return RedirectToAction("CartDetails");
        }
        public ActionResult Proceed()
        {

            string EmailId = User.Identity.Name;
            CartItem cartItem = new CartItem();
            cartItem.UserEmail = EmailId;
            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/Proceed");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("Proceed", cartItem).Result;
            response.EnsureSuccessStatusCode();
            int totalPrice = response.Content.ReadAsAsync<int>().Result;
            ViewBag.totalPrice = totalPrice;

            



            return View();
        }
   
        public ActionResult Address(int TotalPrice ,string CustomerName,string ContactNo,string Address)
        {
            Orders order = new Orders();
            order.CustomerName = CustomerName;
            order.ContactNo = ContactNo;
            order.Address = Address;
            order.TotalPrice = TotalPrice;
            order.Status = "pending";
            order.Email = User.Identity.Name;
            order.OrderDate = System.DateTime.Now;
            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/PlaceOrder");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("PlaceOrder", order).Result;

          

            return View();

        }

        public ActionResult ConfirmOrder()
        {



            Orders order = new Orders();
            order.Email = User.Identity.Name;

            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/ConfirmOrder");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PutAsJsonAsync("ConfirmOrder", order).Result;

            return View();

        }
        public ActionResult YourOrders()
        {
            Orders order = new Orders();
            order.Email = User.Identity.Name;
            ViewBag.email = User.Identity.Name;


            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/OrderDetails");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("OrderDetails", order).Result;
            response.EnsureSuccessStatusCode();

            List<orderDetails> orderDetails = response.Content.ReadAsAsync<List<orderDetails>>().Result;

           
            return View(orderDetails);

        }
        public ActionResult GiveFeedback(int id)
        {
            Orders order = new Orders();
            order.OrderId = id;
            WebApiClient.BaseAddress = new Uri("http://localhost:50756/api/values/getrestid");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("getrestid", order).Result;
            response.EnsureSuccessStatusCode();

            CartItem cartItem = response.Content.ReadAsAsync<CartItem>().Result;
            int restid = cartItem.RestId;
            ViewBag.id = restid;
            return View();
        }
        public ActionResult Save(int restid,string name,string comments, float rating)
        {
            TblReview tblReview = new TblReview();
            tblReview.CustomerName = name;
            tblReview.Comments = comments;
            tblReview.Rating = rating;
            tblReview.RestId = restid;
            tblReview.Email = User.Identity.Name;

            WebApiClient.BaseAddress = new Uri("http://localhost:49819/api/values/Save");

            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.PostAsJsonAsync("Save", tblReview).Result;

            


            return RedirectToAction("YourOrders");
        }
        public ActionResult ViewReview()
        {
            HttpClient httpclient = new HttpClient();
            httpclient.BaseAddress = new Uri("http://localhost:49819/api/values/ViewReview");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = WebApiClient.GetAsync("ViewReview").Result;
            List<TblReview> reviews = response.Content.ReadAsAsync<List<TblReview>>().Result;

            return View(reviews);
        }




    }
}

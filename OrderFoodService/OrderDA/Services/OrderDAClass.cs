//using OrderFoodService.Models;
using Microsoft.AspNetCore.Rewrite.Internal.IISUrlRewrite;
using OrderFoodService.Models;
using OrderFoodService.OrderDA.Repositories;
using Remotion.Linq.Parsing.Structure.IntermediateModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OrderFoodService.OrderDA.Services
{
    public class OrderDAClass : IOrderDAClass
    {
        OrderDbContext orderDb = new OrderDbContext();
        public void AddedToCart(CartItem cartItems)
        {
            orderDb.CartItem.Add(cartItems);
            orderDb.SaveChanges();
        }

        public List<CartItem> CartDetails(CartItem cartItem)
        {

            List<CartItem> cartItems = orderDb.CartItem.Where(i => i.UserEmail == cartItem.UserEmail && i.Status == null).ToList();
            return cartItems;
        }

        public void Delete(CartItem cartItem)
        {
            CartItem items = orderDb.CartItem.Find(cartItem.CartId);
            orderDb.CartItem.Remove(items);
            orderDb.SaveChanges();

            

            
        }

        public void ConfirmOrder(Orders orders)
        {
            List<Orders> ordersList = orderDb.Orders.Where(s => s.Email == orders.Email).ToList();
            Orders res = ordersList.LastOrDefault();
            Orders ress = orderDb.Orders.Find(res.OrderId);
            ress.Status = "Order Placed";
            
            orderDb.SaveChanges();
            List<CartItem> items = orderDb.CartItem.ToList();
            
            
            foreach(CartItem j in items)
            {
                if((j.UserEmail == orders.Email) && (j.Status == null))
                {
                    j.OrderId = res.OrderId;
                    j.Status = "yes";
                    orderDb.SaveChanges();
                }
                else
                {
                    j.Status = "No";
                    orderDb.SaveChanges();

                }
            }

            
        }

        public void PlaceOrder(Orders order)
        {
            orderDb.Add(order);
            orderDb.SaveChanges();
        }

        public int Proceed(CartItem cartItem)
        {
            int sum = 0;
            List<CartItem> cartItems = orderDb.CartItem.Where(i => i.UserEmail == cartItem.UserEmail && i.Status == null).ToList();
            foreach(var i in cartItems)
            {
               
                sum = sum +((i.Units)*(i.Price));
                
            }
            return sum;
        }

        public List<OrderDetails> OrderDetails(Orders details)
        {
            List<Orders> ordersList = orderDb.Orders.Where(s => s.Email == details.Email).ToList();
            List<CartItem> cartItems = orderDb.CartItem.Where(i => i.UserEmail == details.Email ).ToList();

            List<OrderDetails> res = new List<OrderDetails>();
            foreach(Orders i in ordersList)
            {
                foreach(CartItem j in cartItems)
                {
                    if(i.Email == j.UserEmail)
                    {
                        OrderDetails orderDetails = new OrderDetails();
                        
                        orderDetails.OrderId = i.OrderId;
                        orderDetails.FoodName = j.FoodName;
                        orderDetails.Units = j.Units;
                        orderDetails.TotalPrice = i.TotalPrice;
                        orderDetails.Status = i.Status;
                        orderDetails.CustomerName = i.CustomerName;
                        orderDetails.ContactNo = i.ContactNo;
                        orderDetails.Address = i.Address;
                        orderDetails.Email = i.Email;
                        orderDetails.OrderDate = i.OrderDate;
                        res.Add(orderDetails);
                    }
                   
                }
            }
            return res;

        }
       

        public CartItem getrestid(Orders orders)
        {
            CartItem cartItem = orderDb.CartItem.Where(s => s.OrderId == orders.OrderId).FirstOrDefault();
            return cartItem;
        }
    }
}

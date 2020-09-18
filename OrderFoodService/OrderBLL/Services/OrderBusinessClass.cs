//using OrderFoodService.Models;
using OrderFoodService.Models;
using OrderFoodService.OrderBLL.Repositories;
using OrderFoodService.OrderDA.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace OrderFoodService.OrderBLL.Services
{
    public class OrderBusinessClass : IOrderBusinessClass
    {
        private readonly IOrderDAClass _orderDAClass;
        public OrderBusinessClass(IOrderDAClass orderDAClass)
        {
            _orderDAClass = orderDAClass;

        }

        public void AddedToCart(CartItem cartItems)
        {
            _orderDAClass.AddedToCart(cartItems);
        }

        public List<CartItem> CartDetails(CartItem cartItem)
        {
            return _orderDAClass.CartDetails(cartItem);
        }

      

        public void Delete(CartItem cartItem)
        {
            _orderDAClass.Delete(cartItem);
        }

        public void ConfirmOrder(Orders orders)
        {
            _orderDAClass.ConfirmOrder(orders);
        }

        public void PlaceOrder(Orders order)
        {
            _orderDAClass.PlaceOrder(order);
        }

        public int Proceed(CartItem cartItem)
        {
            return _orderDAClass.Proceed(cartItem);
        }

        public List<OrderDetails> OrderDetails(Orders details)
        {
            return _orderDAClass.OrderDetails(details);
        }

        public CartItem getrestid(Orders order)
        {
            return _orderDAClass.getrestid(order);
        }
    }

       
    }


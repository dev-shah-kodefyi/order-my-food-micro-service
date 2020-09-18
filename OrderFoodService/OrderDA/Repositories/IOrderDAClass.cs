//using OrderFoodService.Models;
using OrderFoodService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFoodService.OrderDA.Repositories
{
    public interface IOrderDAClass
    {
        void AddedToCart(CartItem cartItems);
        List<CartItem> CartDetails(CartItem cartItem);
        void Delete(CartItem cartItem);
        int Proceed(CartItem cartItem);
        void PlaceOrder(Orders order);
        void ConfirmOrder(Orders orders);
        List<OrderDetails> OrderDetails(Orders details);
        CartItem getrestid(Orders orders);
    }
}

//using OrderFoodService.Models;
using OrderFoodService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderFoodService.OrderBLL.Repositories
{
    public interface IOrderBusinessClass
    {
        void AddedToCart(CartItem cartItems);
        List<CartItem> CartDetails(CartItem cartItem);
        void Delete(CartItem cartItem);
        int Proceed(CartItem cartItem);
        void ConfirmOrder(Orders order);
        void PlaceOrder(Orders orders);
        List<OrderDetails> OrderDetails(Orders details);
        CartItem getrestid(Orders order);
    }
}

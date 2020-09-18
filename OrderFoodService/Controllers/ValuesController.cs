using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderFoodService.Models;
//using OrderFoodService.Models;
using OrderFoodService.OrderBLL.Repositories;

namespace OrderFoodService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IOrderBusinessClass _orderBusinessClass;

        public ValuesController(IOrderBusinessClass orderBusinessClass)
        {
            _orderBusinessClass = orderBusinessClass;
        }
        [HttpPost]
        [Route("AddedToCart")]
        public ActionResult AddedToCart(CartItem cartItems)
        {
            _orderBusinessClass.AddedToCart(cartItems);
            return Ok();
        }

        [Route("CartDetails")]
        public ActionResult CartDetails(CartItem cartItem)
        {
            List<CartItem> cartItems = _orderBusinessClass.CartDetails(cartItem);
            return Ok(cartItems);
        }
        [Route("Delete")]
        public ActionResult Delete(CartItem cartItem)
        {
            _orderBusinessClass.Delete(cartItem);
            return Ok();
        }
        [Route("Proceed")]
        public ActionResult Proceed(CartItem cartItem)
        {
            int totalprice = _orderBusinessClass.Proceed(cartItem);
            return Ok(totalprice);

        }
        [Route("ConfirmOrder")]

        public ActionResult ConfirmOrder(Orders order)
        {
            _orderBusinessClass.ConfirmOrder(order);
            return Ok();
        }
        [Route("PlaceOrder")]
        public ActionResult PlaceOrder(Orders orders)
        {
            _orderBusinessClass.PlaceOrder(orders);
            return Ok();

        }
        [Route("OrderDetails")]
        public ActionResult OrderDetails(Orders details)
        {
            List<OrderDetails> orderdetails = _orderBusinessClass.OrderDetails(details);
            return Ok(orderdetails);

        }
        [Route("getrestid")]
        public ActionResult getrestid(Orders order)
        {
            CartItem cart = _orderBusinessClass.getrestid(order);
            return Ok(cart);
        } 
}
}

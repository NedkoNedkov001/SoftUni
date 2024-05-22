using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Controllers
{
    public class CartsController : Controller
    {
        private readonly ICartService cartService;
        public CartsController(
            Request request,
            ICartService _cartService)
            : base(request)
        {
            cartService = _cartService;
        }

        [Authorize]
        public Response Details()
        {
            var products = cartService.GetProducts(User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = true
            });
        }

        [Authorize]
        public Response AddProduct(string productId)
        {

            IEnumerable<CartViewModel> products = cartService.AddProductToUser(productId, User.Id);

            return View(new
            {
                products = products,
                IsAuthenticated = true

            }, "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            (bool productsBought, string error) = cartService.BuyProducts(User.Id);

            if (!productsBought)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }
            return Redirect("/");

        }
    }
}

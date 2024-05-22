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
        private readonly IProductService productService;
        public CartsController(
            Request request,
            ICartService _cartService,
            IProductService _productService)
            : base(request)
        {
            this.cartService = _cartService;
            this.productService = _productService;
        }

        [Authorize]
        public Response Details()
        {
            IEnumerable<CartViewModel> products = cartService.GetUserProducts(User.Id);

            return View(new
            {
                User.IsAuthenticated,
                products = products
            });
        }

        [Authorize]
        public Response AddProduct(string productId)
        {
            (bool isAdded, string errors) = cartService.ValidateUserAndProduct(productId, User.Id);

            if (!isAdded)
            {
                return View(new { ErrorMessage = errors }, "/Error");
            }

            cartService.AddProductToUser(productId, User.Id);

            var products = cartService.GetUserProducts(User.Id);

            return View(new
            {
                User.IsAuthenticated,
                products = products
            },
                "/Carts/Details");
        }

        [Authorize]
        public Response Buy()
        {
            (bool isBought, string error) = cartService.ValidatePurchase(User.Id);

            if (!isBought)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            try
            {
                cartService.BuyProducts(User.Id);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error." }, "/Error");
            }

            return Redirect("/");
        }

    }
}

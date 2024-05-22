using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SMS.Contracts;
using SMS.Models;
using System.Collections.Generic;

namespace SMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        public HomeController(
            Request request,
            IProductService _productService,
            IUserService _userService)
            : base(request)
        {
            this.productService = _productService;
            this.userService = _userService;
        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                ICollection<ProductListViewModel> products = productService.GetAllProducts();

                string username = userService.GetUsername(User.Id);

                return View(new
                {
                    IsAuthenticated = true,
                    products = products,
                    Username = username
                }, "/Home/IndexLoggedIn");
            }
            return this.View(new { User.IsAuthenticated });
        }
    }
}
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
    public class ProductsController : Controller
    {
        private readonly IProductService productService;
        public ProductsController(
            Request request,
            IProductService _productService) 
            : base(request)
        {
            this.productService = _productService;
        }

        [Authorize]
        public Response Create()
        {
            return View(new { User.IsAuthenticated });
        }

        [Authorize]
        [HttpPost]
        public Response Create(CreateProductViewModel model)
        {
            (bool isValid, string errors) = productService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { ErrorMessage = errors }, "/Error");
            }

            try
            {
                productService.RegisterProduct(model);

            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error." }, "/Error");
            }

            return Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public Response Add(string productId)
        {
            return View(new { User.IsAuthenticated }, "/Carts/Details");
        }
    }
}

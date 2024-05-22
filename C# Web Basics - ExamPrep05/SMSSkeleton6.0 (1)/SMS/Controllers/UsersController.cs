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
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(
            Request request,
            IUserService _userService) 
            : base(request)
        {
            userService = _userService;
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { User.IsAuthenticated });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            string userId = userService.Login(model);

            if (userId == null)
            {
                return View(new { ErrorMessage = "Incorrect credentials." }, "/Error");
            }

            SignIn(userId);

            return Redirect("/");
        }

        public Response Register()

        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }

            return View(new { User.IsAuthenticated });
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool isValid, string error) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            try
            {
                userService.Register(model);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error." }, "/Error");
            }
            return Redirect("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            if (User.IsAuthenticated)
            {
                SignOut();
            }

            return Redirect("/");
        }
    }
}

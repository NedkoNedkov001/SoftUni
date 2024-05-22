using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
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
            return View();
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            string userId = userService.Login(model);

            if (userId == null)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Could not log in") }, "/Error");
            }

            SignIn(userId);
            return Redirect("/Trips/All");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            var (isValid, errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                userService.Register(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("UnexpectedError") }, "/Error");
            }
            return Redirect("/Users/Login");
        }

        [Authorize]
        public Response LogOut()
        {
            if (User.IsAuthenticated)
            {
                SignOut();
            }
            return Redirect("/");
        }
    }
}

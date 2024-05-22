using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
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
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            string id = userService.Login(model);

            if (id == null)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Could not log in")}, "/Error");
            }

            SignIn(id);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                 Request.Session.Id);

            return Redirect("/Trips/All");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Trips/All");
            }
            return View();
        }

        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool isValid, List<ErrorViewModel> errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error.") }, "/Error");
            }

            return Redirect("/Users/Login");
        }
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

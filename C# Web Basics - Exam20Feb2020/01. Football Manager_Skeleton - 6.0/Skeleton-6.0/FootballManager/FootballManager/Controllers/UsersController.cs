using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Controllers
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
            return View(new
            {
                IsAuthenticated = User.IsAuthenticated
            });
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            Request.Session.Clear();

            string id = null;
            try
            {
                id = userService.Login(model);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error." }, "/Error");
            }

            if (id == null)
            {
                return View(new { ErrorMessage = "Incorrect Login." }, "/Error");
            }

            SignIn(id);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return Redirect("/");
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View(new
            {
                IsAuthenticated = User.IsAuthenticated
            });
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
                userService.RegisterUser(model);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Could not register user. Try again." }, "/Error");
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

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
            this.userService = _userService;
        }

        public Response Login()
        {
            if (!User.IsAuthenticated)
            {
                return View(new { User.IsAuthenticated });
            }

            return Redirect("/");
        }

        [HttpPost]
        public Response Login(LoginViewModel model)
        {
            string userId = userService.LogIn(model);

            if (userId == null)
            {
                return View(new { User.IsAuthenticated });
            }

            SignIn(userId);

            CookieCollection cookies = new CookieCollection();
            cookies.Add(Session.SessionCookieName,
                Request.Session.Id);

            return Redirect("/");
        }

        public Response Register()
        {
            if (!User.IsAuthenticated)
            {
                return View(new { User.IsAuthenticated });
            }

            return Redirect("/");
        }


        [HttpPost]
        public Response Register(RegisterViewModel model)
        {
            (bool isValid, string errors) = userService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { ErrorMessage = errors }, "/Error");
            }

            try
            {
                userService.RegisterUser(model);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error!" }, "/Error");
            }

            return Redirect("/Users/Login");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");   
        }
    }
}

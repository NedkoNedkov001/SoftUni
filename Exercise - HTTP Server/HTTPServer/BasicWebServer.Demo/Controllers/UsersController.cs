using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.Forms;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Demo.Controllers
{
    public class UsersController : Controller
    {
        public UsersController(Request request)
            : base(request)
        {
        }

        public Response Login() => View();

        public Response LogInUser()
        {
            this.Request.Session.Clear();

            var usernameMatches =
                this.Request.Form["Username"] == LoginForm.Username;
            var passwordMatches =
                this.Request.Form["Password"] == LoginForm.Password;

            if (usernameMatches && passwordMatches)
            {
                if (!this.Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    var cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName,
                        this.Request.Session.Id);

                    return Html("<h3>Logged in!</h3>");
                }

                return Html("<h3>Logged in!</h3>");
            }
            return Redirect("/Login");
        }

        public Response Logout()
        {
            this.Request.Session.Clear();

            return Html("Logged out!");
        }

        public Response GetUserData()
        {
            if (this.Request.Session.ContainsKey(Session.SessionUserKey))
            {
                return Html($"<h3>Currently logged-in user is " +
                    $"with username '{LoginForm.Username}'</h3>");
            }

            return Redirect("/Login");
        }
    }
}

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
    public class PlayersController : Controller
    {
        private readonly IPlayerService playerService;
        public PlayersController(
            Request request,
            IPlayerService _playerService)
            : base(request)
        {
            playerService = _playerService;
        }

        public Response Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            return View(new
            {
                IsAuthenticated = User.IsAuthenticated
            });
        }

        [HttpPost]
        public Response Add(PlayerAddViewModel model)
        {

            (bool isValid, string error) = playerService.ValidateModel(model);

            if (!isValid)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            try
            {
                playerService.AddPlayer(model, User.Id);
            }
            catch (Exception)
            {

                return View(new { ErrorMessage = "Could not add player. Please, try again." }, "/Error");
            }

            return Redirect("/");
        }

        public Response Collection()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            IEnumerable<PlayerListViewModel> players = playerService.GetUserPlayers(User.Id);
            return View(new
            {
                players = players,
                IsAuthenticated = User.IsAuthenticated
            });
        }

        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            IEnumerable<PlayerListViewModel> players = playerService.GetAllPlayers();
            return View(new
            {
                players = players,
                IsAuthenticated = User.IsAuthenticated
            });
        }

        public Response AddToCollection(string playerId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            (bool isAdded, string error) = playerService.ValidateAdd(playerId, User.Id);

            if (!isAdded)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }

            try
            {
                playerService.AddPlayerToUser(playerId, User.Id);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error. Try again." }, "/Error");
            }
            return Redirect("/Players/All");
        }

        public Response RemoveFromCollection(string playerId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/Users/Login");
            }

            (bool isRemoved, string error) = playerService.ValidateRemove(playerId, User.Id);

            if (!isRemoved)
            {
                return View(new { ErrorMessage = error }, "/Error");
            }
            try
            {
                playerService.RemovePlayerFromUser(playerId, User.Id);
            }
            catch (Exception)
            {
                return View(new { ErrorMessage = "Unexpected error. Try again." }, "/Error");
            }
            return Redirect("/Players/Collection");
        }
    }
}

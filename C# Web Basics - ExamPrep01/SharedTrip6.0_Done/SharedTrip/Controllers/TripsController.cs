using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using SharedTrip.Contracts;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller

    {
        private readonly ITripService tripService;
        public TripsController(
            Request request,
            ITripService _tripService) 
            : base(request)
        {
            this.tripService = _tripService;
        }

        [Authorize]
        public Response Add()
        {
            if (User.IsAuthenticated)
            {
                return View();
            }
            return Redirect("/");
        }

        [Authorize]
        [HttpPost]
        public Response Add(TripViewModel model)
        {
            var (isValid, errors) = tripService.ValidateModel(model);

            if (!isValid)
            {
                return View(errors, "/Error");
            }

            try
            {
                tripService.AddTrip(model);
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("UnexpectedError") }, "/Error");
            }
            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response Details(string tripId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }

            TripDetailsViewModel model = tripService.GetTripDetails(tripId);

            return View(model);

        }

        [Authorize]
        public Response AddUserToTrip(string tripId)
        {
            try
            {
                tripService.AddUserToTrip(tripId, User.Id);
            }
            catch (ArgumentException aex)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel(aex.Message) }, "/Error");
            }
            catch (InvalidOperationException ioex)
            {
                return Redirect("/Trips/All");
            }
            catch (Exception)
            {
                return View(new List<ErrorViewModel>() { new ErrorViewModel("Unexpected error") }, "/Error");
            }
            return Redirect("/Trips/All");
        }

        [Authorize]
        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }

            IEnumerable<TripListViewModel> trips = tripService.GetAllTrips();

            return View(trips);
        }
    }
}

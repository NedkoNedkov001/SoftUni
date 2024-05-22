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

        public Response All()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }
            IEnumerable<TripListViewModel> trips = tripService.GetTrips();

            return View(trips);
        }

        public Response Details(string tripId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }
            TripDetailsViewModel trip = tripService.GetDetails(tripId);
            return View(trip);
        }

        public Response AddUserToTrip(string tripId)
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }

            try
            {
                tripService.AddUserToTrip(tripId, User.Id);
            }
            catch (Exception ex)
            {
                return View(new List<ErrorViewModel> { new ErrorViewModel(ex.Message) }, "/Error");
            }
            return Redirect("/Trips/All");
        }
        public Response Add()
        {
            if (!User.IsAuthenticated)
            {
                return Redirect("/");
            }
            return View();
        }

        [HttpPost]
        public Response Add(TripAddViewModel model)
        {
            (bool isValid, IEnumerable<ErrorViewModel> errors) = tripService.ValidateModel(model);

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
                return View(new List<ErrorViewModel> { new ErrorViewModel("Unexpected error ") }, "/Error");
            }

            return Redirect("/Trips/All");
        }
    }
}

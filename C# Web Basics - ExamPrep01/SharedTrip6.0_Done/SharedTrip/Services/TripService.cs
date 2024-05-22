using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class TripService : ITripService
    {
        private readonly IRepository repo;
        public TripService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public void AddTrip(TripViewModel model)
        {
            List<UserTrip> userTrips = new List<UserTrip>();
            DateTime departureTime;
            DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out departureTime);

            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = departureTime,
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
                UserTrips = userTrips,
            };

            repo.Add(trip);
            repo.SaveChanges();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            var user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);
            var trip = repo.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip not found");
            }

            if (repo.All<UserTrip>()
                .Where(u => u.UserId == userId)
                .Any(t => t.TripId == tripId))
            {
                throw new InvalidOperationException();
            }
            
            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                UserId = userId,
                Trip = trip,
                User = user
            });

            repo.SaveChanges();
        }

        public IEnumerable<TripListViewModel> GetAllTrips()
        {
            return repo.All<Trip>()
                .Select(t => new TripListViewModel()
                {
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    EndPoint = t.EndPoint,
                    Id = t.Id,
                    Seats = t.Seats,
                    StartPoint = t.StartPoint
                });
        }

        public TripDetailsViewModel GetTripDetails(string tripId)
        {
            return repo.All<Trip>()
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                    Description = t.Description,
                    ImagePath = t.ImagePath,
                })
                .FirstOrDefault();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (string.IsNullOrWhiteSpace(model.StartPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Start point is required"));
            }
            if (string.IsNullOrWhiteSpace(model.EndPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("End point is required"));
            }

            if (model.Seats < 2 ||
                model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6"));
            }
            if (model.Description == null ||
                model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and must be under 80 characters"));
            }

            DateTime date;
            if (!DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None, out date))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Departure time required"));
            }

            return (isValid, errors);
        }
    }
}

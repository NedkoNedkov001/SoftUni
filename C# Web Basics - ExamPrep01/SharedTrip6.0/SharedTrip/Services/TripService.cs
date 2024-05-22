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

        public IEnumerable<TripListViewModel> GetTrips()
        {
            return repo.All<Trip>()
                .Select(t => new TripListViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats = t.Seats,
                });
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripAddViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (model.StartPoint == null)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Start point is required."));
            }

            if (string.IsNullOrEmpty(model.EndPoint))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("End point is required."));
            }

            if (model.Seats < 2 || model.Seats > 6)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Seats must be between 2 and 6."));
            }

            if (string.IsNullOrEmpty(model.Description) ||
                model.Description.Length > 80)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Description is required and must be under 80 characters."));
            }

            DateTime date;
            if (!DateTime.TryParseExact(
                model.DepartureTime,
                "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Departure time is required and must be in the 'dd.MM.yyyy HH:mm' format."));
            }

            return (isValid, errors);
        }

        private static DateTime GetDateFromString(string dateString)
        {
            DateTime date;
            DateTime.TryParseExact(dateString, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            return date;
        }

        public void AddTrip(TripAddViewModel model)
        {
            Trip trip = new Trip()
            {
                StartPoint = model.StartPoint,
                EndPoint = model.EndPoint,
                DepartureTime = (DateTime)GetDateFromString(model.DepartureTime),
                Seats = model.Seats,
                Description = model.Description,
                ImagePath = model.ImagePath,
            };

            repo.Add(trip);
            repo.SaveChanges();
        }

        public TripDetailsViewModel GetDetails(string tripId)
        {
            return repo.All<Trip>()
                .Where(t => t.Id == tripId)
                .Select(t => new TripDetailsViewModel()
                {
                    Id = t.Id,
                    StartPoint = t.StartPoint,
                    EndPoint = t.EndPoint,
                    DepartureTime = t.DepartureTime.ToString("dd.MM.yyyy HH:mm"),
                    Seats=t.Seats,
                    ImagePath=t.ImagePath,
                    Description=t.Description,
                })
                .FirstOrDefault();
        }

        public void AddUserToTrip(string tripId, string userId)
        {
            User user = repo.All<User>()
                .FirstOrDefault(u => u.Id == userId);
            Trip trip = repo.All<Trip>()
                .FirstOrDefault(t => t.Id == tripId);

            if (repo.All<UserTrip>()
                .Where(ut => ut.User == user)
                .Any(ut => ut.Trip == trip))
            {
                throw new ArgumentException($"User ({user.Username}) already added to trip ({trip.StartPoint}-{trip.EndPoint} on {trip.DepartureTime}).");
            }

            if (user == null || trip == null)
            {
                throw new ArgumentException("User or trip does not exist.");
            }

            user.UserTrips.Add(new UserTrip()
            {
                TripId = tripId,
                Trip = trip,
                UserId = userId,
                User = user
            });

            repo.SaveChanges();
        }
    }
}

using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface ITripService
    {
        IEnumerable<TripListViewModel> GetTrips();
        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(TripAddViewModel model);
        void AddTrip(TripAddViewModel model);
        TripDetailsViewModel GetDetails(string tripId);
        void AddUserToTrip(string tripId, string userId);
    }
}

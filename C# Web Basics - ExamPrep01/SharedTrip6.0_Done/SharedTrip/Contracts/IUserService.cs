using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Contracts
{
    public interface IUserService
    {
        void Register(RegisterViewModel model);

        string CalculateHash(string password);

        string Login(LoginViewModel model);

        string GetUsername(string userId);

        (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);
    }
}

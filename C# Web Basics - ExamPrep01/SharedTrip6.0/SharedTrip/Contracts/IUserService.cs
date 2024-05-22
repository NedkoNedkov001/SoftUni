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
        string Login(Models.LoginViewModel model);
        (bool isValid, List<ErrorViewModel> errors) ValidateModel(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
    }
}

using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        (bool isValid, string error) ValidateModel(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
        string Login(LoginViewModel model);

        string GetUsername(string userId);
    }
}

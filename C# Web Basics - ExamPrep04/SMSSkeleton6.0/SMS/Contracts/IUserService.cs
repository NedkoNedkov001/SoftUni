using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IUserService
    {
        (bool isValid, string errors) ValidateModel(RegisterViewModel model);
        void RegisterUser(RegisterViewModel model);
        string LogIn(LoginViewModel model);
        string GetUsername(string id);
    }
}

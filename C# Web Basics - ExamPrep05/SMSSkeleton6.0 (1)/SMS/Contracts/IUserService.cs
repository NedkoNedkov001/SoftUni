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
        (bool isValid, string error) ValidateModel(RegisterViewModel model);
        void Register(RegisterViewModel model);
        string Login(LoginViewModel model);
        string GetUsername(string userId);
    }
}

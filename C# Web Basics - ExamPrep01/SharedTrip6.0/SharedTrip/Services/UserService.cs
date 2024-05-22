using SharedTrip.Contracts;
using SharedTrip.Data.Common;
using SharedTrip.Data.Models;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        public UserService(
            IRepository _repo)
        {
            repo = _repo;
        }


        public string Login(LoginViewModel model)
        {
            return repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == CalculateHash(model.Password))
                .FirstOrDefault()?.Id;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                Password = CalculateHash(model.Password),
                Email = model.Email,
            };

            repo.Add(user);
            repo.SaveChanges();
        }

        public (bool isValid, List<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (repo.All<User>()
                .Any(u => u.Username == model.Username) ||
                repo.All<User>()
                .Any(u => u.Email == model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username or email is taken."));

                return (isValid, errors);
            }

            if (model.Username == null ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username must be between 5 and 20 characters."));
            }
            
            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required."));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password must be between 5 and 20 characters."));
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and Confirm password must be the same."));
            }
                
            return (isValid, errors);
        }

        private string CalculateHash(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }
    }
}

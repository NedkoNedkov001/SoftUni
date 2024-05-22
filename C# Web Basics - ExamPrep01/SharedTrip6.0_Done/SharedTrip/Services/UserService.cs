using BasicWebServer.Server.Attributes;
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

        public string CalculateHash(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .Where(u => u.Id == userId)
                .FirstOrDefault().Username;
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == CalculateHash(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public void Register(RegisterViewModel model)
        {
            List<UserTrip> userTrips = new List<UserTrip>();

            User user = new User()
            {
                Username = model.Username,
                Password = CalculateHash(model.Password),
                Email = model.Email,
                UserTrips = userTrips
            };

            repo.Add(user);
            repo.SaveChanges();
        }

        public (bool isValid, IEnumerable<ErrorViewModel> errors) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            List<ErrorViewModel> errors = new List<ErrorViewModel>();

            if (repo.All<User>()
                .Any(u => u.Username == model.Username) ||
                repo.All<User>()
                .Any(u => u.Email == model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username or Email is already taken"));

                return (isValid, errors);
            }

            if (model.Username == null ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Username must be between 5 and 20 characters"));
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Email is required"));
            }

            if (model.Password == null ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password must be between 6 and 20 characters"));
            }

            if (model.ConfirmPassword != model.Password)
            {
                isValid = false;
                errors.Add(new ErrorViewModel("Password and ConfirmPassword must be the same"));
            }

            return (isValid, errors);
        }


    }
}

using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        public UserService(IRepository _repo)
        {
            repo = _repo;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = HashPassword(model.Password)
            };

            repo.Add(user);
            repo.SaveChanges();
        }
        private string HashPassword(string password)
        {
            byte[] passwordArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passwordArray));
            }
        }

        public (bool isValid, string error) ValidateModel(RegisterViewModel model)
        {
            bool isValid = true;
            StringBuilder errors = new StringBuilder();

            if (repo.All<User>()
                .Any(u => u.Username == model.Username) ||
                repo.All<User>()
                .Any(u => u.Email == model.Email))
            {
                isValid = false;
                errors.AppendLine("Username or email is already taken.");

                return (isValid, errors.ToString());
            }

            if (string.IsNullOrWhiteSpace(model.Username) ||
                model.Username.Length < 5 ||
                model.Username.Length > 20)
            {
                isValid = false;
                errors.AppendLine("Username must be between 5 and 20 characters.");
            }

            if (string.IsNullOrWhiteSpace(model.Email) ||
                model.Email.Length < 10 ||
                model.Email.Length > 60)
            {
                isValid = false;
                errors.AppendLine("Email must be between 10 and 60 characters.");
            }

            if (string.IsNullOrWhiteSpace(model.Password) ||
                model.Password.Length < 5 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.AppendLine("Password must be between 5 and 20 characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.AppendLine("Password and Confirm password must be the same.");
            }

            return (isValid, errors.ToString());
        }

        public string Login(LoginViewModel model)
        {
            var user = repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == HashPassword(model.Password))
                .SingleOrDefault();

            return user?.Id;
        }

        public string GetUsername(string userId)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == userId)?.Username;
        }
    }
}

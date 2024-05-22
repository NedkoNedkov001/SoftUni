using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repo;
        public UserService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public void RegisterUser(RegisterViewModel model)
        {
            Cart cart = new Cart();
            

            User user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = CalculateHash(model.Password),
                Cart = cart,
                CartId = cart.Id
            };

            repo.Add(user);
            repo.SaveChanges();
        }

        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }

        public (bool isValid, string errors) ValidateModel(RegisterViewModel model)
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
                errors.AppendLine("Username must be between 5 and 20 characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                isValid = false;
                errors.AppendLine("Email must be valid.");
            }

            if (string.IsNullOrWhiteSpace(model.Password) ||
                model.Password.Length < 6 ||
                model.Password.Length > 20)
            {
                isValid = false;
                errors.AppendLine("Password must be between 6 and 20 characters.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                isValid = false;
                errors.AppendLine("Password and Confirm password must be the same.");
            }

            return (isValid, errors.ToString());

        }

        public string LogIn(LoginViewModel model)
        {
            return repo.All<User>()
                .Where(u => u.Username == model.Username)
                .Where(u => u.Password == CalculateHash(model.Password))
                .FirstOrDefault()?.Id;
        }

        public string GetUsername(string id)
        {
            return repo.All<User>()
                .FirstOrDefault(u => u.Id == id)?.Username;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository repo;
        public CartService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public (bool isAdded, string errors) ValidateUserAndProduct(string productId, string userId)
        {
            bool isAdded = true;
            StringBuilder errors = new StringBuilder();

            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();
            Product product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                isAdded = false;
                errors.AppendLine("Invalid product.");
            }
            if (user == null)
            {
                isAdded = false;
                errors.AppendLine("Invalid user.");
            }
            if (user.Cart.Products.Any(p => p.Id == productId))
            {
                isAdded = false;
                errors.AppendLine("User already has product in cart.");
            }

            return (isAdded, errors.ToString());
        }

        public void AddProductToUser(string productId, string userId)
        {
            User user = repo.All<User>()
                   .Where(u => u.Id == userId)
                   .Include(u => u.Cart)
                   .ThenInclude(c => c.Products)
                   .FirstOrDefault();
            Product product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Products.Add(product);
            repo.SaveChanges();
        }

        public IEnumerable<CartViewModel> GetUserProducts(string userId)
        {
            User user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            return user
                .Cart
                .Products
                .Select(p => new CartViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                })
                .ToList();
        }

        public (bool isBought, string error) ValidatePurchase(string userId)
        {
            bool isBought = true;
            StringBuilder errors = new StringBuilder();

            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            if (user == null)
            {
                isBought = false;
                errors.AppendLine("Invalid user.");
            }
            if (!user.Cart.Products.Any())
            {
                isBought = false;
                errors.AppendLine("No items to buy.");
            }

            return (isBought, errors.ToString());
        }

        public void BuyProducts(string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            user.Cart.Products.Clear();

            repo.SaveChanges();
        }
    }
}

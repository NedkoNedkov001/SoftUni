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

        public IEnumerable<CartViewModel> AddProductToUser(string productId, string userId)
        {
            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            var product = repo.All<Product>()
                .FirstOrDefault(p => p.Id == productId);

            user.Cart.Products.Add(product);

            try
            {
                repo.SaveChanges();
            }
            catch (Exception)
            {
            }

            return user
                .Cart
                .Products
                .Select(p => new CartViewModel()
                {
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

        public (bool, string) BuyProducts(string userId)
        {
            bool productsBought = true;
            string error = null;

            var user = repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.Cart)
                .ThenInclude(c => c.Products)
                .FirstOrDefault();

            if (user == null)
            {
                productsBought = false;
                error = "User not found.";
            }
            else if (!user.Cart.Products.Any())
            {
                productsBought = false;
                error = "Cart is empty.";
            }
            else
            {
                try
                {
                    user.Cart.Products.Clear();

                    repo.SaveChanges();
                }
                catch (Exception)
                {
                    productsBought = false;
                    error = "Unexpected error.";
                }
            }
            return (productsBought, error);
        }

        IEnumerable<CartViewModel> ICartService.GetProducts(string userId)
        {
            var user = repo.All<User>()
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
                });
        }
    }
}

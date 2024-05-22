using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface ICartService
    {
        (bool isAdded, string errors) ValidateUserAndProduct(string productId, string userId);
        void AddProductToUser(string productId, string userId);
        IEnumerable<CartViewModel> GetUserProducts(string userId);
        (bool isBought, string error) ValidatePurchase(string userId);
        void BuyProducts(string userId);
    }
}

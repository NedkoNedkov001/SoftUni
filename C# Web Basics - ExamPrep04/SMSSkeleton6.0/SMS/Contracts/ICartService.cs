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
        IEnumerable<CartViewModel> GetProducts(string userId);
        IEnumerable<CartViewModel> AddProductToUser(string productId, string userId);
        (bool, string) BuyProducts(string userId);
    }
}

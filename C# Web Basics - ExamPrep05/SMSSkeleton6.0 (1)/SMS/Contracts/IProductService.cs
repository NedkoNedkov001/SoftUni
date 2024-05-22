using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Contracts
{
    public interface IProductService
    {
        ICollection<ProductListViewModel> GetAllProducts();
        (bool isValid, string errors) ValidateModel(CreateProductViewModel model);
        void RegisterProduct(CreateProductViewModel model);
    }
}

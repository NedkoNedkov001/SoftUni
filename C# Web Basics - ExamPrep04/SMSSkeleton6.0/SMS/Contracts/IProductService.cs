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
        (bool isValid, string errors) ValidateModel(ProductCreateViewModel model);
        void CreateProduct(ProductCreateViewModel model);
        IEnumerable<ProductListViewModel> GetProducts();
    }
}

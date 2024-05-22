using SMS.Contracts;
using SMS.Data.Common;
using SMS.Data.Models;
using SMS.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repo;
        public ProductService(
            IRepository _repo)
        {
            repo = _repo;
        }

        public void CreateProduct(ProductCreateViewModel model)
        {
            decimal price;
            decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price);

            Product product = new Product()
            {
                Name = model.Name,
                Price = price
            };

            repo.Add(product);
            repo.SaveChanges();
        }

        public IEnumerable<ProductListViewModel> GetProducts()
        {
            return repo.All<Product>()
                .Select(p => new ProductListViewModel()
                {
                    ProductId = p.Id,
                    ProductName = p.Name,
                    ProductPrice = p.Price.ToString("F2")
                });
        }

        public (bool isValid, string errors) ValidateModel(ProductCreateViewModel model)
        {
            bool isValid = true;
            StringBuilder errors = new StringBuilder();

            if (repo.All<Product>()
                .Any(p => p.Name == model.Name))
            {
                isValid = false;
                errors.AppendLine("Product already exists.");

                return (isValid, errors.ToString());
            }
            if (string.IsNullOrWhiteSpace(model.Name) ||
                model.Name.Length < 4 ||
                model.Name.Length > 20)
            {
                isValid = false;
                errors.AppendLine("Product name must be between 4 and 20 characters.");
            }

            decimal price = 0;
            if (!decimal.TryParse(model.Price, NumberStyles.Float, CultureInfo.InvariantCulture, out price) ||
                price < 0.05M ||
                price > 1000M)
            {
                isValid = false;
                errors.AppendLine("Product price must be between 0,05 and 1000");
            }

            return (isValid, errors.ToString());

        }
    }
}

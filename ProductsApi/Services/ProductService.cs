using Microsoft.Extensions.Logging;
using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        List<Product> products = new List<Product>();
        
        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public Task<string> AddProductAsync(Product product)
        {
            product.Id = Guid.NewGuid().ToString();
            //add product Note:Here replace with Repository 
            products.Add(product);
            return Task.FromResult(product.Id);
        }

        public Task<bool> DeleteProductAsync(string id)
        {

            var result = products.Remove(products.SingleOrDefault(p => p.Id==id));
            return Task.FromResult(result);
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            return Task.FromResult(products);
        }

        public Task<Product> GetProductAsync(string id)
        {
            var product = products.Where(p => p.Id == id).FirstOrDefault();
            return Task.FromResult(product);
        }

        public Task<List<Product>> GetProductsByTypeAsync(string type)
        {
            var result = products.Where(p=>p.Type==type).ToList();
            return Task.FromResult(result);
        }
    }
}

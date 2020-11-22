using ProductsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Services
{
    public interface IProductService
    {
        Task<string> AddProductAsync(Product product);
        Task<Product> GetProductAsync(string id);
        Task<List<Product>> GetProductsByTypeAsync(string type);
        Task<List<Product>> GetAllProductsAsync();
        Task<bool> DeleteProductAsync(string id);

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductsApi.Models;
using ProductsApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsApi.Controllers
{
    /// <summary>
    /// Products controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ProductController: ControllerBase
    {
        private readonly ILogger<ProductController> logger;
        private readonly IProductService _productService;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="productService"></param>
        public ProductController(ILogger<ProductController> logger,IProductService productService)
        {
            this._productService = productService;
        }

        /// <summary>
        /// Create Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateProductAsync([FromBody] Product product)
        {
            string result = await  _productService.AddProductAsync(product);
            return Created("",result);
        }

        /// <summary>
        /// Get products by product type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductsByTypeAsync([FromQuery] string type)
        {
            if (!Models.ProductTypes.TYPES.Contains(type))
            {
                return BadRequest("Invalid Product type");
            }
            var result = await _productService.GetProductsByTypeAsync(type);
            return Ok(result);
        }

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetProductByIdAsync(string id)
        {
            var result = await _productService.GetProductAsync(id);
            if(result == null)
            {
                return NotFound("Id not found");
            }
            return Ok(result);
        }

        /// <summary>
        /// Get All available products
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProductsAsync()
        {
            var result = await _productService.GetAllProductsAsync();
            return Ok(result);
        }

        /// <summary>
        /// Delete Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            var result = await _productService.DeleteProductAsync(id.ToString());
            if (!result)
            {
                return NotFound("Id not found");
            }
            return NoContent();
        }


    }
}

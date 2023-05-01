using Gaez.BakeryHouse.Domain.Models;
using Gaez.BakeryHouse.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gaez.BakeryHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        #region PROPERTIES
        private readonly ProductService productService;
        #endregion
        #region CONSTRUCTOR
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }
        #endregion
        #region METHODS
        [HttpGet("GetAllProducts")]
        public IEnumerable<ProductModel> GetAllProducts()
        {
            try
            {
                var response = productService.GetAllProducts();
                return response;
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("GetAllProductsOnlyNameAndProductCode")]
        public IEnumerable<ProductModel> GetAllProductsOnlyNameAndProductCode()
        {
            try
            {
                var response = productService.GetAllProductsOnlyNameAndProductCode();
                return response;
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("GetProductsFromLowerToHigherPrice")]
        public IEnumerable<ProductModel> GetProductsFromLowerToHigherPrice(int categoryId)
        {
            try
            {
                var response = productService.GetProductsFromLowerToHigherPrice(categoryId);
                return response;
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("GetProductsFromHigherToLowerPrice")]
        public IEnumerable<ProductModel> GetProductsFromHigherToLowerPrice(int categoryId)
        {
            try
            {
                var response = productService.GetProductsFromHigherToLowerPrice(categoryId);
                return response;
            }
            catch (Exception ex) { throw; }
        }

        [HttpGet("GetProductsByCategory")]
        public IEnumerable<ProductModel> GetProductsByCategory(int categoryId)
        {
            try
            {
                var response = productService.GetProductsByCategory(categoryId);
                return response;
            }
            catch (Exception ex) { throw; }
        }
        #endregion
    }
}

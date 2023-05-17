using Gaez.BakeryHouse.Data.Entities;
using Gaez.BakeryHouse.Domain.Models;
using Gaez.BakeryHouse.Domain.Services;
using Gaez.BakeryHouse.Utils;
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

        [HttpPost("PostLikeProduct")]
        public ReturnInfo PostLikeProduct(int clientId, int productCode)
        {
            try
            {
                ReturnInfo returnInfo = new ReturnInfo();
                returnInfo = productService.PostLikeProduct(clientId, productCode);
                return returnInfo;
            }
            catch(Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetAllFavoriteProducts")]
        public IEnumerable<ProductModel> GetAllFavoriteProducts(int clientId)
        {
            try
            {
                var response = productService.GetAllFavoriteProducts(clientId);
                return response;
            }
            catch(Exception)
            {
                throw;
            }
        }

        [HttpDelete("DeleteLikeProduct")]
        public ReturnInfo DeleteLikeProduct(int clientId, int productCode)
        {
            try
            {
                ReturnInfo returnInfo = new ReturnInfo();
                returnInfo = productService.DeleteLikeProduct(clientId, productCode);
                return returnInfo;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}

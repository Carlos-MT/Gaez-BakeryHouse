using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Services
{
    public class ProductService : BaseService
    {
        #region METHODS
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.GetAllProducts();
                return response;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<IEnumerable<ProductModel>> GetProductsFromLowerToHigherPrice(int categoryId)
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.GetProductsFromLowerToHigherPrice(categoryId);
                return response;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<IEnumerable<ProductModel>> GetProductsFromHigherToLowerPrice(int categoryId)
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.GetProductsFromHigherToLowerPrice(categoryId);
                return response;
            }
            catch (Exception ex) { throw; }
        }
        #endregion
    }
}

using Gaez.BakeryHouse.interfaces;
using Gaez.BakeryHouse.Interfaces;
using Gaez.BakeryHouse.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Services
{
    public class ProductService : BaseService
    {
        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.GetAllProducts();
                return response;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
        public async Task<IEnumerable<ProductModel>> GetProductsByCategory(int categoryId)
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.GetProductsByCategory(categoryId);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ReturnInfo> PostLikeProduct(int clientId, int productCode)
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.PostLikeProduct(clientId, productCode);
                return response;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<IEnumerable<ProductModel>> GetAllFavoriteProducts(int clientId)
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.GetAllFavoriteProducts(clientId);
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ReturnInfo> DeleteLikeProduct(int clientId, int productCode)
        {
            try
            {
                var apiResponse = RestService.For<IProductService>(httpClient);
                var response = await apiResponse.DeleteLikeProduct(clientId, productCode);
                return response;
            }
            catch (Exception ex) { throw; }
        }
    }
}

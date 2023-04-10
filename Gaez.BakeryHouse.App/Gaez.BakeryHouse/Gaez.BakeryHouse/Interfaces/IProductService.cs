using Gaez.BakeryHouse.API.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Interfaces
{
    public interface IProductService
    {
        [Get("/Product/GetAllProducts")]
        Task<IEnumerable<ProductModel>> GetAllProducts();

        [Get("/Product/GetProductsFromLowerToHigherPrice")]
        Task<IEnumerable<ProductModel>> GetProductsFromLowerToHigherPrice(int categoryId);

        [Get("/Product/GetProductsFromHigherToLowerPrice")]
        Task<IEnumerable<ProductModel>> GetProductsFromHigherToLowerPrice(int categoryId);
    }
}

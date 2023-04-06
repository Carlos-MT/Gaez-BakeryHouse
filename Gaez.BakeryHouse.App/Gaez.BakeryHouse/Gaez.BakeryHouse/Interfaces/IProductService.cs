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
        [Get("/GetAllProducts")]
        Task<IEnumerable<ProductModel>> GetAllProducts();

        [Get("/GetProductsFromLowerToHigherPrice")]
        Task<IEnumerable<ProductModel>> GetProductsFromLowerToHigherPrice(int categoryId);

        [Get("/GetProductsFromHigherToLowerPrice")]
        Task<IEnumerable<ProductModel>> GetProductsFromHigherToLowerPrice(int categoryId);
    }
}

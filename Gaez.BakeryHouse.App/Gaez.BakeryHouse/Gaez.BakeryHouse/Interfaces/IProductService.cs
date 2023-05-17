using Gaez.BakeryHouse.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.interfaces
{
    public interface IProductService
    {
        [Get("/Product/GetAllProducts")]
        Task<IEnumerable<ProductModel>> GetAllProducts();

        [Get("/Product/GetProductsByCategory")]
        Task<IEnumerable<ProductModel>> GetProductsByCategory(int categoryId);

        [Post("/Product/PostLikeProduct")]
        Task<ReturnInfo> PostLikeProduct(int clientId, int productCode);

        [Get("/Product/GetAllFavoriteProducts")]
        Task<IEnumerable<ProductModel>> GetAllFavoriteProducts(int clientId);

        [Delete("/Product/DeleteLikeProduct")]
        Task<ReturnInfo> DeleteLikeProduct(int clientId, int productCode);
    }
}

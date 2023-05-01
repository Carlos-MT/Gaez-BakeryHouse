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
    }
}

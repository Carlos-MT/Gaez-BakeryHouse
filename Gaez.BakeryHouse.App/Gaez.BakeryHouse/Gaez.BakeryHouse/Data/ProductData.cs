using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Data
{
    public static class ProductData
    {
        public static IList<ProductModel> Products { get; private set; }
        private static readonly ProductService productService;

        static ProductData()
        {
            Products = new List<ProductModel>();
            productService = new ProductService();
        }

        public static async Task LoadData()
        {
            Products.Clear();
            ((List<ProductModel>)Products).AddRange(await productService.GetAllProducts());
        }

    }
}

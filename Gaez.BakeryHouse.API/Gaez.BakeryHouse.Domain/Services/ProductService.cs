using Gaez.BakeryHouse.Data.Entities;
using Gaez.BakeryHouse.Data.Repositories;
using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Domain.Services
{
    public class ProductService
    {
        #region PROPERTIES
        private readonly GaezDbContext context;
        private readonly GenericRepository<Product> productsRepo;
        private readonly GenericRepository<ProductBelongsToCategory> pbtCategoryRepo;
        #endregion
        #region CONSTRUCTOR
        public ProductService(GaezDbContext context)
        {
            this.context = context;
            productsRepo = new GenericRepository<Product>(context);
            pbtCategoryRepo = new GenericRepository<ProductBelongsToCategory>(context);
        }
        #endregion
        #region METHODS
        public IEnumerable<ProductModel> GetAllProducts()
        {
            try
            {
                var query = from t1 in productsRepo.GetAll()
                            select new ProductModel()
                            {
                                ProductCode = t1.ProductCode,
                                ProductName = t1.ProductName,
                                ProductImage = t1.ProductImage,
                                Application = t1.Application,
                                Description = t1.Description,
                                ExpirityDate = t1.ExpirityDate,
                                RegularPrice = t1.RegularPrice,
                                Stock = t1.Stock,
                                Valuation = t1.Valuation
                            };

                return query;
            }
            catch (Exception ex) { throw; }
        }
        public IEnumerable<ProductModel> GetProductsFromLowerToHigherPrice(int categoryId)
        {
            try
            {
                var query = from t1 in productsRepo.GetAll()
                            join t2 in pbtCategoryRepo.GetAll()
                            on t1.ProductCode equals t2.ProductCode
                            where t2.CategoryId == categoryId
                            orderby t1.RegularPrice ascending
                            select new ProductModel()
                            {
                                ProductCode = t1.ProductCode,
                                ProductName = t1.ProductName,
                                ProductImage = t1.ProductImage,
                                Application = t1.Application,
                                Description = t1.Description,
                                ExpirityDate = t1.ExpirityDate,
                                RegularPrice = t1.RegularPrice,
                                Stock = t1.Stock,
                                Valuation = t1.Valuation
                            };

                return query;
            }
            catch (Exception ex) { throw; }
        }
        public IEnumerable<ProductModel> GetProductsFromHigherToLowerPrice(int categoryId)
        {
            try
            {
                var query = from t1 in productsRepo.GetAll()
                            join t2 in pbtCategoryRepo.GetAll()
                            on t1.ProductCode equals t2.ProductCode
                            where t2.CategoryId == categoryId
                            orderby t1.RegularPrice descending
                            select new ProductModel()
                            {
                                ProductCode = t1.ProductCode,
                                ProductName = t1.ProductName,
                                ProductImage = t1.ProductImage,
                                Application = t1.Application,
                                Description = t1.Description,
                                ExpirityDate = t1.ExpirityDate,
                                RegularPrice = t1.RegularPrice,
                                Stock = t1.Stock,
                                Valuation = t1.Valuation
                            };

                return query;
            }
            catch (Exception ex) { throw; }
        }
        #endregion
    }
}

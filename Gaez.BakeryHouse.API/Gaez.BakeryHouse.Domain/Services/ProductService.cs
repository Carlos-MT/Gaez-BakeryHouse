using Gaez.BakeryHouse.Data.Entities;
using Gaez.BakeryHouse.Data.Repositories;
using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gaez.BakeryHouse.Utils;

namespace Gaez.BakeryHouse.Domain.Services
{
    public class ProductService
    {
        #region PROPERTIES
        private readonly GaezDbContext context;
        private readonly GenericRepository<Product> productsRepo;
        private readonly GenericRepository<ClientLikesProduct> clientLikesProductRepo;
        private readonly GenericRepository<ProductBelongsToCategory> pbtCategoryRepo;
        #endregion
        #region CONSTRUCTOR
        public ProductService(GaezDbContext context)
        {
            this.context = context;
            productsRepo = new GenericRepository<Product>(context);
            clientLikesProductRepo = new GenericRepository<ClientLikesProduct>();
            pbtCategoryRepo = new GenericRepository<ProductBelongsToCategory>(context);
        }
        #endregion
        #region METHODS
        public IEnumerable<ProductModel> GetAllProducts()
        {
            try
            {
                var query = from t1 in productsRepo.GetAll()
                            orderby t1.ProductName ascending
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
        public IEnumerable<ProductModel> GetProductsByCategory(int categoryId)
        {
            try
            {
                var query = from t1 in productsRepo.GetAll()
                            join t2 in pbtCategoryRepo.GetAll()
                            on t1.ProductCode equals t2.ProductCode
                            where t2.CategoryId == categoryId
                            select new ProductModel()
                            {
                                ProductCode = t1.ProductCode,
                                ProductName = t1.ProductName,
                                RegularPrice = t1.RegularPrice,
                                Valuation = t1.Valuation,
                                Application = t1.Application,
                                Description = t1.Description,
                                Stock = t1.Stock
                            };

                return query;
            }
            catch(Exception ex) { throw; }
        }
        public ReturnInfo PostLikeProduct(int clientId, int productCode)
        {
            ReturnInfo returnInfo = new ReturnInfo();
            try
            {
                // 1. Se crean los objetos
                var entity = new ClientLikesProduct
                {
                    ClientId = clientId,
                    ProductCode = productCode
                };

                bool exist = clientLikesProductRepo.GetAll().Any(l => l.ClientId == clientId && l.ProductCode == productCode);

                if(!exist)
                {
                    clientLikesProductRepo.Insert(entity);
                    clientLikesProductRepo.Save();
                }
               
            }
            catch (Exception ex)
            {
                returnInfo.Message = ex.Message;
                returnInfo.Result = ResultCode.Error;
                throw;
            }

            returnInfo.Message = "Operación realizada con exito";
            return returnInfo;
        }
        public ReturnInfo DeleteLikeProduct(int clientId, int productCode)
        {
            ReturnInfo returnInfo = new ReturnInfo();
            try
            {
                var x = clientLikesProductRepo.GetById(clientId, productCode);

                if(x != null)
                {
                    clientLikesProductRepo.Delete(clientId, productCode);
                    clientLikesProductRepo.Save();
                }

            }
            catch (Exception ex)
            {
                returnInfo.Message = ex.Message;
                returnInfo.Result = ResultCode.Error;
                throw;
            }

            returnInfo.Message = "Operación realizada con exito";
            return returnInfo;
        }
        public IEnumerable<ProductModel> GetAllFavoriteProducts(int clientId)
        {
            try
            {
                var query = from t1 in clientLikesProductRepo.GetAll()
                            join t2 in productsRepo.GetAll()
                            on t1.ProductCode equals t2.ProductCode
                            where t1.ClientId == clientId
                            select new ProductModel()
                            {
                                ProductCode = t1.ProductCode,
                                ProductName = t2.ProductName,
                                ProductImage = t2.ProductImage,
                                Application = t2.Application,
                                Description = t2.Description,
                                ExpirityDate = t2.ExpirityDate,
                                RegularPrice = t2.RegularPrice,
                                Stock = t2.Stock,
                                Valuation = t2.Valuation
                            };


                return query;
            }
            catch (Exception ex) { throw; }
        }
        #endregion
    }
}

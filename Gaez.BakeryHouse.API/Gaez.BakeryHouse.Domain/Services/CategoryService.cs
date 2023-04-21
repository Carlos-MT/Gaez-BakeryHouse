using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Data.Entities;
using Gaez.BakeryHouse.Data.Repositories;
using Gaez.BakeryHouse.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Domain.Services
{
    public class CategoryService
    {
        #region PROPERTIES
        private readonly GaezDbContext context;
        private readonly GenericRepository<Category> categoriesRepo;
        #endregion
        #region CONSTRUCTOR
        public CategoryService(GaezDbContext context)
        {
            this.context = context;
            categoriesRepo = new GenericRepository<Category>(context);
        }
        #endregion
        #region METHODS
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            try
            {
                var query = from t1 in categoriesRepo.GetAll()
                            orderby t1.CategoryName ascending
                            select new CategoryModel()
                            {
                                CategoryId = t1.CategoryId,
                                CategoryName = t1.CategoryName
                            };
                return query;
            }
            catch(Exception ex) { throw; }
        }
        #endregion
    }
}

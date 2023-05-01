using Gaez.BakeryHouse.interfaces;
using Gaez.BakeryHouse.Interfaces;
using Gaez.BakeryHouse.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Services
{
    public class CategoryService : BaseService
    {
        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            try
            {
                var apiResponse = RestService.For<ICategoryService>(httpClient);
                var response = await apiResponse.GetAllCategories();
                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

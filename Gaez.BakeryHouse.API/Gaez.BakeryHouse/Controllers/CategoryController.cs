using Gaez.BakeryHouse.Domain.Models;
using Gaez.BakeryHouse.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gaez.BakeryHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region PROPERTIES
        private readonly CategoryService categoryService;
        #endregion
        #region CONSTRUCTOR
        public CategoryController(CategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        #endregion
        #region METHODS
        [HttpGet("GetAllCategories")]
        public IEnumerable<CategoryModel> GetAllCategories()
        {
            try
            {
                var response = categoryService.GetAllCategories();
                return response;
            }
            catch(Exception ex) { throw; }
        }
        #endregion
    }
}

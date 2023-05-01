using Gaez.BakeryHouse.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Interfaces
{
    public interface ICategoryService
    {
        [Get("/Category/GetAllCategories")]
        Task<IEnumerable<CategoryModel>> GetAllCategories();
    }
}

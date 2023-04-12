using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Services
{
    public class CommentService : BaseService
    {
        #region METHODS
        public async Task<ReturnInfo> PostComment(CommentModel comment, int clientId, int productCode)
        {
            try
            {
                var apiResponse = RestService.For<ICommentService>(httpClient);
                var response = await apiResponse.PostComment(comment, clientId, productCode);
                return response;
            }
            catch (Exception ex) { throw; }
        }
        public async Task<IEnumerable<CommentModel>> GetAllCommentsForProduct(int productCode)
        {
            try
            {
                var apiResponse = RestService.For<ICommentService>(httpClient);
                var response = await apiResponse.GetAllCommentsForProduct(productCode);
                return response;
            }
            catch (Exception ex)
            { 
                throw; 
            }
        }
        #endregion
    }
}

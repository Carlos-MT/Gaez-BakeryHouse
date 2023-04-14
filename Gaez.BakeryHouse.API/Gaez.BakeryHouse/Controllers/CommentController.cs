using Gaez.BakeryHouse.Domain.Models;
using Gaez.BakeryHouse.Domain.Services;
using Gaez.BakeryHouse.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Gaez.BakeryHouse.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentController : ControllerBase
    {
        #region PROPERTIES
        private readonly CommentService commentService;
        #endregion
        #region CONSTRUCTOR
        public CommentController(CommentService commentService)
        {
            this.commentService = commentService;
        }
        #endregion
        #region METHODS
        [HttpPost("PostComment")]
        public ReturnInfo PostComment(CommentModel comment, int clientId, int productCode)
        {
            ReturnInfo returnInfo = new ReturnInfo();
            returnInfo = commentService.PostComment(comment, clientId, productCode);
            return returnInfo;
        }

        [HttpGet("GetAllCommentsForProduct")]
        public IEnumerable<CommentModel> GetAllCommentsForProduct(int productCode)
        {
            try
            {
                var reponse = commentService.GetAllCommentsForProduct(productCode);
                return reponse;
            }
            catch (Exception ex) 
            {
                throw;
            }
        }
        #endregion
    }
}

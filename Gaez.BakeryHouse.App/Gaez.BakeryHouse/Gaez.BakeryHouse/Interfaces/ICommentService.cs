using Gaez.BakeryHouse.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gaez.BakeryHouse.Interfaces
{
    public interface ICommentService
    {
        [Post("/Comment/PostComment")]
        Task<ReturnInfo> PostComment(CommentModel comment, int clientId, int productCode);

        [Get("/Comment/GetAllCommentsForProduct")]
        Task<IEnumerable<CommentModel>> GetAllCommentsForProduct(int productCode);
    }
}

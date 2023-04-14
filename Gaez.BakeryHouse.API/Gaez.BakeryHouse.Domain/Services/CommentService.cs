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
    public class CommentService
    {
        #region PROPERTIES
        private readonly GaezDbContext context;
        private readonly GenericRepository<Comment> commentsRepo;
        private readonly GenericRepository<ClientMakesComment> clientCommentsRepo;
        private readonly GenericRepository<ProductHasComment> productHasCommentRepo;
        private readonly GenericRepository<Client> clientRepo;
        #endregion
        #region CONSTRUCTOR
        public CommentService(GaezDbContext context)
        {
            this.context = context;
            commentsRepo = new GenericRepository<Comment>(context);
            clientCommentsRepo = new GenericRepository<ClientMakesComment>(context);
            productHasCommentRepo = new GenericRepository<ProductHasComment>(context);
            clientRepo = new GenericRepository<Client>(context);
        }
        #endregion
        #region METHODS
        public ReturnInfo PostComment(CommentModel comment, int clientId, int productCode)
        {
            ReturnInfo returnInfo = new ReturnInfo();
            try
            {
                // 1. Se crean los objetos
                var entity = new Comment
                {
                    CommentDate = comment.CommentDate,
                    Description = comment.Description,
                    Valoration = comment.Valoration
                };
                commentsRepo.Insert(entity);
                commentsRepo.Save();

                var clientMakeComment = new ClientMakesComment()
                {
                    ClientId = clientId,
                    CommentId = entity.CommentId
                };
                clientCommentsRepo.Insert(clientMakeComment);
                clientCommentsRepo.Save();

                var productHasComment = new ProductHasComment()
                {
                    ProductCode = productCode,
                    CommentId = entity.CommentId
                };
                productHasCommentRepo.Insert(productHasComment);
                productHasCommentRepo.Save();
            }
            catch (Exception ex) 
            {
                returnInfo.Message = ex.Message;
                returnInfo.Result = ResultCode.Error;
                throw;
            }

            returnInfo.Message = "Comentario realizado con exíto";
            return returnInfo;
        }
        public IEnumerable<CommentModel> GetAllCommentsForProduct(int productCode)
        {
            try
            {
                var query = from t1 in commentsRepo.GetAll()
                            join t2 in clientCommentsRepo.GetAll()
                            on t1.CommentId equals t2.CommentId
                            join t3 in productHasCommentRepo.GetAll()
                            on t1.CommentId equals t3.CommentId
                            join t4 in clientRepo.GetAll()
                            on t2.ClientId equals t4.ClientId
                            where t3.ProductCode == productCode
                            orderby t1.CommentDate descending
                            select new CommentModel()
                            {
                                CommentId = t1.CommentId,
                                CommentDate = t1.CommentDate,
                                Description = t1.Description,
                                Valoration = t1.Valoration,
                                FirstName = t4.FirstName,
                                FatherLastName = t4.FatherLastName,
                                MotherLastName = t4.MotherLastName,
                            };
                return query;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public IEnumerable<CommentModel> GetOnlyThreeCommentsForProduct(int productCode)
        {
            try
            {
                var query = (from t1 in commentsRepo.GetAll()
                            join t2 in clientCommentsRepo.GetAll()
                            on t1.CommentId equals t2.CommentId
                            join t3 in productHasCommentRepo.GetAll()
                            on t1.CommentId equals t3.CommentId
                            join t4 in clientRepo.GetAll()
                            on t2.ClientId equals t4.ClientId
                            where t3.ProductCode == productCode
                            orderby t1.CommentDate descending
                            select new CommentModel()
                            {
                                CommentId = t1.CommentId,
                                CommentDate = t1.CommentDate,
                                Description = t1.Description,
                                Valoration = t1.Valoration,
                                FirstName = t4.FirstName,
                                FatherLastName = t4.FatherLastName,
                                MotherLastName = t4.MotherLastName
                            }).Take(3);

                return query;
            }
            catch (Exception e)
            {
                throw;
            }
        }
        #endregion
    }
}

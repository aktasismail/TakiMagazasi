using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusiness.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }
        public void TAdd(Comment entity)
        {
            _commentDal.Add(entity);
        }
        public void TDelete(Comment entity)
        {
            _commentDal.Delete(entity);
        }

        public Comment TGetByID(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> TGetListAll()
        {
            return _commentDal.GetAll();
        }
        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
    }
}

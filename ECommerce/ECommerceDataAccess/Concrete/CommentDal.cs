using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Data;
using ECommerceEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDataAccess.Concrete
{
    public class CommentDal : Repository<Comment>, ICommentDal
    {
        public CommentDal(AppDbContext context) : base(context)
        {
        }
    }
}

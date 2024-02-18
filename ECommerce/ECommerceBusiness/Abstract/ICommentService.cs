using ECommerceDataAccess.Migrations;
using ECommerceEntities;
using ECommerceEntities.Dto.CreateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceBusiness.Abstract
{
    public interface ICommentService : IRepositoryService<Comment>
    {
        Task Add(CommentCreateDto commentCreateDto);
    }
}

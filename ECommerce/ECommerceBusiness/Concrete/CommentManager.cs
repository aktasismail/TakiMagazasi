using AutoMapper;
using ECommerceBusiness.Abstract;
using ECommerceDataAccess.Abstract;
using ECommerceDataAccess.Migrations;
using ECommerceEntities;
using ECommerceEntities.Dto.CreateDto;
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
        private readonly IMapper _mapper;
        public CommentManager(ICommentDal commentDal, IMapper mapper)
        {
            _commentDal = commentDal;
            _mapper = mapper;
        }
        public async Task Add(CommentCreateDto commentCreateDto)
        {
            if (commentCreateDto == null)
            {
                throw new ArgumentNullException();
            }
            Comment yorum = _mapper.Map<Comment>(commentCreateDto);
            await _commentDal.Add(yorum);
        }
        public async Task TAdd(Comment entity)
        {
           await _commentDal.Add(entity);
        }
        public async Task TDelete(Comment entity)
        {
            await _commentDal.Delete(entity);
        }

        public async Task<Comment> TGetByID(int id)
        {
            return await _commentDal.GetById(id);
        }

        public async Task<List<Comment>> TGetListAll()
        {
            return await _commentDal.GetAll();
        }
        public async Task TUpdate(Comment entity)
        {
            await _commentDal.Update(entity);
        }
    }
}

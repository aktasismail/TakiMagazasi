using ECommerceBusiness.Abstract;
using ECommerceEntities;
using ECommerceEntities.Dto;
using ECommerceEntities.Dto.CreateDto;
using ECommerceEntities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ECommerceWebApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpPost]
        public IActionResult AddComment(CommentCreateDto CommentCreateDto)
        {
            Comment commment = new Comment()
            {
                FullName = CommentCreateDto.FullName,
                Text = CommentCreateDto.Text,
                ProductId = CommentCreateDto.ProductId,
                UserId = CommentCreateDto.UserId,
            };
            _commentService.TAdd(commment);
            return Ok("Eklendi");
        }
    }
}

using System;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crud_assignment_m2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommentsController : ControllerBase
    {
        private readonly ILogger<CommentsController> _logger;
        private readonly IComment _commentService;

        public CommentsController(ILogger<CommentsController> logger, IComment commentService)
        {
            _logger = logger;
            _commentService = commentService;
        }

        [Authorize]
        [HttpGet("GetAllComments")]
        public Task<IEnumerable<CommentModel>> Get()
        {
            return _commentService.GetAllComments();

        }

        [Authorize]
        [HttpGet("getComment/{commentId}")]
        public Task<CommentModel> GetPost([FromRoute] int commentId)
        {
            return _commentService.GetComment(commentId);
        }

        [Authorize]
        [HttpPost("addNewComment")]
        public Task<bool> AddNewComment([FromBody] CommentModel commentModel)
        {
            return _commentService.AddNewComment(commentModel);
        }

        [Authorize]
        [HttpPatch("updatecomment/{commentId}")]
        public Task<CommentModel> UpdatePost([FromRoute] int commentId, [FromBody] UpdateCommentModel commentModel)
        {
            return _commentService.UpdateComment(commentId, commentModel);
        }

        [Authorize]
        [HttpDelete("deleteComment/{commentId}")]
        public Task<CommentModel> DeletePost([FromRoute] int commentId)
        {
            return _commentService.DeleteComment(commentId);
        }
    }
}


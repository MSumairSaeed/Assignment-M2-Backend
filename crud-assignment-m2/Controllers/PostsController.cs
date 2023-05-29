using System;
using crud_assignment_m2.Interfaces;
using crud_assignment_m2.models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace crud_assignment_m2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostsController: ControllerBase
	{
        private readonly ILogger<PostsController> _logger;
        private readonly IPost _postService;

        public PostsController(ILogger<PostsController> logger, IPost postService)
        {
            _logger = logger;
            _postService = postService;
        }

        [Authorize]
        [HttpGet("GetAllPosts")]
        public Task<dynamic> Get()
        {
            return _postService.GetAllPosts();

        }

        [Authorize]
        [HttpGet("getPost/{postId}")]
        public Task<dynamic> GetPost([FromRoute] int postId)
        {
            return _postService.GetPost(postId);
        }

        [Authorize]
        [HttpPost("addNewPost")]
        public Task<bool> AddNewPost([FromBody] PostModel PostModel)
        {
            return _postService.AddNewPost(PostModel);
        }

        [Authorize]
        [HttpPatch("updatePost/{postId}")]
        public Task<PostModel> UpdatePost([FromRoute] int postId, [FromBody] UpdatePostModel PostModel)
        {
            return _postService.UpdatePost(postId, PostModel);
        }

        [Authorize]
        [HttpDelete("deletePost/{postId}")]
        public Task<PostModel> DeletePost([FromRoute] int postId)
        {
            return _postService.DeletePost(postId);
        }
    }
}


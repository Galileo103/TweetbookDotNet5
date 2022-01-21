using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TweetbookDotNet5.Contracts;
using TweetbookDotNet5.Controllers.V1.Requests;
using TweetbookDotNet5.Controllers.V1.Responses;
using TweetbookDotNet5.Domain;
using TweetbookDotNet5.Services;

namespace TweetbookDotNet5.Controllers.V1
{
    public class PostsController : Controller
    {
        private IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_postService.GetPosts());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public IActionResult Get([FromRoute] Guid postId)
        {
            var post = _postService.GetPostById(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };

            if (post.Id != Guid.Empty)
            {
                post.Id = Guid.NewGuid();
            }

            _postService.GetPosts().Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUrl = $"{baseUrl}/{ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString())}";

            var response = new PostRespons { Id = post.Id };
            return Created(locationUrl, response);
        }
    }
}

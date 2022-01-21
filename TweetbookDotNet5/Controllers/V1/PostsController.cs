using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TweetbookDotNet5.Contracts;
using TweetbookDotNet5.Controllers.V1.Requests;
using TweetbookDotNet5.Controllers.V1.Responses;
using TweetbookDotNet5.Domain;

namespace TweetbookDotNet5.Controllers.V1
{
    public class PostsController : Controller
    {
        private List<Post> _posts;

        public PostsController()
        {
            _posts = new List<Post>();
            for (int i = 0; i < 5; i++)
            {
                _posts.Add(new Post { Id = Guid.NewGuid().ToString() });
            }
        }
        [HttpGet(ApiRoutes.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public IActionResult Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Id = postRequest.Id };

            if (string.IsNullOrEmpty(post.Id))
            {
                post.Id = Guid.NewGuid().ToString();
            }

            _posts.Add(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUrl = $"{baseUrl}/{ApiRoutes.Posts.Get.Replace("{postId}", post.Id)}";

            var response = new PostRespons { Id = post.Id };
            return Created(locationUrl, response);
        }
    }
}

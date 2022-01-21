using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        [HttpGet(ApiRoutes.Posts.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid postId)
        {
            var post = await _postService.GetPostByIdAsync(postId);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPut(ApiRoutes.Posts.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid postId, [FromBody] UpdatePostRequest postRequest)
        {
            var post = new Post
            {
                Id = postId,
                Name = postRequest.Name
            };

            var updated = await _postService.UpdatePostAsync(post);
            if (!updated)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpDelete(ApiRoutes.Posts.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid postId)
        {

            var deleted = await _postService.DeletePostAsync(postId);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost(ApiRoutes.Posts.Create)]
        public async Task<IActionResult> Create([FromBody] CreatePostRequest postRequest)
        {
            var post = new Post { Name = postRequest.Name };

            await _postService.CreatePostAsync(post);

            var baseUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";

            var locationUrl = $"{baseUrl}/{ApiRoutes.Posts.Get.Replace("{postId}", post.Id.ToString())}";

            var response = new PostRespons { Id = post.Id };
            return Created(locationUrl, response);
        }
    }
}

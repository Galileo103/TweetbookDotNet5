using System;
using System.Collections.Generic;
using TweetbookDotNet5.Domain;

namespace TweetbookDotNet5.Services
{
    public interface IPostService
    {
        List<Post> GetPosts();

        Post GetPostById(Guid postId);
    }
}

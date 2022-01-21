﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TweetbookDotNet5.Domain;

namespace TweetbookDotNet5.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPostsAsync();

        Task<Post> GetPostByIdAsync(Guid postId);

        Task<bool> CreatePostAsync(Post post);

        Task<bool> UpdatePostAsync(Post postToUpdate);

        Task<bool> DeletePostAsync(Guid postId);
    }
}

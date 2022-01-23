﻿using System.Threading.Tasks;
using TweetbookDotNet5.Domain;

namespace TweetbookDotNet5.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
    }
}

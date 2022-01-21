using System;
using System.ComponentModel.DataAnnotations;

namespace TweetbookDotNet5.Domain
{
    public class Post
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

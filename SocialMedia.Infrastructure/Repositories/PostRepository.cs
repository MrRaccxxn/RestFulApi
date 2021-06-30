using Microsoft.EntityFrameworkCore;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using SocialMedia.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _socialMediaContext;
        public PostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _socialMediaContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int postId)
        {
            return await _socialMediaContext.Posts.FirstAsync(post => post.PostId == postId);
        }

        public async Task InsertPost(Post post)
        {
            _socialMediaContext.Posts.Add(post);
            await _socialMediaContext.SaveChangesAsync();
        }
    }
}

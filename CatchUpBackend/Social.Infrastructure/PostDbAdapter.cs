using CatchUpBackend.Social.Core;
using CatchUpBackend.Social.Core.Ports.Outgoing;

namespace CatchUpBackend.Social.Infrastructure
{
    public class PostDbAdapter : IPostRepository
    {
        private readonly SocialDbContext _context;
        public PostDbAdapter(SocialDbContext context)
        {
            _context = context;
        }

        public Task AddPostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task DeletePostAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Post> GetPostByIdAsync(Guid postId)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePostAsync(Post post)
        {
            throw new NotImplementedException();
        }

        public Task UpvoteCommentAsync(Guid postId, Guid commentId)
        {
            throw new NotImplementedException();
        }

        //public async Task AddPostAsync(Post post)
        //{
        //    _context.Posts.Add(post);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task DeletePostAsync(Guid postId)
        //{
        //    var post = await _context.Posts.FindAsync(postId);
        //    if(post == null)
        //    {
        //       throw new InvalidOperationException(
        //           $"Post with Id: {postId} not found"
        //           );
        //    }
        //    _context.Posts.Remove(post);
        //    await _context.SaveChangesAsync();
        //}

        //public async Task<IEnumerable<Post>> GetAllPostsAsync()
        //{
        //    return await _context.Posts
        //        .Include(p => p.Comments)
        //        .ToListAsync();
        //}

        //public async Task<Post> GetPostByIdAsync(Guid postId)
        //{
        //    await _context.Posts.Include(p => p.Comments)
        //        .FirstOrDefaultAsync(p => p.Id == postId);
        //}

        //public Task UpvoteCommentAsync(Guid postId, Guid commentId)
        //{
        //    throw new NotImplementedException();
        //}

        //Task IPostRepository.UpdatePostAsync(Post post)
        //{
        //    _context.Posts.Update(post);
        //    await _context.SaveChangesAsync();
        //}
    }
}

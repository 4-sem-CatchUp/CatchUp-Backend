using CatchUpBackend.Social.Core.Ports.Incomming;
using CatchUpBackend.Social.Core.Ports.Outgoing;
using Microsoft.AspNetCore.Http.Connections;

namespace CatchUpBackend.Social.Core.Application
{
    public class PostService : IPostUseCases
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        
        public async Task<Guid> CreatePostAsync(Guid authorId, string title, string content)
        {
            var post = Post.CreateNewPost(authorId, title, content);
            await _postRepository.AddPostAsync(post);
            return post.Id;
        }
        public async Task AddComment(Guid postId, Guid authorId, string text)
        {
            var post = await _postRepository.GetPostByIdAsync(postId)
                ?? throw new InvalidOperationException("Post not found");

            post.AddComment(authorId, text);
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task VotePost(Guid postId, bool upVote)
        {
            var post = await _postRepository.GetPostByIdAsync(postId)
                ?? throw new InvalidOperationException("Post not found");
            if (upVote) { post.Upvotes++; }
            else { post.Downvotes++; }
            await _postRepository.UpdatePostAsync(post);
        }

        public async Task VoteComment(Guid postId, Guid commentId, bool upVote)
        {
            var post = await _postRepository.GetPostByIdAsync(postId)
                ?? throw new InvalidOperationException("Post not found");
            var comment = (await _postRepository.GetPostByIdAsync(postId))
                ?.Comments.FirstOrDefault(c => c.Id == commentId)
                ?? throw new InvalidOperationException("Comment not found");
        }
    }
}

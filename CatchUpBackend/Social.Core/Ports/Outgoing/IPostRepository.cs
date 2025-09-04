namespace CatchUpBackend.Social.Core.Ports.Outgoing
{
    public interface IPostRepository
    {
        Task<Post> GetPostByIdAsync(Guid postId);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task AddPostAsync(Post post);
        Task UpdatePostAsync(Post post);
        Task DeletePostAsync(Guid postId);
        Task UpvoteCommentAsync(Guid postId, Guid commentId);
    }
}

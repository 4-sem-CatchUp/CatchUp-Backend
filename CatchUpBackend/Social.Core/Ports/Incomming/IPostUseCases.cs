namespace CatchUpBackend.Social.Core.Ports.Incomming
{
    public interface IPostUseCases
    {
        Task<Guid> CreatePostAsync(Guid authorId, string title, string content);
        Task AddComment(Guid postId, Guid authorId, string text);
        public Task VotePost(Guid postId, bool upVote);
        public Task VoteComment(Guid postId, Guid commentId, bool upVote);
    }
}

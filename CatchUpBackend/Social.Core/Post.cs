using CatchUpBackend.Social.Core;
namespace CatchUpBackend.Social.Core
{
    public class Post
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid AuthorId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int Upvotes { get; set; }

        public int Downvotes { get; set; }
        public DateTime CreatedAt { get; set; }

        private readonly List<Comment> _comments;

        public IReadOnlyList<Comment> Comments => _comments.AsReadOnly();


        public Post() { }
        public Post(Guid authorId,
                    string title,
                    string content)
        {
            AuthorId = authorId;
            Title = title;
            Content = content;
        }

        public Post(Guid id,
                    Guid authorId,
                    string title,
                    string content,
                    int upvotes,
                    int downvotes,
                    DateTime createdAt,
                    List<Comment> comments)
        {
            Id = id;
            AuthorId = authorId;
            Title = title;
            Content = content;
            Upvotes = upvotes;
            Downvotes = downvotes;
            CreatedAt = createdAt;
            _comments = comments;
        }

        public static Post CreateNewPost(Guid authorId, string title, string content)
        {
            return new Post
            {
                AuthorId = authorId,
                Title = title,
                Content = content,
                Upvotes = 0,
                Downvotes = 0,
                CreatedAt = DateTime.UtcNow,
            };
        }
        public void AddComment(Guid authorId, string text) 
        {
            Comment.CreateNewComment(AuthorId, text);
        }
    }
}

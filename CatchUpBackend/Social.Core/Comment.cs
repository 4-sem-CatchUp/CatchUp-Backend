using System.ComponentModel.DataAnnotations;
namespace CatchUpBackend.Social.Core
{
	public class Comment
	{
		public Guid Id { get; private set; } = Guid.NewGuid();
		public Guid AuthorId { get; private set; }

		private string _content;

		public string Content
		{
			get { return _content; }
			set { _content = value; }
		}

		public DateTime Timestamp { get; set; } = DateTime.UtcNow;

		private int _upvote;

		public int Upvote
		{
			get { return _upvote; }
			set { _upvote = value; }
		}

		private int _downvote;

		public int Downvote
		{
			get { return _downvote; }
			set { _downvote = value; }
		}
		public Comment() { }
		public Comment(Guid authorId,
					string text,
					DateTime timeStamp,
					int upvote,
					int downvote)
		{
			AuthorId = authorId;
			Content = text;
			Timestamp = timeStamp;
			Upvote = upvote;
			Downvote = downvote;
		}

		public static Comment CreateNewComment(Guid authorId, string text)
		{
			return new Comment { AuthorId = authorId, Content = text };
		}

	}
}

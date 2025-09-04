namespace CatchUpBackend.Identity.Core
{
    public class User
    {
		public Guid Id { get; private set; } = Guid.NewGuid();
        private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		private string _mail;

		public string Mail
		{
			get { return _mail; }
			set { _mail = value; }
		}
		private DateOnly _doB;

		public DateOnly DoB
		{
			get { return _doB; }
			set { _doB = value; }
		}

	}
}

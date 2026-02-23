namespace Models
{
    public class Note : IModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public int Position { get; set; }
        public Group? Parent { get; set; }
    }
}

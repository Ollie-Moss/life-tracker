namespace Models
{
    public class Note : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public int Position { get; set; }
        public Guid ParentId { get; set; }
    }
}

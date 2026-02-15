namespace Models
{
    public class Group : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public int Position { get; set; }
        public Guid ParentId { get; set; }

        public List<Note> Notes { get; set; } = new();
        public List<Group> Children { get; set; } = new();
    }
}

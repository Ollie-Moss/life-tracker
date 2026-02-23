namespace Models
{
    public class Group : IModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public int Position { get; set; }
        public Group? Parent { get; set; }

        public List<Note> Notes { get; set; } = new();
        public List<Group> Children { get; set; } = new();
    }
}

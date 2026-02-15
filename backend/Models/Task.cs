namespace Models
{
    class Task : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public List<Note> Notes { get; set; } = new();
        public DateTime Date { get; set; }
        public uint DurationMinutes;
    }
}

namespace DataAccessLayer.Models
{
    public class Note : IDataModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public int Position { get; set; }
        public Group? Parent { get; set; }
        public List<CalendarTask> CalendarTasks { get; set; } = new();
    }
}

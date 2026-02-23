namespace DataAccessLayer.Models
{
    public class CalendarTask : IDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public List<Note> Notes { get; set; } = new();
        public DateTime Date { get; set; }
        public uint DurationMinutes;
    }
}

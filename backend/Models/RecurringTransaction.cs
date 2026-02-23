namespace Models
{
    public enum Frequency
    {
        Weekly,
        Fortnightly,
        Monthly,
        Yearly
    }

    public class RecurringTransaction : Transaction, IModel
    {
        public Frequency Frequency;
    }
}

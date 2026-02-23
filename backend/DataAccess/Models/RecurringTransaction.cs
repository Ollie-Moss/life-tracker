namespace DataAccessLayer.Models
{

    public class RecurringTransaction : Transaction, IDataModel
    {
        public Frequency Frequency;
    }
}

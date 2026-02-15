namespace Models
{
    public enum TransactionAccuracy
    {
        Expense,
        Exact
    }

    public class Transaction : IBusinessModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Value { get; set; }
        public decimal EstimateValue { get; set; }
        public TransactionAccuracy Accuracy { get; set; }
        public DateTime Date { get; set; }
    }
}

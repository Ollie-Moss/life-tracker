namespace DataAccessLayer.Models
{
    public class Transaction : IDataModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public decimal Value { get; set; }
        public decimal EstimateValue { get; set; }
        public Accuracy Accuracy { get; set; }
        public DateTime Date { get; set; }
    }
}

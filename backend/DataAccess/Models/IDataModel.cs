namespace DataAccessLayer.Models
{
    /// <summary>
    /// Represents a model with an PK Id.
    /// </summary>
    public interface IDataModel
    {
        public Guid Id { get; set; }
    }
}

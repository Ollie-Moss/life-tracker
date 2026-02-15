namespace Models
{
    /// <summary>
    /// Represents a business model with an PK Id.
    /// </summary>
    public interface IBusinessModel
    {
        public Guid Id { get; set; }
    }
}

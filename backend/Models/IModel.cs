namespace Models
{
    /// <summary>
    /// Represents a model with an PK Id.
    /// </summary>
    public interface IModel
    {
        public Guid Id { get; set; }
    }
}

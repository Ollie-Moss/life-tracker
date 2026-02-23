namespace DataAccessLayer.Models
{
    public class User : IDataModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public string PhoneNumber { get; set; } = "";
        public DateTime UpdatedAt { get; set; }
    }

}

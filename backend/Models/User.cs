namespace Models
{
    public class User : IModel
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

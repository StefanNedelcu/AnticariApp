namespace AnticariApp.Application.User
{
    public class User
    {
        public long IdUser { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserRole { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}

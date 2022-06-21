using System.ComponentModel.DataAnnotations;

namespace AnticariApp.Application.User
{
    public class UserSettings
    {
        public long IdUser { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string StreetName { get; set; }

        public int? StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public Statistics Statistics { get; set; }

        [Required]
        public IEnumerable<Author> PreferredAuthors { get; set; }

        [Required]
        public IEnumerable<Category> PreferredCategories { get; set; }

        public IEnumerable<Author> ExistingAuthors { get; set; }

        public IEnumerable<Category> ExistingCategories { get; set; }
    }
}

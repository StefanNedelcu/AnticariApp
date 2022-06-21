using System.ComponentModel.DataAnnotations;

namespace AnticariApp.Application.User
{
    public class UpdateUserSettingsRequest
    {
        public long IdUser { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string StreetName { get; set; }

        public int? StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public IEnumerable<Author> PreferredAuthors { get; set; } = new List<Author>();

        public IEnumerable<Category> PreferredCategories { get; set; } = new List<Category>();
    }
}

using AnticariApp.Data.Entities;

namespace AnticariApp.Application.User;

public static class UserHelper
{
    public static Address GetUserAddress(this TBUser user)
    {
        if (user == null)
        {
            return null;
        }
        var address = user.TBUserAddresses.First();

        return new Address
        {
            City = address.City,
            Country = address.Country,
            StreetName = address.StreetName,
            StreetNumber = address.StreetNumber,
            ZipCode = address.ZipCode,
        };
    }

    public static Statistics GetUserStatistics(this TBUser user)
    {
        if (user == null)
        {
            return null;
        }
        var statistics = user.TBUserStatistics.First();

        return new Statistics
        {
            AvgRating = statistics.UserAvgRating,
            ReadBooks = statistics.ReadBooks,
            SoldItems = statistics.SoldItems,
        };
    }

    public static Author ToAuthor(this TBAuthor author)
    {
        if (author == null)
        {
            return null;
        }

        return new Author
        {
            Id = author.IdAuthor,
            Name = author.AuthorName,
            Description = author.AuthorDescription,
        };
    }

    public static Category ToCategory(this TBCategory category)
    {
        if (category == null)
        {
            return null;
        }

        return new Category
        {
            Id = category.IdCategory,
            Name = category.CategoryName,
            Description = category.CategoryDescription,
        };
    }
}

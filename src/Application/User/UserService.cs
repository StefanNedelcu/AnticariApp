using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Data.Entities;
using AnticariApp.Utils.Enums;
using AnticariApp.Utils.Extensions;
using AnticariApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Application.User;

public interface IUserService
{
    public User GetUser(long userId);

    public Task<UserSettings> GetUserSettings(long userId);

    public Task UpdateUserSettings(UpdateUserSettingsRequest req); 

    public Task<long> Register(RegistrationRequest model);
}

public class UserService : DataService, IUserService
{
    private readonly MySqlContext _context;

    public UserService(MySqlContext context)
    {
        _context = context;
    }

    public User GetUser(long userId)
    {
        var user = _context.TBUsers
           .Where(u => u.IdUser == userId)
           .Include(u => u.TBUserAddresses)
           .Include(u => u.TBUserStatistics)
           .FirstOrDefault();

        var address = user.GetUserAddress();
        var statistics = user.GetUserStatistics();

        return new User
        {
            IdUser = user.IdUser,
            FirstName = user.FirstName,
            LastName = user.LastName,
            PhoneNumber = user.PhoneNumber,
            Address = address.ToString(),
            Statistics = statistics,
            Email = user.Email,
            CreatedAt = user.CreatedAt
        };
    }

    public async Task<UserSettings> GetUserSettings(long userId)
    {
        var user = await _context.TBUsers
           .Where(u => u.IdUser == userId)
           .Include(u => u.TBUserAddresses)
           .Include(u => u.TBUserStatistics)
           .FirstOrDefaultAsync();

        var existingAuthors = await _context
            .TBAuthors
            .Select(a => a.ToAuthor())
            .ToListAsync();
        var existingCategories = await _context
            .TBCategories
            .Select(c => c.ToCategory())
            .ToListAsync();
        var authorPreferences = await _context
            .TBUserAuthorPreferences
            .Where(c => c.IdUser == userId)
            .Include(c => c.Author)
            .Select(c => c.Author.ToAuthor())
            .ToListAsync();
        var categoryPreferences = await _context
            .TBUserCategoryPreferences
            .Where(c => c.IdUser == userId)
            .Include(c => c.Category)
            .Select(c => c.Category.ToCategory())
            .ToListAsync();
        var address = user.GetUserAddress();

        return new UserSettings
        {
            IdUser = user.IdUser,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            City = address.City,
            Country = address.Country,
            StreetName = address.StreetName,
            StreetNumber = address.StreetNumber,
            ZipCode = address.ZipCode,
            Statistics = user.GetUserStatistics(),
            PreferredAuthors = authorPreferences,
            PreferredCategories = categoryPreferences,
            ExistingAuthors = existingAuthors,
            ExistingCategories = existingCategories,
        };
    }

    public async Task UpdateUserSettings(UpdateUserSettingsRequest req)
    {
        var user = await _context.TBUsers
            .Where(u => u.IdUser == req.IdUser)
            .Include(u => u.TBUserAuthorPreferences)
            .Include(u => u.TBUserCategoryPreferences)
            .FirstAsync();
        var address = await _context.TBUserAddresses
            .Where(a => a.IdUser == req.IdUser)
            .Include(a => a.User)
            .FirstAsync();

        user.FirstName = req.FirstName;
        user.LastName = req.LastName;
        user.PhoneNumber = req.PhoneNumber;
        address.Country = req.Country;
        address.City = req.City;
        address.StreetNumber = req.StreetNumber;
        address.StreetName = req.StreetName;
        address.ZipCode = req.ZipCode;

        var currentAuthorPreferences = _context.TBUserAuthorPreferences
            .Where(p => p.IdUser == req.IdUser);
        var currentCategoryPreferences = _context.TBUserCategoryPreferences
            .Where(c => c.IdUser == req.IdUser);
        _context.TBUserAuthorPreferences.RemoveRange(currentAuthorPreferences);
        _context.TBUserCategoryPreferences.RemoveRange(currentCategoryPreferences);

        foreach(var author in req.PreferredAuthors)
        {
            _context.TBUserAuthorPreferences.Add(new TBUserAuthorPreference
            {
                IdAuthor = author.Id,
                IdUser = req.IdUser,
            });
        }

        foreach(var category in req.PreferredCategories)
        {
            _context.TBUserCategoryPreferences.Add(new TBUserCategoryPreference
            {
                IdCategory = category.Id,
                IdUser = req.IdUser,
            });
        }

        _context.SaveChanges();
    }

    public async Task<long> Register(RegistrationRequest model)
    {
        var existingUser = await _context.TBUsers
            .FirstOrDefaultAsync(u => u.Email == model.Email);
        if (existingUser != null)
        {
            return 0;
        }

        var newUser = new TBUser
        {
            Email = model.Email,
            Password = AuthenticationHelper.HashPassword(model.Password),
            FirstName = model.FirstName,
            LastName = model.LastName,
            PhoneNumber = model.PhoneNumber,
            UserRole = UserRole.Standard.AsInt(),
            CreatedAt = DateTime.Now,
        };

        _context.TBUsers.Add(newUser);
        _context.TBUserAddresses.Add(new TBUserAddress
        {
            User = newUser,
            City = "-",
            Country = "-",
            StreetName = "-",
            StreetNumber = 0,
            ZipCode = "-",
        });
        _context.TBUserStatistics.Add(new TBUserStatistic
        {
            User = newUser,
            ReadBooks = 0,
            SoldItems = 0,
            UserAvgRating = 0,
            UpdatedAt = DateTime.Now,
        });

        _context.SaveChanges();

        return newUser.IdUser;
    }
}

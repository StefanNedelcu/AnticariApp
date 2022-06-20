using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Data.Entities;
using AnticariApp.Utils.Enums;
using AnticariApp.Utils.Extensions;
using AnticariApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Application.User
{
    public interface IUserService
    {
        public Task<User> GetUser(long userId);

        public Task<long> Register(RegistrationRequest model);
    }

    public class UserService : DataService, IUserService
    {
        private readonly MySqlContext _context;

        public UserService(MySqlContext context)
        {
            _context = context;
        }

        public async Task<User> GetUser(long userId)
        {
            var user = await _context.TBUsers
               .Where(u => u.IdUser == userId)
               .Include(u => u.TBUserAddresses)
               .Include(u => u.TBUserStatistics)
               .FirstOrDefaultAsync();

            var address = GetUserAddress(user);
            var statistics = GetUserStatistics(user);

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
                UserRole = UserRoles.Standard.AsInt(),
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

        private static Address GetUserAddress(TBUser user)
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

        public static Statistics GetUserStatistics(TBUser user)
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
    }
}

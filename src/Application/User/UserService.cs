using AnticariApp.Application.Authentication;
using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Data.Entities;
using AnticariApp.Utils.Enums;
using AnticariApp.Utils.Exceptions;
using AnticariApp.Utils.Extensions;
using AnticariApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;

namespace AnticariApp.Application.User
{
    public interface IUserService
    {
        public IEnumerable<User> Index();

        public Task<long> Register(RegistrationRequest model);
    }

    public class UserService : DataService, IUserService
    {
        private readonly MySqlContext _context;

        public UserService(MySqlContext context)
        {
            _context = context;
        }

        public IEnumerable<User> Index()
        {
            return _context.TBUsers
                .Select(u => new User
                {
                    IdUser = u.IdUser,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    UserRole = u.UserRole,
                    CreatedAt = u.CreatedAt,
                });
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
                UserRole = UserRoles.Standard.AsInt(),
                CreatedAt = DateTime.UtcNow,
            };

            _context.TBUsers.Add(newUser);
            _context.SaveChanges();

            return newUser.IdUser;
        }
    }
}

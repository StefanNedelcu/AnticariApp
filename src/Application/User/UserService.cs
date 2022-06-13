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
        public IEnumerable<User> Index();

        public Task<long> Register(RegistrationRequest model);

        public Task<bool> Authenticate(AuthenticationRequest model);
    }

    public class UserService : DataService, IUserService
    {
        private readonly ACContext _context;

        public UserService(ACContext context)
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

        public async Task<bool> Authenticate(AuthenticationRequest model)
        {
            var user = await _context.TBUsers
                .Where(u => u.Email == model.Email)
                .FirstOrDefaultAsync();

            return AuthenticationHelper.IsValidPassword(model.Password, user.Password);
        }
    }
}

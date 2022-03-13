using ACEntities.Context;
using ACEntities.TableModels;
using ACServiceModels.Models;
using ACServiceModels.Models.Authentication;
using ACUtils.Extensions;

namespace ACDataServices.Services
{
    public interface IAuthenticationService
    {
        public long RegisterUser(UserRegistrationData data);
    }

    public class AuthenticationService : DataService, IAuthenticationService
    {
        private readonly ACContext _context;

        public AuthenticationService(ACContext context)
        {
            _context = context;
        }

        public long RegisterUser(UserRegistrationData data)
        {
            var existingUser = _context.TBUsers.FirstOrDefault(u => u.Email == data.Email);
            if (existingUser != null)
                return 0;

            var hashedPassword = new HashedItem(data.Password);

            var newUser = new TBUser
            {
                Email = data.Email,
                Salt = hashedPassword.Salt,
                Password = hashedPassword.HashedString,
                FirstName = data.FirstName,
                LastName = data.LastName,
                UserRole = UserRoles.Standard.AsInt(),
                CreatedAt = DateTime.UtcNow,
            };

            _context.TBUsers.Add(newUser);
            _context.SaveChanges();

            return newUser.IdUser;
        }
    }
}
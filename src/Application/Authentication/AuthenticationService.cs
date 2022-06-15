using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AnticariApp.Application.Authentication
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest model);
    }

    public class AuthService : DataService, IAuthService
    {
        private readonly MySqlContext _context;

        private readonly IConfiguration _configuration;

        public AuthService(MySqlContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponse> Login(LoginRequest model)
        {
            var user = await _context.TBUsers
                .Where(u => u.Email == model.Email)
                .FirstOrDefaultAsync();
            if (user == null || !AuthenticationHelper.IsValidPassword(model.Password, user.Password))
            {
                return null;
            }

            return GetLoginResponse(user.IdUser);
        }

        private LoginResponse GetLoginResponse(long userId)
        {
            var expirationTime = DateTime.UtcNow.AddSeconds(double.Parse(_configuration["JwtToken:Lifespan"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString())
                }),
                Expires = expirationTime,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Key"])),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new LoginResponse
            {
                Token = token,
                TokenExpirationTime = ((DateTimeOffset)expirationTime).ToUnixTimeSeconds(),
                UserId = userId,
            };
        }
    }
}

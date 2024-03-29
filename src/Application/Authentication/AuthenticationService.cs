﻿using AnticariApp.Application.Common;
using AnticariApp.Data.Context;
using AnticariApp.Utils.Enums;
using AnticariApp.Utils.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AnticariApp.Application.Authentication
{
    public interface IAuthService
    {
        public Task<LoginResponse> Login(LoginRequest model);
    }

    public class AuthService : DataService, IAuthService
    {
        private readonly MySqlContext _context;

        public AuthService(MySqlContext context)
        {
            _context = context;
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

            return new LoginResponse
            {
                UserId = user.IdUser,
                Role = (UserRole)user.UserRole,
            };
        }
    }
}

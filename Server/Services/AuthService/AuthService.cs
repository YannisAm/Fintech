using Fintech.Shared.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Fintech.Server.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private DataContext _context;

        public AuthService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<int>> CreateUserAsync(User user, string password)
        {
            if (await UserExists(user.Email))
                return new ServiceResponse<int>
                {
                    Success = false,
                    Message = "User already exists"
                };
            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new ServiceResponse<int>
            {
                Data = user.Id,
                Message = "Registration Succesfull"
            };
        }

        public async Task<bool> UserExists(string email)
        {
            if (await _context.Users
                .AnyAsync(u => u.Email.ToLower()
                .Equals(email.ToLower())))
                return true;
            else
                return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using(var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

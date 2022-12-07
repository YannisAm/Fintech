using Fintech.Shared.Models;

namespace Fintech.Server.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> CreateUserAsync(User user, string password);
        Task<bool> UserExists(string email);

    }
}

using Fintech.Shared.Models;

namespace Fintech.Server.Services.UserService
{
    public interface IUserService
    {
        Task<ServiceResponse<int>> CreateUserAsync(RegisterUser user);
    }
}

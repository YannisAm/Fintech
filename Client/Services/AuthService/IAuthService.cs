using Fintech.Shared.Models;

namespace Fintech.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> CreateUser(RegisterUser request);
    }
}

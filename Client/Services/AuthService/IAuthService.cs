using Fintech.Shared.Models;

namespace Fintech.Client.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<int>> CreateUser(RegisterUser request);
        Task<ServiceResponse<string>> LogIn(Login login);
        Task<ServiceResponse<bool>> ChangePassword(UserChangePassword request);
    }
}

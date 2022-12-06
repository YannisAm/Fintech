using Fintech.Shared.Models;

namespace Fintech.Client.Services.UserService
{
    public interface IUserService
    {
        Task CreateUser(RegisterUser user);
    }
}

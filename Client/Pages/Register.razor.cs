using Fintech.Client.Services.UserService;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class Register : ComponentBase
    {
        private RegisterUser user = new();
        private IUserService _userService;

        private async void HandleSubmit()
        {
            await _userService.CreateUser(user);
        }
    }
}

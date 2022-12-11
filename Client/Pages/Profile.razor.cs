using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Fintech.Client.Pages
{
    public partial class Profile : ComponentBase
    {
        [Inject]
        public IAuthService AuthService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        UserChangePassword request = new UserChangePassword();

        string message = string.Empty;

        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(request);
            message = result.Message;
        }
    }
}

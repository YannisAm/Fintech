using Fintech.Client.Services.UserService;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class Index : ComponentBase
    {
        private bool log = true;
        public RegisterUser user = new();
        public NavigationManager NavigationManager;
        public IUserService userService;


        private async void HandleSubmit()
        {
            
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/register", true);
        }

    }
}

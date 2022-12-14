using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject]
        public IAuthService AuthService { get; set; }
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public Fintech.Shared.Models.Login user { get; set; } = new Fintech.Shared.Models.Login();
        private string errorMessage = string.Empty;

        private async Task HandleLogin()
        {
            var result = await AuthService.LogIn(user);
            if (result.Success)
            {
                errorMessage = string.Empty;

                await LocalStorage.SetItemAsync("authToken", result.Data);
                await AuthenticationStateProvider.GetAuthenticationStateAsync();
                NavigationManager.NavigateTo("/home");
            }
            else
                errorMessage = result.Message;

        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/register", true);
        }
    }
}

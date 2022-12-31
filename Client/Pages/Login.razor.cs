using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fintech.Client.Pages
{
    public partial class Login : ComponentBase
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
        public string Password { get; set; } = "superstrong123";

        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        void ButtonTestclick()
        {
            if(isShow)
            {
                isShow = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                isShow = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }

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

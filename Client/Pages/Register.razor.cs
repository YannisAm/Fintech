using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fintech.Client.Pages
{
    public partial class Register : ComponentBase
    {
        [Inject]
        public IAuthService AuthService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Fintech.Shared.Models.RegisterUser request { get; set; } = new();

        string message = string.Empty;
        private Color messageColor;

        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;

        private void ButtonTestclick()
        {
            if (isShow)
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

        public async Task HandleSubmit()
        {
            var result = await AuthService.CreateUser(request);
            message = result.Message;
            if (result.Success)
                messageColor = Color.Tertiary;
            else
                messageColor = Color.Error;

            Navigate();
        }

        private async Task Navigate()
        {
            await Task.Delay(5000);
            NavigationManager.NavigateTo("/login");
        }
    }
}

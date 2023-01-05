using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.Filters;
using MudBlazor;
using System;

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
        bool isShow;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        private Color messageColor; 

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

        private async Task ChangePassword()
        {
            var result = await AuthService.ChangePassword(request);
            message = result.Message;
            if (!result.Success)
                messageColor = Color.Error;
            else
                messageColor = Color.Tertiary;

            Navigate();
        }

        private async Task Navigate()
        {
            await Task.Delay(5000);
            NavigationManager.NavigateTo("/home");
        }
    }
}

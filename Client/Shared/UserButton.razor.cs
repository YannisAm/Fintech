using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Shared
{
    public partial class UserButton : ComponentBase
    {
        [Inject]
        public ILocalStorageService LocalStorage { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private async Task Logout()
        {
            await LocalStorage.RemoveItemAsync("authToken");
            await AuthenticationStateProvider.GetAuthenticationStateAsync();
            NavigationManager.NavigateTo("/");
        }
    }
}

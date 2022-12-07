using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class Index : ComponentBase
    {
        private bool log = true;
        public RegisterUser user = new();
        [Inject]
        public NavigationManager NavigationManager { get; set; }



        private async void HandleSubmit()
        {

        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/register", true);
        }

    }
}

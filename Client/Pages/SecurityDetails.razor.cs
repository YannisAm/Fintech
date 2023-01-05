using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fintech.Client.Pages
{
    public partial class SecurityDetails : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private Security? security;
        [Inject]
        private IDialogService DialogService { get; set; }
        [Parameter]
        public int id { get; set; }


        protected override async Task OnInitializedAsync()
        {
            security = await SecurityService.GetSecurityById(id);
        }

        private async Task OpenDeleteDialog(Fintech.Shared.Models.Security security)
        {
            string state;
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this security?",
            yesText: "Delete!", cancelText: "Cancel");
            state = result == null ? "Cancelled" : "Deleted!";
            if (state == "Deleted!")
                await SecurityService.DeleteSecurity(id);
            NavigationManager.NavigateTo("/securities", true);
        }

    }
}

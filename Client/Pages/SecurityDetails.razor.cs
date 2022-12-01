using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class SecurityDetails : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        private Security? security;
        [Parameter]
        public bool DeleteDialogOpen { get; set; }
        private Security _securityToDelete;

        [Parameter]
        public int id { get; set; }

        private async Task OnDeleteDialogClose(bool accepted)
        {
            if (accepted)
            {
                await Delete(id);
                _securityToDelete = null;
                Navigate();
            }
            DeleteDialogOpen = false;
            StateHasChanged();
        }

        private async Task OpenDeleteDialog(Security security)
        {
            DeleteDialogOpen = true;
            _securityToDelete = security;
            StateHasChanged();
        }

        protected override async Task OnParametersSetAsync()
        {
            security = await SecurityService.GetSecurityById(id);
        }

        public async Task Delete(int id)
        {
            if (security != null)
            {
                await SecurityService.DeleteSecurity(id);

            }
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/securities", true);
        }
    }
}

using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Fintech.Client;

namespace Fintech.Client.Pages
{
    public partial class EditSecurity : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private Security? security = null;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            security = await SecurityService.GetSecurityById(Id);
        }

        public async Task Edit (Security security)
        {
            await SecurityService.EditSecurity(security);
            Navigate();
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/portfolio", true);
        }
    }
}

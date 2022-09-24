using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class EditSecurity : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }

        private Security? security = null;

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            security = SecurityService.Securities.Find(s => s.Id == Id);
        }

        public async Task Edit (Security security)
        {
            await SecurityService.EditSecurity(security);
            
        }

    }
}

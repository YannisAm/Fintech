using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class SecurityDetails : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        private Security? security;

        [Parameter]
        public int id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            security = await SecurityService.GetSecurityById(id);
        }

        public async Task Delete(int securityId)
        {
            if (security != null)
            {
                await SecurityService.DeleteSecurity(securityId);
            }
        }
    }
}

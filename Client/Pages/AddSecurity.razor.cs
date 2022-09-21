using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class AddSecurity : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        public Security Security { get; set; } = new();

        public async Task Create()
        {
            await SecurityService.CreateSecurity(Security);
        }
    }
}

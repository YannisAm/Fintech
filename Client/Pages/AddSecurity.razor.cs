using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Fintech.Client.Pages
{
    public partial class AddSecurity : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Security Security { get; set; } = new();

        public async Task Create()
        {
            await SecurityService.CreateSecurity(Security);
            NavigateToPortfolio navigate = new NavigateToPortfolio();
            navigate.Navigate();
        }
    }
}

using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace Fintech.Client.Pages
{
    public partial class AddPortfolio : ComponentBase
    {
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        public Fintech.Shared.Models.Portfolio Portfolio { get; set; } = new();

        public async Task Create()
        {
            await PortfolioService.CreatePortfolio(Portfolio);
            Navigate();
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/portfolio", true);
        }
    }
}

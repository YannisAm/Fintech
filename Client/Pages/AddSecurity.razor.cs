using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class AddSecurity : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        public Security Security { get; set; } = new();
        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        public int PortfolioId { get; set; }

        public async Task Create()
        {
            Security.Portfolio = await PortfolioService.GetPortfolioById(PortfolioId);
            await SecurityService.CreateSecurity(Security);
        }

        //private void Navigate()
        //{
        //    NavigationManager.NavigateTo("/securities", true);
        //}

        protected override async Task OnInitializedAsync()
        {
            Portfolios = await PortfolioService.GetPortfolios();
        }
    }
}

using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class EditPortfolio : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        Fintech.Shared.Models.Portfolio portfolio = new Fintech.Shared.Models.Portfolio();

        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            portfolio = await PortfolioService.GetPortfolioById(Id);
        }


        async Task HandleSubmit()
        {
            portfolio.DateTimeModified = DateTime.UtcNow;
            await PortfolioService.EditPortfolio(portfolio);
            NavigationManager.NavigateTo("/portfolio", true);
        }
    }
}

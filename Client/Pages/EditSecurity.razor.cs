using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class EditSecurity : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; }
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        Security security = new Security { Portfolio = new Fintech.Shared.Models.Portfolio() };

        //private Security security;
        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        [Parameter]
        public int Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Portfolios = await PortfolioService.GetPortfolios();
            security = await SecurityService.GetSecurityById(Id);
        }


        async Task HandleSubmit()
        {
            await SecurityService.EditSecurity(security);
            Navigate();
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/securities", true);
        }
    }
}

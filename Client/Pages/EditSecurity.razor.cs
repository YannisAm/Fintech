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

        private Security security;
        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        [Parameter]
        public int Id { get; set; }
        private Fintech.Shared.Models.Portfolio portfolaki;
        private int portfolakiId;

        protected override async Task OnInitializedAsync()
        {
            Portfolios = await PortfolioService.GetPortfolios();
        }

        protected override async Task OnParametersSetAsync()
        {
            security = await SecurityService.GetSecurityById(Id);

        }

        async Task HandleSubmit()
        {
            await SecurityService.EditSecurity(security);
            //Navigate();
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/securities", true);
        }
    }
}

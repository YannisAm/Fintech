using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Pages
{
    public partial class PortfolioDetails : ComponentBase
    {
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private Fintech.Shared.Models.Portfolio? portfolio;

        [Parameter]
        public int id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            portfolio = await PortfolioService.GetPortfolioById(id);
        }


        private void NavigationToSecurity()
        {
            NavigationManager.NavigateTo("/addSecurity", true);
        }

    }
}

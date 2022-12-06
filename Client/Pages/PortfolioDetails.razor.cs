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
        private Fintech.Shared.Models.Portfolio _portfolioToDelete;
        public bool DeleteDialogOpen { get; set; }

        [Parameter]
        public int id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            portfolio = await PortfolioService.GetPortfolioById(id);
        }


        private void NavigationToSecurity()
        {
            NavigationManager.NavigateTo("/portfolio", true);
        }
        private async Task OnDeleteDialogClose(bool accepted)
        {
            if (accepted)
            {
                await Delete(id);
                _portfolioToDelete = null;
                NavigationToSecurity();
            }
            DeleteDialogOpen = false;
            StateHasChanged();
        }

        private async Task OpenDeleteDialog(Fintech.Shared.Models.Portfolio portfolio)
        {
            DeleteDialogOpen = true;
            _portfolioToDelete = portfolio;
            StateHasChanged();
        }

        public async Task Delete(int id)
        {
            if (portfolio != null)
            {
                await PortfolioService.DeletePortfolio(id);

            }
        }

    }
}

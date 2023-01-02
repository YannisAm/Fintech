using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fintech.Client.Pages
{
    public partial class PortfolioDetails : ComponentBase
    {
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        private IDialogService DialogService { get; set; }

        private Fintech.Shared.Models.Portfolio? portfolio;

        [Parameter]
        public int id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            portfolio = await PortfolioService.GetPortfolioById(id);
        }

        private async Task OpenDeleteDialog(Fintech.Shared.Models.Portfolio portfolio)
        {
            string state;
            bool? result = await DialogService.ShowMessageBox(
            "Warning",
            "Are you sure you want to delete this portfolio and all it's securities?",
            yesText: "Delete!", cancelText: "Cancel");
            state = result == null ? "Cancelled" : "Deleted!";
            if(state == "Deleted!")
                await PortfolioService.DeletePortfolio(id);
            NavigationManager.NavigateTo("/portfolio", true);
        }
    }
}

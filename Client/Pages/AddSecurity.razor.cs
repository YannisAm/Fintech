using Fintech.Client.Services.PortfolioService;
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
        private int Id = 0;
        bool flag;
        
        

        protected override async Task OnInitializedAsync()
        {
            try
            {
                Portfolios = await PortfolioService.GetPortfolios();
                foreach (var portfolio in Portfolios)
                {
                    if (Id == 0)
                    {
                        Id = portfolio.Id;
                        break;
                    }
                }
                Security.Portfolio = await PortfolioService.GetPortfolioById(Id);
                Security.PortfolioId = Security.Portfolio.Id;
            }
            catch (NullReferenceException ex)
            {

                flag = true;
            }
        }


        async Task HandleSubmit()
        {
            await SecurityService.CreateSecurity(Security);
            Navigate();
        }

        private void Navigate()
        {
            NavigationManager.NavigateTo("/securities", true);
        }
    }
}

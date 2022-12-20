using Fintech.Client.Pages;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace Fintech.Client.Shared
{
    public partial class PortfolioList : ComponentBase
    {
        [Inject]
        public IPortfolioService? PortfolioService { get; set; }
        [Inject]
        public ISecurityService? SecurityService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private string userEmail;

        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        private List<Fintech.Shared.Models.Security> Securities = new();
        private List<int> securitiesCount = new List<int>();
        private int iterator = 0;
        private int sumOfSecurities = 0;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)user.Identity;
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                userEmail = userIdClaim?.Value;
            }

            Portfolios = await PortfolioService.GetPortfolios(userEmail);
            Securities = await SecurityService.GetSecurities(userEmail);
            
            foreach(var portfolio in Portfolios)
            {
                int count = 0;
                foreach(var security in Securities)
                {
                    if (portfolio.Id == security.PortfolioId)
                    {
                        count++;
                        sumOfSecurities++;
                    }
                        
                }
                securitiesCount.Add(count);
            }
        }

        private void NavigationToPortfolio()
        {
            NavigationManager.NavigateTo("/addPortfolio", true);
        }

    }
}

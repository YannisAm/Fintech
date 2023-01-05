using Fintech.Client.Pages;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Security.Claims;
using System.Xml.Linq;
using static MudBlazor.CategoryTypes;

namespace Fintech.Client.Shared
{
    public partial class PortfolioList : Microsoft.AspNetCore.Components.ComponentBase
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
        private int[] securitiesCount;
        private int iterator;
        private int i;

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
            
            foreach(var portfolio in Portfolios)
            {
                if (portfolio.Securities == null)
                    iterator = 0;
                else
                    iterator = portfolio.Securities.Count;
                iterator++;
            }
            securitiesCount = new int[iterator];
        }

        private void NavigationToPortfolio()
        {
            NavigationManager.NavigateTo("/addPortfolio", true);
        }
    }
}

using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace Fintech.Client.Pages
{
    public partial class AddPortfolio : ComponentBase
    {
        [Inject]
        public IPortfolioService PortfolioService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        public Fintech.Shared.Models.Portfolio Portfolio { get; set; } = new();
        private string userEmail;

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)user.Identity;
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                userEmail = userIdClaim?.Value;
                Portfolio.UserEmail = userEmail;
            }
        }

        public async Task Create()
        {
            await PortfolioService.CreatePortfolio(Portfolio);
            NavigationManager.NavigateTo("/portfolio", true);
        }
    }
}

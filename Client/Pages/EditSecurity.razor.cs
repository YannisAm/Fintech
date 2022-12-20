using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

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
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
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
            }

            Portfolios = await PortfolioService.GetPortfolios(userEmail);
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

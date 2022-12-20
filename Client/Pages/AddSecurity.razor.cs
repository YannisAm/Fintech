using Fintech.Client.Services.PortfolioService;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

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
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private string userEmail;
        public Security Security { get; set; } = new();
        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        private int Id = 0;
        bool flag;
        
        

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

            try
            {
                Portfolios = await PortfolioService.GetPortfolios(userEmail);
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
                Security.UserEmail = userEmail;
            }
            catch (NullReferenceException)
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

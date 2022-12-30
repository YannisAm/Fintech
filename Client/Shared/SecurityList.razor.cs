using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        [Inject]
        public ISecurityService? SecurityService { get; set; } = null;
        [Inject]
        public IPortfolioService? PortfolioService { get; set; } = null;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        private string userEmail;
        private List<Security> Securities = new();
        private Portfolio Portfolio= new Portfolio();
        List<string> names = new List<string>();
        int iterator = 0;                                           //We use this integer as an itirator to run the whole name list and to 
                                                                    //present every element on frontend
        protected override async Task OnInitializedAsync()          //When the page is rendered we bring all the securities. Furthermore, we are getting the portfolios
        {                                                           //and assigning them in a list, because we want to use them in the razor page.
            var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            if (user.Identity.IsAuthenticated)
            {
                var claimsIdentity = (ClaimsIdentity)user.Identity;
                var userIdClaim = claimsIdentity.FindFirst(ClaimTypes.Name);
                userEmail = userIdClaim?.Value;
            }

            Securities = await SecurityService.GetSecurities(userEmail);
            foreach (var security in Securities)
            {
                Portfolio = await PortfolioService.GetPortfolioById(security.PortfolioId);
                names.Add(Portfolio.NameOfPortfolio);
            }
        }

        private double SumOfStocks()
        {
            double sumOfStocks = 0f;
            foreach (var security in Securities)
            {
                sumOfStocks += security.StocksValue;
            }
            return sumOfStocks;

        }

        private int NumberOfStocks()
        {
            int numberOfStocks = 0;
            foreach (var security in Securities)
            {
                numberOfStocks += security.StockesOwned;
            }
            return numberOfStocks;
        }

        private string CutTheText(string description)
        {
            const int maxLength = 20;

            var words = description.Split(' ');
            if (words.Length > maxLength)
            {
                var totalCharacters = 0;
                var summaryWords = new List<string>();

                foreach (var word in words)
                {
                    summaryWords.Add(word);

                    totalCharacters += word.Length + 1;
                    if (totalCharacters > maxLength)
                        break;
                }

                return String.Join(" ", summaryWords) + "...";
            }
            return description;
        }

        private void NavigationToSecurity()
        {
            NavigationManager.NavigateTo("/addSecurity", true);
        }

    }
}

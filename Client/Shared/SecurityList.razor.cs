using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        [Inject]
        public ISecurityService SecurityService { get; set; } = null;
        [Inject]
        public IPortfolioService PortfolioService { get; set; } = null;
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider AuthenticationStateProvider { get; set; }
        
        private string? userEmail;
        private string searchString1 = "";
        private Fintech.Shared.Models.Security _selectedItem1 = null;
        private List<Security> Securities = new();
        private Portfolio Portfolio= new Portfolio();
        List<string> names = new List<string>();
        private bool FilterFunc1(Fintech.Shared.Models.Security security) => FilterFunc(security, searchString1);

        private string infoFormat = "{first_item}-{last_item} of {all_items}";

        //We use this integer as an itirator to run the whole name list and to 
        //present every element on frontend
        int iterator = 0;       
        

        //When the page is rendered we bring all the securities. Furthermore, we are getting
        //the portfolios
        //and assigning them in a list, because we want to use them in the razor page.
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

            Securities = await SecurityService.GetSecurities(userEmail);
            foreach (var security in Securities)
            {
                Portfolio = await PortfolioService.GetPortfolioById(security.PortfolioId);
                names.Add(Portfolio.NameOfPortfolio);
            }
        }

        private double SumOfStocks()
        {
            double sumOfStocks = 0;
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

        private bool FilterFunc(Fintech.Shared.Models.Security security, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ($"{security.SecurityName} {security.Description}".Contains(searchString))
                return true;
            return false;
        }

        public string CutTheText(string description)
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
    }
}

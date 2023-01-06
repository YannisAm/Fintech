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
        private string searchString1 = "";
        private Fintech.Shared.Models.Portfolio _selectedItem1 = null;

        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        private List<Fintech.Shared.Models.Security> Securities = new();
        private List<int> securitiesCount = new();
        private int iterator;
        private int count;
        private bool FilterFunc1(Fintech.Shared.Models.Portfolio portfolio) => FilterFunc(portfolio, searchString1);

        private string infoFormat = "{first_item}-{last_item} of {all_items}";

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
                count = 0;
                foreach (var security in Securities)
                {
                    if (security.PortfolioId == portfolio.Id)
                    {
                        count++;
                    }
                }
                securitiesCount.Add(count);
            }
        }

        private bool FilterFunc(Fintech.Shared.Models.Portfolio portfolio, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if ($"{portfolio.NameOfPortfolio} {portfolio.Description}".Contains(searchString))
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

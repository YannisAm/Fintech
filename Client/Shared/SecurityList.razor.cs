using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

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
        private List<Security> Securities = new();
        private Portfolio Portfolio= new Portfolio();
        private List<string> names = new ();
        private int cnt = 0;

        private static float ValueOfEachStock(Security security)
            => security.Price * security.StockesOwned;

        private float SumOfStocks()
        {
            float sumOfStocks = 0f;
            foreach (var security in Securities)
            {
                sumOfStocks += ValueOfEachStock(security);
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

        protected override async Task OnInitializedAsync()
        {
            Securities = await SecurityService.GetSecurities();
            foreach (var security in Securities)
                names.Add(await PortfolioService.GetPortfolioNameBySecurity(security));
        }

        //protected override async Task OnParametersSetAsync()
        //{
        //    foreach (var security in Securities)
        //    {
        //        Portfolio = await PortfolioService.GetPortfolioById(security.PortfolioId);
        //        security.Portfolio.NameOfPortfolio = Portfolio.NameOfPortfolio;
        //    }
        //}

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

        //private async Task<string> GetName(Security security)
        //{
        //    var name = await PortfolioService.GetPortfolioNameBySecurity(security);
        //    return name;
        //}

    }
}

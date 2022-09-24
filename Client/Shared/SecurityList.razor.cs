using Fintech.Shared;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace Fintech.Client.Shared
{
    public partial class SecurityList : ComponentBase
    {
        [Inject]
        public ISecurityService? SecurityService { get; set; } = null;

        private static List<Security> Securities = new List<Security>();

        private static float ValueOfEachStock (Security security)
        {
            float valueOfStock = security.Price * security.StockesOwned;
            return valueOfStock;
        }

        private static float SumOfStocks (SecurityService securities)
        {
            float sumOfStocks = 0f;
            foreach (var security in securities.Securities)
            {
                sumOfStocks += security.StockesOwned;
            }
            return sumOfStocks;

        }

        private static int NumberOfStocks (SecurityService securities)
        {
            int numberOfStocks = 0;
            foreach (var security in securities.Securities)
            {
                numberOfStocks += security.StockesOwned;
            }
            return numberOfStocks;
        }


        protected override async Task OnInitializedAsync()
        {
            await SecurityService.GetSecurities();
        }
    }
}

﻿using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;

namespace Fintech.Client.Shared
{
    public partial class PortfolioList : ComponentBase
    {
        [Inject]
        public IPortfolioService? PortfolioService { get; set; } = null;
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private List<Portfolio> Portfolios = new();

        protected override async Task OnInitializedAsync()
        {
            Portfolios = await PortfolioService.GetPortfolios();
        }

        protected int CountSecurities (Portfolio portfolio)
        {
            int countSecurities = 0;
            return countSecurities = portfolio.Securities.Count();
        }

        private void Navigation()
        {
            NavigationManager.NavigateTo("/addPortfolio", true);
        }
    }
}
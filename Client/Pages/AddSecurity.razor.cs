﻿using Fintech.Client.Services.PortfolioService;
using Fintech.Client.Shared;
using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

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
        public Security Security { get; set; } = new();
        private List<Fintech.Shared.Models.Portfolio> Portfolios = new();
        private Fintech.Shared.Models.Portfolio SelectedPortfolio { get; set; }
        private string choice { get; set; }


        public async Task Create()
        {
            await SecurityService.CreateSecurity(Security);
            SelectedPortfolio = PortfolioService.GetPortfolioByName(choice).Result;
            Security.Portfolio = SelectedPortfolio;
            //Navigate();
            //ServiceResponse na valw
        }

        private void Navigate()
        {
            //NavigationManager.NavigateTo("/securities", true);
        }

        protected override async Task OnInitializedAsync()
        {
            Portfolios = await PortfolioService.GetPortfolios();                                                           //inject portfolio service
        }


    }
}

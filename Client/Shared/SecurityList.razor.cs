﻿using Fintech.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
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
        List<string> names = new List<string>();
        int iterator = 0;              //We use this integer as an itirator to run the whole name list and to present every element on frontend


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

        protected override async Task OnInitializedAsync()                      //When the page is rendered we bring all the securities. Furthermore, we are getting the portfolios
        {                                                                       //and assigning them in a list, because we want to use them in the razor page.
            Securities = await SecurityService.GetSecurities();
            foreach (var security in Securities)
            {
                Portfolio = await PortfolioService.GetPortfolioById(security.PortfolioId);
                names.Add(Portfolio.NameOfPortfolio);
            }
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

        //private async Task<string> GetName(Security security)
        //{
        //    var name = await PortfolioService.GetPortfolioNameBySecurity(security);
        //    return name;
        //}

    }
}
